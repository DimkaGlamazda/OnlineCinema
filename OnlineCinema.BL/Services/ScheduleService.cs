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
        int Add(ScheduleDto scheduleDto);

        void Update(ScheduleDto scheduleDto);

        void Delete(int id);

        ScheduleDto GetItem(int id);

        List<ScheduleDto> GetAll();
    }

    public class ScheduleService : IScheduleService
    {
        private UnitOfWork _uOW = new UnitOfWork();

        public int Add(ScheduleDto scheduleDto)
        {
            var schedule = scheduleDto.ToSqlModel();
            _uOW.EFScheduleRepository.Add(schedule);
            _uOW.Save();

            return schedule.Id;
        }

        public void Delete(int id)
        {
            var schedule = GetItem(id);
            //schedule.IsDeleted = true;
            _uOW.Save();
        }

        public List<ScheduleDto> GetAll()
        {
            return _uOW.EFScheduleRepository.Get().Select(s => s.ToDto()).ToList();
        }

        public ScheduleDto GetItem(int id)
        {
            return _uOW.EFScheduleRepository.GetDeteils(id).ToDto();
        }

        public void Update(ScheduleDto scheduleDto)
        {
            var schedule = scheduleDto.ToSqlModel();
            _uOW.Save();
        }
    }
}
