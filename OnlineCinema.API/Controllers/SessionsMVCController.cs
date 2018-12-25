using OnlineCinema.BL.Model;
using OnlineCinema.BL.Services;
using System.Web.Mvc;
using Ninject;

namespace OnlineCinema.API.Controllers
{
    public class SessionsMVCController : Controller
    {
        private readonly ISessionService _sessionService;

        public SessionsMVCController(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var list = _sessionService.GetAll();

            return View(list);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(SessionView session)
        {
            if (ModelState.IsValid)
            {
                _sessionService.Add(session);

                return RedirectToAction("Index");
            }
            else
                return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var session = _sessionService.GetItem(id);

            return View(session);
        }


        [HttpPost]
        public ActionResult Edit(SessionView session)
        {
            if (ModelState.IsValid)
            {
                _sessionService.Update(session);

                return RedirectToAction("Index");
            }
            else
            {
                return View(session);
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            _sessionService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}