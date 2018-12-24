using OnlineCinema.API.Models;
using OnlineCinema.BL.Extensions;
using OnlineCinema.BL.Model;
using OnlineCinema.BL.Services;
using OnlineCinema.DB.DataModels;
using OnlineCinema.DB.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineCinema.API.Controllers
{
    public class ScheduleMVCController : Controller
    {
        private readonly IMovieService _movieService = new MovieService();
        private readonly IScheduleService _scheduleServise = new ScheduleService();
        private readonly ISessionService _sessionServics = new SessionService();

        [HttpGet]
        public ActionResult Index()
        {
            var model = _scheduleServise.GetAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult Editor(int id)
        {
            
            ViewBag.MovieList = _movieService.GetAll();
            ViewBag.SessionList = _sessionServics.GetAll();

            var model = new ScheduleView();

            if(id != 0)
            {
                model = _scheduleServise.GetItem(id);
            }


            return View("Edit", model);
        }

        [HttpPost]
        public ActionResult Save(ScheduleView model)
        {

            ViewBag.MovieList = _movieService.GetAll();
            ViewBag.SessionList = _sessionServics.GetAll();

            if (!ModelState.IsValid)
                return View("Edit", model);

            try
            {
                if (model.Id == 0)
                {
                    _scheduleServise.Add(model);
                }
                else
                {
                    _scheduleServise.Update(model);
                }
            }
            catch (DublicateScheduleItemException e)
            {
                ModelState.AddModelError("MovieId", "Item with this value already exists.");
                ModelState.AddModelError("SessionId", "Item with this value already exists.");
                ModelState.AddModelError("Date", "Item with this value already exists.");
            }


            return View("Edit", model);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                _scheduleServise.Delete(id);
                ViewBag.SuccessMessage = "Item has been deleted";
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
            }

            var schedule = _scheduleServise.GetAll();
            return View("Index", schedule);
        }
    }
}