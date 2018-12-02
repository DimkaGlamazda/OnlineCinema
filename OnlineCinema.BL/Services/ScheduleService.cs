using OnlineCinema.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCinema.BL.Services
{
    public interface IScheduleService
    {
        //need ScheduleDto
        int Add(ScheduleView schedule);

        void Update(ScheduleView schedule);

        void Delete(int id);

        ScheduleView GetItem(int id);

        List<ScheduleView> GetAll();
    }

    public class ScheduleService : IScheduleService
    {
        public int Add(ScheduleView schedule)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<ScheduleView> GetAll()
        {
            throw new NotImplementedException();
        }

        public ScheduleView GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(ScheduleView schedule)
        {
            throw new NotImplementedException();
        }
    }
}
