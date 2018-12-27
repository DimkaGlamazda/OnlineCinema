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
            var _moviesList = _movieService.GetAllMock().OrderBy(f => f.name);

            if (_moviesList == null)
                return NotFound();

            return Ok(_moviesList);
        }

        [HttpGet]
        public IHttpActionResult Get(int? id)
        {
            if (!id.HasValue)
                return BadRequest("Check you parametr");

            if (id <= 0)
                return BadRequest("Parameter cannot be less than or equal to zero");

            if (_movieService.GetAllMock().FirstOrDefault(k => k.id == id) == null)
                return NotFound();

            var movie = _movieService.GetItemMock(id.Value);
            return Ok(movie);
        }

        [Authorize(Roles = "admin")]
        [HttpDelete]
        public IHttpActionResult Delete(int? id)
        {
            if (!id.HasValue)
                return BadRequest("Check you parametr");

            if (id <= 0)
                return BadRequest("Parameter cannot be less than or equal to zero");

            if (_movieService.GetAllMock().FirstOrDefault(k => k.id == id) == null)
                return NotFound();

            _movieService.Delete(id.Value);

            return Ok();
        }
    }
}