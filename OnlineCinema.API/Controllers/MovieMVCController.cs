using OnlineCinema.BL.Model;
using OnlineCinema.BL.Services;
using OnlineCinema.BL.Exceptions;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;

namespace OnlineCinema.API.Controllers
{
    public class MovieMVCController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IGenreService _genreService;


        public MovieMVCController(IMovieService movieService, IGenreService genreService)
        {
            _movieService = movieService;
            _genreService = genreService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var movies = _movieService.GetAllForAdmin();
            return View(movies);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View("Edit", new MovieAdminView());
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View("Edit", _movieService.GetItemForAdmin(id));
        }

        [HttpPost]
        public ActionResult Save(MovieAdminView model, HttpPostedFileBase uploadedImage)
        {
            if (!ModelState.IsValid)
                return View("Edit", model);

            try
            {
                if (model.Id == 0)
                {
                    _movieService.Add(model, uploadedImage);
                }
                else
                {
                    _movieService.Update(model, uploadedImage);
                }
            }
            catch(ImageNotFoundException)
            {
                ModelState.AddModelError("Image", "Required field.");
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