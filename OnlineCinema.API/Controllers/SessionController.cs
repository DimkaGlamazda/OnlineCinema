using OnlineCinema.BL.Model;
using OnlineCinema.BL.Services;
using OnlineCinema.BL.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Ninject;

namespace OnlineCinema.API.Controllers
{
    //[Authorize(Roles = "admin")]
    public class SessionController : ApiController
    {
        private readonly ISessionService _sessionService;

        public SessionController(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var _sessionList = _sessionService.GetAll().Select(b => b.ToViewModel()).OrderBy(f => f.Title).ToList();
            return Ok(_sessionList);
        }

        [HttpGet]
        public IHttpActionResult Get(int? id)
        {
            if (!id.HasValue)
                return BadRequest();

            if (id <= 0)
                return BadRequest();

            if (_sessionService.GetAll().FirstOrDefault(k => k.Id == id) == null)
                return BadRequest();

            var session = _sessionService.GetItem(id.Value).ToViewModel();
            return Ok(session);
        }

        [HttpPost]
        public IHttpActionResult Add([FromBody]SessionView session)
        {
            if (ModelState.IsValid)
            {
                int sessionId = _sessionService.Add(session.ToDtoModel());
                return Ok(sessionId);
            }
            return BadRequest("You've entered invalid values!");
        }

        [HttpPut]
        public IHttpActionResult Update([FromBody]SessionView session)
        {
            if (ModelState.IsValid)
            {
                _sessionService.Update(session.ToDtoModel());
                return Ok();
            }
            return BadRequest("You've entered invalid values!");
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            _sessionService.Delete(id);

            return Ok();
        }
    }
}