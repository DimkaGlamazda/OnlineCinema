using OnlineCinema.BL.Extensions;
using OnlineCinema.BL.Model;
using OnlineCinema.BL.Services;
using System;
using System.Web.Mvc;
using Ninject;

namespace OnlineCinema.API.Controllers
{
    public class ScheduleMVCController : Controller
    {
        private readonly IScheduleService _scheduleServise;

        public ScheduleMVCController(IScheduleService scheduleService)
        {
            _scheduleServise = scheduleService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = _scheduleServise.GetAllForAdmin();
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = new ScheduleAdminView();

            if(id != 0)
            {
                model = _scheduleServise.GetItemForAdmin(id);
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Save(ScheduleAdminView model)
        {
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
            catch (ItemAlreadyExistException)
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