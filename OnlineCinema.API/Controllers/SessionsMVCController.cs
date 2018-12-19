using Newtonsoft.Json;
using OnlineCinema.BL.Model;
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
    [Authorize(Roles = "admin")]
    public class SessionsMVCController : Controller
    {
        private HttpClient client;
        private string APIpath = "http://localhost:53464/api";

        public SessionsMVCController()
        {
            client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        //Get All: SessionsMVC/Index
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            IEnumerable<SessionView> sessions = null;

            string json = await client.GetStringAsync($"{APIpath}/Sessions");

            sessions = JsonConvert.DeserializeObject<IEnumerable<SessionView>>(json);

            return View(sessions);
        }

        // GET: SessionsMVC/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: SessionsMVC/Create
        [HttpPost]
        public async Task<ActionResult> Create(SessionView session)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = await client.PostAsJsonAsync($"{APIpath}/Session", session);

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

        // GET: SessionsMVC/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
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
