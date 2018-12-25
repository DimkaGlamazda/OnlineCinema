using OnlineCinema.BL.Extensions;
using OnlineCinema.BL.Model;
using OnlineCinema.DB;
using OnlineCinema.DB.DTOs;
using OnlineCinema.DB.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCinema.BL.Services
{
    public interface IScheduleService
    {
        int Add(IScheduleView scheduleDto);

        void Update(IScheduleView scheduleDto);

        void Delete(int id);

        ScheduleView GetItem(int id);

        ScheduleAdminView GetItemForAdmin(int id);

        List<ScheduleView> GetAll();

        List<ScheduleAdminView> GetAllForAdmin();
    }

    public class ScheduleService : IScheduleService
    {
        private UnitOfWork _uOW = new UnitOfWork();

        public int Add(IScheduleView scheduleView)
        {
            var newItem = scheduleView.ToDtoModel().ToSqlModel();

            int count = _uOW.EFScheduleRepository.Get()
                .Count(
                    m => m.MovieId == newItem.MovieId
                    && m.SessionId == newItem.SessionId
                    && m.Date == newItem.Date
                );

            if (count > 0)
                throw new ItemAlreadyExistException();

    
            _uOW.EFScheduleRepository.Add(newItem);
            _uOW.Save();

            return newItem.Id;
        }

        public void Delete(int id)
        {
            _uOW.EFScheduleRepository.Delete(id);
            _uOW.Save();
        }

        public List<ScheduleView> GetAll()
        {
            return _uOW.EFScheduleRepository.Get().Select(s => s.ToDto().ToViewModel()).ToList();
        }

        public List<ScheduleAdminView> GetAllForAdmin()
        {
            return _uOW.EFScheduleRepository.Get().Select(s => s.ToDto().ToAdminViewModel()).ToList();
        }

        public ScheduleView GetItem(int id)
        {
            return _uOW.EFScheduleRepository.GetDeteils(id).ToDto().ToViewModel();
        }

        public ScheduleAdminView GetItemForAdmin(int id)
        {
            return _uOW.EFScheduleRepository.GetDeteils(id).ToDto().ToAdminViewModel();
        }

        public void Update(IScheduleView scheduleView)
        {
            var newItem = scheduleView.ToDtoModel().ToSqlModel();

            int count = _uOW.EFScheduleRepository.Get()
                .Count(
                    m => m.MovieId == newItem.MovieId
                    && m.SessionId == newItem.SessionId
                    && m.Date == newItem.Date
                    && m.Id != newItem.Id
                );

            if (count > 0)
                throw new ItemAlreadyExistException();

            _uOW.EFScheduleRepository.Update(newItem);
            _uOW.Save();
        }
    }
}
