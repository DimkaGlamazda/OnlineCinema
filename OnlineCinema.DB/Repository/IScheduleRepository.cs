using OnlineCinema.DB.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
