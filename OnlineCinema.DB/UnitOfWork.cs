using OnlineCinema.DB.DataModels;
using OnlineCinema.DB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCinema.DB
{
    public class UnitOfWork : IDisposable
    {
        private bool disposed = false;

        private OnlineCinemaDataModel context = new OnlineCinemaDataModel();

        private EFGenreRepository _eFGenreRepository;

        private EFMovieRepository _eFMovieRepository;

        private EFScheduleRepository _eFScheduleRepository;

        private EFSessionRepository _eFSessionRepository;

        public EFGenreRepository EFGenreRepository
        {
            get
            {
                if (_eFGenreRepository == null)
                {
                    _eFGenreRepository = new EFGenreRepository(context);
                }

                return _eFGenreRepository;
            }
        }

        public EFMovieRepository EFTransacyionRepository
        {
            get
            {
                if (_eFMovieRepository == null)
                {
                    _eFMovieRepository = new EFMovieRepository(context);
                }
                return _eFMovieRepository;
            }
        }

        public EFScheduleRepository EFScheduleRepository
        {
            get
            {
                if (_eFScheduleRepository == null)
                {
                    _eFScheduleRepository = new EFScheduleRepository(context);
                }
                return _eFScheduleRepository;
            }
        }

        public EFSessionRepository EFSessionRepository
        {
            get
            {
                if (_eFSessionRepository == null)
                {
                    _eFSessionRepository = new EFSessionRepository(context);
                }
                return _eFSessionRepository;
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
