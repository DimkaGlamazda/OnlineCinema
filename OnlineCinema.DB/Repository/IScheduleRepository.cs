using OnlineCinema.DB.DataModels;
using System.Collections.Generic;

namespace OnlineCinema.DB.Repository
{
    public interface IScheduleRepository
    {
        int Add(Schedule schedule);

        void Update(Schedule schedule);

        void Delete(int id);

        Schedule GetDeteils(int id);

        List<Schedule> Get();
    }
}
