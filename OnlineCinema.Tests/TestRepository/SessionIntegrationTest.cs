
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineCinema.DB;
using OnlineCinema.DB.DataModels;
using System;
using System.Linq;
using System.Transactions;

namespace OnlineCinema.Tests.TestRepository
{
    [TestClass]
    public class SessionIntegrationTest
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
            var isExists = _ctx.Session.Any();

            Assert.IsTrue(isExists);
        }

        [TestMethod]
        public void Test_Get()
        {
            // Assign
            var isExists = _ctx.Session.Any();

            int count = _ctx.Session
                .Count(c => !c.IsDeleted.HasValue || !c.IsDeleted.Value);

            // Action

            int uOwCount = _uOw.EFSessionRepository.Get().Count;

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
                int countBefore = _ctx.Session.Count();

                // Action
                _uOw.EFSessionRepository.Add(
                    new Session
                    {
                        IsDeleted = false,
                        Title = "Test Session Title",
                        TimeFrom = new TimeSpan(),
                        TimeTo = new TimeSpan()
                    }
                );

                _uOw.Save();

                // Assert

                Assert.AreEqual(countBefore + 1, _ctx.Session.Count());
            }
        }

        [TestMethod]
        public void Test_Delete()
        {
            using (new TransactionScope())
            {
                // Assign 

                int countBefore = _ctx.Session
                    .Count(c => !c.IsDeleted.HasValue || !c.IsDeleted.Value);

                var session = _ctx.Session
                    .FirstOrDefault(c => !c.IsDeleted.HasValue || !c.IsDeleted.Value);

                if (session == null)
                {
                    Assert.IsTrue(true, "Existing item not found.");
                    return;
                }

                // Action 

                _uOw.EFSessionRepository.Delete(session.Id);
                _uOw.Save();

                int countAfter = _ctx.Session
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

                var session = _ctx.Session
                    .FirstOrDefault(c => !c.IsDeleted.HasValue || !c.IsDeleted.Value);

                if (session == null)
                {
                    Assert.IsTrue(true, "Any item not found.");
                    return;
                }

                // Action 

                session.Title = newName;

                _uOw.EFSessionRepository.Update(session);
                _uOw.Save();

                // Assert

                Assert.AreEqual(newName, _ctx.Session.First(c => c.Id == session.Id).Title);
            }
        }

        [TestMethod]
        public void Test_GetDetail()
        {
            // Assign

            var session = _ctx.Session
                .FirstOrDefault(c => !c.IsDeleted.HasValue || !c.IsDeleted.Value);

            if (session == null)
            {
                Assert.IsTrue(true, "Any item not found.");
                return;
            }

            // Action

            var uOwSession = _uOw.EFSessionRepository.GetDeteils(session.Id);

            // Assert

            Assert.AreEqual(session.Id, uOwSession.Id);
        }

        [TestMethod]
        public void Test_GetDetailDeleted()
        {
            // Assign

            var session = _ctx.Session
                .Where(c => c.IsDeleted.HasValue && c.IsDeleted.Value)
                .FirstOrDefault();

            if (session == null)
            {
                Assert.IsTrue(true, "Any deleted item not found.");
                return;
            }

            // Action

            var uOwSession = _uOw.EFSessionRepository.GetDeteils(session.Id);

            // Assert

            Assert.IsNull(uOwSession);
        }
    }
}
