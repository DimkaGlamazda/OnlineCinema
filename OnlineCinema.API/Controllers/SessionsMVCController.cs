using Newtonsoft.Json;
using OnlineCinema.BL.Extensions;
using OnlineCinema.BL.Model;
using OnlineCinema.BL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace OnlineCinema.API.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class SessionsMVCController : Controller
    {
        private readonly ISessionService _sessionService;

        public SessionsMVCController()
        {
            _sessionService = new SessionService();
        }

        public SessionsMVCController(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }

        //Get All: SessionsMVC/Index
        [HttpGet]
        public ActionResult Index()
        {
            var list = _sessionService.GetAll().Select(s => s.ToViewModel());

            return View(list);
        }

        // GET: SessionsMVC/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: SessionsMVC/Create
        [HttpPost]
        public ActionResult Create(SessionView session)
        {
            if (ModelState.IsValid)
            {
                
                return RedirectToAction("Index");
            }
            else
                return View();
        }

        // GET: SessionsMVC/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SessionsMVC/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: SessionsMVC/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
