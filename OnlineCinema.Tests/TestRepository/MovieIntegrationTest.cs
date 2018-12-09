using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineCinema.DB;
using OnlineCinema.DB.DataModels;
using System.Linq;
using System.Transactions;

namespace OnlineCinema.Tests.TestRepository
{
    [TestClass]
    public class MovieIntegrationTest
    {
        private UnitOfWork _uOw;

        private OnlineCinemaDataModel _ctx;

        [TestInitialize]
        public void Initialize()
        {
            _ctx = new OnlineCinemaDataModel();
            _uOw = new UnitOfWork();
        }

        [TestCleanup]
        public void Destroer() { }

        [TestMethod]
        public void Test_DbRecording()
        {
            var isExists = _ctx.Movie.Any();

            Assert.IsTrue(isExists);
        }

        [TestMethod]
        public void Test_Get()
        {
            // Assign
            var isExists = _ctx.Movie.Any();

            int count = _ctx.Movie
                .Count(c => !c.IsDeleted.HasValue || !c.IsDeleted.Value);

            // Action

            int uOwCount = _uOw.EFMovieRepository.Get().Count;

            // Assert

            if (!isExists)
            {
                Assert.IsTrue(true, "No records in Movie table.");
                return;
            }

            Assert.AreEqual(uOwCount, count);
        }

        [TestMethod]
        public void Test_Add()
        {
            using (new TransactionScope())
            {
                // Assign 
                int countBefore = _ctx.Movie.Count();

                // Action
                _uOw.EFMovieRepository.Add(
                    new Movie
                    {
                        IsDeleted = false,
                        GenreId = 1,
                        Name = "Test Movie Title"
                    }
                );

                _uOw.Save();

                // Assert

                Assert.AreEqual(countBefore + 1, _ctx.Movie.Count());
            }
        }

        [TestMethod]
        public void Test_Delete()
        {
            using (new TransactionScope())
            {
                // Assign 

                int countBefore = _ctx.Movie
                    .Count(c => !c.IsDeleted.HasValue || !c.IsDeleted.Value);

                var movie = _ctx.Movie
                    .FirstOrDefault(c => !c.IsDeleted.HasValue || !c.IsDeleted.Value);

                if (movie == null)
                {
                    Assert.IsTrue(true, "Existing item not found.");
                    return;
                }

                // Action 

                _uOw.EFMovieRepository.Delete(movie.Id);
                _uOw.Save();

                int countAfter = _ctx.Movie
                    .Count(c => !c.IsDeleted.HasValue || !c.IsDeleted.Value);

                // Assert

                Assert.AreEqual(countBefore - 1, countAfter);
            }
        }

        [TestMethod]
        public void Test_Update()
        {
            using (new TransactionScope())
            {
                // Assign 

                string newName = "TestName";

                var movie = _ctx.Movie
                    .FirstOrDefault(c => !c.IsDeleted.HasValue || !c.IsDeleted.Value);

                if (movie == null)
                {
                    Assert.IsTrue(true, "Any item not found.");
                    return;
                }

                // Action 

                movie.Name = newName;

                _uOw.EFMovieRepository.Update(movie);
                _uOw.Save();

                // Assert

                Assert.AreEqual(newName, _ctx.Movie.First(c => c.Id == movie.Id).Name);
            }
        }

        [TestMethod]
        public void Test_GetDetail()
        {
            // Assign

            var movie = _ctx.Movie
                .FirstOrDefault(c => !c.IsDeleted.HasValue || !c.IsDeleted.Value);

            if (movie == null)
            {
                Assert.IsTrue(true, "Any item not found.");
                return;
            }

            // Action

            var uOwMovie = _uOw.EFMovieRepository.GetDeteils(movie.Id);

            // Assert

            Assert.AreEqual(movie.Id, uOwMovie.Id);
        }

        [TestMethod]
        public void Test_GetDetailDeleted()
        {
            // Assign

            var movie = _ctx.Movie
                .Where(c => c.IsDeleted.HasValue && c.IsDeleted.Value)
                .FirstOrDefault();

            if (movie == null)
            {
                Assert.IsTrue(true, "Any deleted item not found.");
                return;
            }

            // Action

            var uOwMovie = _uOw.EFMovieRepository.GetDeteils(movie.Id);

            // Assert
       
            Assert.IsNull(uOwMovie);
        }
    }
}
