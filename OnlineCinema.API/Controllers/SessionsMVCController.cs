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
    public class SessionsMVCController : Controller
    {
        private readonly ISessionService _sessionService;

        public SessionsMVCController()
        {
            _sessionService = new SessionService();
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
                _sessionService.Add(session.ToDtoModel());

                return RedirectToAction("Index");
            }
            else
                return View();
        }

        // GET: SessionsMVC/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var session = _sessionService.GetItem(id);

            return View(session.ToViewModel());
        }

        // POST: SessionsMVC/Edit/5
        [HttpPost]
        public ActionResult Edit(SessionView session)
        {
            if (ModelState.IsValid)
            {
                _sessionService.Update(session.ToDtoModel());

                return RedirectToAction("Index");
            }
            else
            {
                return View(session);
            }
        }

        // POST: SessionsMVC/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            _sessionService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
