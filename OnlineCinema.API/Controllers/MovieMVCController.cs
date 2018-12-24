using OnlineCinema.BL.Extensions;
using OnlineCinema.BL.Model;
using OnlineCinema.BL.Services;
using OnlineCinema.DB.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineCinema.API.Controllers
{
    public class MovieMVCController : Controller
    {
        private readonly IMovieService _movieService  = new MovieService();
        private readonly IGenreService _genreService  = new GenreService();

        [HttpGet]
        public ActionResult Index()
        {
            var movies = _movieService.GetAll().OrderBy(f => f.Name); ;
            return View(movies);
        }

        [HttpGet]
        public ActionResult Create()
        {

            ViewBag.GenreList = _genreService.GetAll();
            return View("Edit", new MovieView());
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = _movieService.GetItem(id);
            ViewBag.GenreList = _genreService.GetAll();
            return View("Edit", model);
        }

        [HttpPost]
        public ActionResult Save(MovieView model, HttpPostedFileBase uploadedImage)
        {
            ViewBag.GenreList = _genreService.GetAll();

            var movie = model;

            if (model.Id != 0)
            {
                movie = _movieService.GetItem(model.Id);
            }


            if (uploadedImage == null && movie.Image == null)
            {
                ModelState.AddModelError("Image", "Required field.");
                return View("Edit", model);
            }
            

            if (uploadedImage != null)
            {
                model.Image = new byte[uploadedImage.ContentLength];
                uploadedImage.InputStream.Read(model.Image, 0, uploadedImage.ContentLength);
            }

            if (!ModelState.IsValid)
                return View("Edit", model);

            if (model.Id == 0)
            {
                _movieService.Add(model);
            }
            else
            {
                _movieService.Update(model);
            }


            return View("Edit", model);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                _movieService.Delete(id);
                ViewBag.SuccessMessage = "Item has been deleted";
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
            }

            var genres = _movieService.GetAll().OrderBy(f => f.Name);
            return View("Index", genres);
        }
    }
}