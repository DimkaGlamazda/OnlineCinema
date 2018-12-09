using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineCinema.DB;
using OnlineCinema.DB.DataModels;
using System.Linq;
using System.Transactions;

namespace OnlineCinema.Tests.TestRepository
{
    [TestClass]
    public class GenreIntegratedTest
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
        public void Destroer() {}

        [TestMethod]
        public void Test_DbRecording()
        {
            var isExists = _ctx.Genre.Any();

            Assert.IsTrue(isExists);
        }

        [TestMethod]
        public void Test_Get()
        {
            // Assign
            var isExists = _ctx.Genre.Any();

            int count = _ctx.Genre
                .Count(c => !c.IsDeleted.HasValue || !c.IsDeleted.Value);

            // Action

            int uOwCount = _uOw.EFGenreRepository.Get().Count;

            // Assert

            if (!isExists)
            {
                Assert.IsTrue(true, "No records in Ganre table.");
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
                int countBefore = _ctx.Genre.Count();

                // Action
                _uOw.EFGenreRepository.Add(
                    new Genre
                    {
                        IsDeleted = false,
                        Name = "Test Genre Title"
                    }
                );

                _uOw.Save();

                // Assert

                Assert.AreEqual(countBefore + 1, _ctx.Genre.Count());
            }
        }

        [TestMethod]
        public void Test_Delete()
        {
            using (new TransactionScope())
            {
                // Assign 

                int countBefore = _ctx.Genre
                    .Count(c => !c.IsDeleted.HasValue || !c.IsDeleted.Value);

                var genre = _ctx.Genre
                    .FirstOrDefault(c => !c.IsDeleted.HasValue || !c.IsDeleted.Value);

                if(genre == null)
                {
                    Assert.IsTrue(true, "Existing item not found.");
                    return;
                }

                // Action 

                _uOw.EFGenreRepository.Delete(genre.Id);
                _uOw.Save();

                int countAfter = _ctx.Genre
                    .Count(c => !c.IsDeleted.HasValue || !c.IsDeleted.Value);

                // Assert

                Assert.AreEqual(countBefore - 1 , countAfter);
            }
        }

        [TestMethod]
        public void Test_Update()
        {
            using (new TransactionScope())
            {
                // Assign 

                string newName = "TestName";

                var genre = _ctx.Genre
                    .FirstOrDefault();

                if (genre == null)
                {
                    Assert.IsTrue(true, "Any item not found.");
                    return;
                }

                // Action 

                genre.Name = newName;

                _uOw.EFGenreRepository.Update(genre);
                _uOw.Save();

                // Assert

                Assert.AreEqual(newName, _ctx.Genre.First(c => c.Id == genre.Id).Name);
            }
        }

        [TestMethod]
        public void Test_GetDetail()
        {
            // Assign

            var genre = _ctx.Genre
                .FirstOrDefault(c => !c.IsDeleted.HasValue || !c.IsDeleted.Value);

            if (genre == null)
            {
                Assert.IsTrue(true, "Any item not found.");
                return;
            }

            // Action

            var uOwGenre = _uOw.EFGenreRepository.GetDeteils(genre.Id);

            // Assert

            Assert.AreEqual(genre.Id, uOwGenre.Id);
        }

        [TestMethod]
        public void Test_GetDetailDeleted()
        {
            // Assign

            var genre = _ctx.Genre
                .Where(c => c.IsDeleted.HasValue && c.IsDeleted.Value)
                .FirstOrDefault();

            if (genre == null)
            {
                Assert.IsTrue(true, "Any deleted item not found.");
                return;
            }

            // Action

            var uOwGenre = _uOw.EFGenreRepository.GetDeteils(genre.Id);

            // Assert

            Assert.IsNull(uOwGenre);
        }
    }
}
