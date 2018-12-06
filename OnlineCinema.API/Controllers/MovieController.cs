using OnlineCinema.BL.Model;
using OnlineCinema.BL.Services;
using OnlineCinema.BL.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OnlineCinema.API.Controllers
{
    [Authorize]
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
            var _moviesList = _movieService.GetAll().Select(b => b.ToViewModel());

            return Ok(_moviesList);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var movie = _movieService.Get(id).ToViewModel();

            return Ok(movie);
        }

        [HttpPost]
        public IHttpActionResult Add([FromBody]MovieView movie)
        {
            int clientId = _movieService.Add(movie.ToDtoModel());

            return Ok(clientId);
        }

        [HttpPut]
        public IHttpActionResult Update([FromBody] MovieView model)
        {
            _movieService.Update(model.ToDTOModel());

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            _movieService.Delete(id);

            return Ok();
        }
    }
}
