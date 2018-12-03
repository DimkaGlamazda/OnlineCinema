using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineCinema.DB.DataModels;

namespace OnlineCinema.DB.Repository
{
    public class EFScheduleRepository : IScheduleRepository
    {
        private OnlineCinemaDataModel _context;

        public EFScheduleRepository(OnlineCinemaDataModel context)
        {
            _context = context;
        }

        public int Add(Schedule schedule)
        {
            _context.Schedule.Add(schedule);

            return schedule.Id;
        }

        public void Delete(int id)
        {
        }

        public List<Schedule> Get()
        {
            return _context.Schedule.ToList();
        }

        public Schedule GetDeteils(int id)
        {
            return _context.Schedule.FirstOrDefault(x=>x.Id==id);
        }

        public void Update(Schedule schedule)
        {
            var OldSchedule = GetDeteils(schedule.Id);

            OldSchedule.Movie = schedule.Movie;
            OldSchedule.MovieId = schedule.MovieId;
            OldSchedule.Session = schedule.Session;
            OldSchedule.SessionId = schedule.SessionId;
            OldSchedule.Date = schedule.Date;
        }
    }
}
