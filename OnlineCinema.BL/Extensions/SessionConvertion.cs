using OnlineCinema.BL.Model;
using OnlineCinema.DB.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCinema.BL.Extensions
{
    static class SessionConvertion
    {
        public static SessionView ToViewModel(this SessionDto sessionDto)
        {
            if (sessionDto == null)
            {
                return null;
            }

            return new SessionView
            {
                Id = sessionDto.Id,
                Title = sessionDto.Title,
                TimeFrom = sessionDto.TimeFrom,
                TimeTo = sessionDto.TimeTo,
                IsDeleted = sessionDto.IsDeleted
            };
        }

        public static SessionDto ToDtoModel(this SessionView sessionView)
        {
            if (sessionView == null)
            {
                return null;
            }

            return new SessionDto
            {
                Id = sessionView.Id,
                Title = sessionView.Title,
                TimeFrom = sessionView.TimeFrom,
                TimeTo = sessionView.TimeTo,
                IsDeleted = sessionView.IsDeleted
            };
        }
    }
}
