using OnlineCinema.BL.Extensions;
using OnlineCinema.BL.Model;
using OnlineCinema.BL.Services;
using System;
using System.Linq;
using System.Web.Mvc;

namespace OnlineCinema.API.Controllers
{
    public class GenreMVCController : Controller
    {
        private readonly IGenreService _genreService;

        public GenreMVCController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        public ActionResult Index()
        {
            var genres = _genreService.GetAll();
            return View(genres);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if(id == 0)
                return View(new GenreView());


            var genre = _genreService.GetItem(id);

            if (genre == null)
            {
                ViewBag.ErrorMessage = "Item not found";
                return View(new GenreView());
            }

            return View(genre);      
        }

        [HttpPost]
        public ActionResult Save(GenreView model)
        {
            if(!ModelState.IsValid)
                return View("Edit", model);

            try
            {
                if (model.Id == 0)
                {
                    _genreService.Add(model);
                }
                else
                {
                    _genreService.Update(model);
                }
            }
            catch(ItemAlreadyExistException)
            {
                ModelState.AddModelError("Name", "Item with this value already exists.");
            }

            return View("Edit", model);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                _genreService.Delete(id);
                ViewBag.SuccessMessage = "Item has been deleted";
            }
            catch(Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
            }

            var genres = _genreService.GetAll().OrderBy(f => f.Name);
            return View("Index", genres);
        }
    }
}