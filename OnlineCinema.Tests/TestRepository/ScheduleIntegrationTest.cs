

using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineCinema.DB;
using OnlineCinema.DB.DataModels;
using System;
using System.Linq;
using System.Transactions;

namespace OnlineCinema.Tests.TestRepository
{
    [TestClass]
    public class ScheduleIntegrationTest
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
            var isExists = _ctx.Schedule.Any();

            int count = _ctx.Schedule.Count();

            // Action

            int uOwCount = _uOw.EFScheduleRepository.Get().Count;

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
                int countBefore = _ctx.Schedule.Count();

                // Action
                _uOw.EFScheduleRepository.Add(new Schedule {
                    Date = new DateTime(),
                    MovieId = 1,
                    SessionId = 1
                });

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

                int countBefore = _ctx.Schedule
                    .Count();

                var schedule = _ctx.Schedule
                    .FirstOrDefault();

                if (schedule == null)
                {
                    Assert.IsTrue(true, "Existing item not found.");
                    return;
                }

                // Action 

                _uOw.EFScheduleRepository.Delete(schedule.Id);
                _uOw.Save();

                int countAfter = _ctx.Schedule
                    .Count();

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

                DateTime newDate = new DateTime();

                var schedule = _ctx.Schedule
                    .FirstOrDefault();

                if (schedule == null)
                {
                    Assert.IsTrue(true, "Any item not found.");
                    return;
                }

                // Action 

                schedule.Date = newDate;

                _uOw.EFScheduleRepository.Update(schedule);
                _uOw.Save();

                // Assert

                Assert.AreEqual(newDate, _ctx.Schedule.First(c => c.Id == schedule.Id).Date);
            }
        }

        [TestMethod]
        public void Test_GetDetail()
        {
            // Assign

            var schedule = _ctx.Schedule
                .FirstOrDefault();

            if (schedule == null)
            {
                Assert.IsTrue(true, "Any item not found.");
                return;
            }

            // Action

            var uOwSchedule = _uOw.EFScheduleRepository.GetDeteils(schedule.Id);

            // Assert

            Assert.AreEqual(schedule.Id, uOwSchedule.Id);
        }
    }
}
