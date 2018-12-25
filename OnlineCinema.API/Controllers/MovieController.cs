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
    public class MovieController : ApiController
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var _moviesList = _movieService.GetAll().OrderBy(f => f.Name);
            return Ok(_moviesList);
        }

        [HttpGet]
        public IHttpActionResult Get(int? id)
        {
            if (!id.HasValue)
                return BadRequest();

            if (id <= 0)
                return BadRequest();

            if (_movieService.GetAll().FirstOrDefault(k => k.Id == id) == null)
                return BadRequest();

            var movie = _movieService.GetItem(id.Value);
            return Ok(movie);
        }


        [Authorize(Roles = "admin")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            _movieService.Delete(id);

            return Ok();
        }
    }
}