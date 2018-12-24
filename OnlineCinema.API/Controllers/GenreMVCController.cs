using OnlineCinema.BL.Extensions;
using OnlineCinema.BL.Model;
using OnlineCinema.BL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineCinema.API.Controllers
{
    public class GenreMVCController : Controller
    {
        private readonly IGenreService _genreService = new GenreService();

        public ActionResult Index()
        {
            var genres = _genreService.GetAll().OrderBy(f => f.Name);
            return View(genres);
        }

        [HttpGet]
        public ActionResult Editor(int id)
        {
            if(id == 0)
            {
                return View("Edit", new GenreView());
            }
            else
            {
                var genre = _genreService.GetItem(id);

                if(genre != null)
                {
                    return View("Edit", genre);
                }
            }

            throw new ArgumentOutOfRangeException("Genre is not found.");
        }

        [HttpPost]
        public ActionResult Save(GenreView model)
        {
            if(!ModelState.IsValid)
                return View("Edit", model);

            if (model.Id == 0)
            {
                _genreService.Add(model);
            }
            else
            {
                _genreService.Update(model);
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