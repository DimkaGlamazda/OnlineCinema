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
    [Authorize]
    public class MovieMockController : ApiController
    {
        [Inject]
        private readonly IMovieService _movieService;

        public MovieMockController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var _moviesList = _movieService.GetAll().Select(b => b.ToViewModel()).OrderBy(f => f.Name);

            return Ok(_moviesList);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var movie = _movieService.GetItem(id).ToViewModel();

            return Ok(movie);
        }

        [HttpPost]
        public IHttpActionResult Add([FromBody]MovieView movie)
        {
            return BadRequest("Invalid endpoint");
        }

        [HttpPut]
        public IHttpActionResult Update([FromBody] MovieView model)
        {
            return BadRequest("Invalid endpoint");
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            return BadRequest("Invalid endpoint");
        }
    }
}
