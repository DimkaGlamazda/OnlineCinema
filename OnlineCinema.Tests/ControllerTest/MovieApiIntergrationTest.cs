using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineCinema.BL.Model;
using OnlineCinema.DB.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCinema.Tests.ControllerTest
{
    [TestClass]
    public class MovieApiIntergrationTest
    {
        private HttpClient _httpClient;
        private OnlineCinemaDataModel _ctx;

        [TestInitialize]
        public void Initializer()
        {
            _ctx = new OnlineCinemaDataModel();
            _httpClient = new HttpClient();

            _httpClient.BaseAddress = new Uri("http://localhost:53464/api/");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        [TestCleanup]
        public void Destroyer() { }

        [TestMethod]
        public async Task Test_GetAllMovies()
        {
            // Assign
            var movieCount = _ctx.Movie.Count(c => !c.IsDeleted.HasValue || !c.IsDeleted.Value);

            // Action
            var result = await _httpClient.GetAsync("movie");
            var list = await result.Content.ReadAsAsync<List<Movie>>();

            // Assert
            Assert.AreEqual(movieCount, list.Count);
        }

        [TestMethod]
        public async Task Test_GetMovie()
        {
            // Assign
            var movie = _ctx.Movie.FirstOrDefault(c => !c.IsDeleted.HasValue || !c.IsDeleted.Value);

            // Action
            var result = await _httpClient.GetAsync($"movie/{movie.Id}");

            // Assert
            Assert.AreEqual(System.Net.HttpStatusCode.OK, result.StatusCode);
        }

        [TestMethod]
        public async Task Test_GetParticularMovie()
        {
            // Assign
            var movie = _ctx.Movie.FirstOrDefault(c => !c.IsDeleted.HasValue || !c.IsDeleted.Value);
            
            // Action
            var result = await _httpClient.GetAsync($"movie/{movie.Id}");
            var movieFromHttp = await result.Content.ReadAsAsync<Movie>();

            // Assert
            Assert.AreEqual(movie.Id, movieFromHttp.Id);
            Assert.AreEqual(movie.Name, movieFromHttp.Name);
            Assert.AreEqual(movie.GenreId, movieFromHttp.GenreId);
            Assert.AreEqual(movie.VideoLink, movieFromHttp.VideoLink);
            Assert.AreEqual(movie.Image, movieFromHttp.Image);
        }
    }
}
