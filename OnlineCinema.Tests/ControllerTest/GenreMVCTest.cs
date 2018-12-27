using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineCinema.API.Controllers;
using OnlineCinema.BL.Model;
using OnlineCinema.BL.Services;
using OnlineCinema.DB.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OnlineCinema.Tests.ControllerTest
{
    [TestClass]
    public class GenreMVCTest
    {
        private IGenreService _genreService;
        private GenreMVCController _genreMVC;

        [TestInitialize]
        public void Initializer()
        {
            _genreService = new GenreService();
            _genreMVC = new GenreMVCController(_genreService);
        }

        [TestMethod]
        public void Test_GenreIndex()
        {
            var genresSer = _genreService.GetAll();
            var result = _genreMVC.Index() as ViewResult;
            var genresMVC = (List<GenreView>)result.ViewData.Model;

            Assert.AreEqual(genresSer, genresMVC);
        }

        [TestMethod]
        public void Test_Genre()
        {
            var genresSer = _genreService.GetAll();
            var result = _genreMVC.Index() as ViewResult;
            var genresMVC = (List<GenreView>)result.ViewData.Model;

            Assert.AreEqual(genresSer, genresMVC);
        }
    }
}
