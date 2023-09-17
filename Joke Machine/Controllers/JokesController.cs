using Joke_Machine.Extensions;
using Joke_Machine.Interfaces;
using Joke_Machine.Models;
using Joke_Machine.Repositories;
using Joke_Machine.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Joke_Machine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JokesController : ControllerBase
    {
        private readonly ISession session;
        private List<Joke> _usedJokes;
        private readonly IJokeRepository _jokeRepository;
        public JokesController(IJokeRepository jokeRepository, IHttpContextAccessor httpContextAccessor)
        {
            session = httpContextAccessor.HttpContext.Session;

            _jokeRepository = jokeRepository;
            
            _usedJokes = SessionExtension.GetObjectAsJson<List<Joke>>(session, "ShoppingCart") ?? new List<Joke>();
        }
        [HttpGet("categories")]
        public IActionResult GetCategories()
        {
            var categories = _jokeRepository.GetCategories();
            return Ok(categories);
        }
        [HttpGet]
        public IActionResult GetJoke()
        {
            Random rnd = new Random();

            var joke = _jokeRepository.GetJoke(rnd.Next(1, _jokeRepository.JokeList.Count));

            _usedJokes.Add(joke);
            _jokeRepository.DeleteJoke(joke);

            return Ok(joke.Text);
        }

        [HttpGet("key")]
        public IActionResult GetApiKey()
        {
            var key = ApiKeyService.GenerateApiKey();
            return Ok(key);
        }
    }
}
