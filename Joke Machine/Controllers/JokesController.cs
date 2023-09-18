using Joke_Machine.Interfaces;
using Joke_Machine.Models;
using Joke_Machine.Services;
using Microsoft.AspNetCore.Mvc;

namespace Joke_Machine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JokesController : ControllerBase
    {
        private readonly ISession session;
        private readonly string _category;
        private readonly IJokeRepository _jokeRepository;
        private string _language;

        public JokesController(IJokeRepository jokeRepository, IHttpContextAccessor httpContextAccessor)
        {
            session = httpContextAccessor.HttpContext.Session;

            _jokeRepository = jokeRepository;

            _category = session.GetString("category");
        }

        [HttpGet("categories")]
        public IActionResult GetCategories()
        {
            var categories = _jokeRepository.GetCategories();
            return Ok(categories);
        }

        [HttpPost]
        public IActionResult SetCategory(string category)
        {
            if (string.IsNullOrEmpty(category))
            {
                return BadRequest("Please enter a category");
            }

            session.SetString("category", category);

            return Ok($"Category has been set to '{category}'");
        }

        [HttpGet("random")]
        public IActionResult GetJoke()
        {
            _language = Request.Headers["lang"];

            Joke joke;

            if(_category == "racist")
            {
                return BadRequest("Please use other endpoint");
            }

            if (_category == null)
            {
                return BadRequest("Please set a category");
            }

            // Gets a joke in any language
            if (string.IsNullOrEmpty(_language))
            {
                joke = _jokeRepository.GetJoke(_category);
            }

            // Gets a joke with the language from the request header (dk,en)
            else
            {
                joke = _jokeRepository.GetJoke(_language, _category);
            }

            // Deletes the used joke
            _jokeRepository.DeleteJoke(joke);

            if (joke != null)
            {
                return Ok(joke.Text);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet("racistjokes")]
        [ApiKeyAuthorization]
        public IActionResult GetRacistJoke()
        {
            _language = Request.Headers["lang"];

            Joke joke;

            if (_category != "racist")
            {
                return BadRequest("this endpoint is for racist jokes");
            }

            // Gets a joke in any language
            if (string.IsNullOrEmpty(_language))
            {
                joke = _jokeRepository.GetJoke(_category);
            }

            // Gets a joke with the language from the request header (dk,en)
            else
            {
                joke = _jokeRepository.GetJoke(_language, _category);
            }

            // Deletes the used joke
            _jokeRepository.DeleteJoke(joke);

            if (joke != null)
            {
                return Ok(joke.Text);
            }
            else
            {
                return NoContent();
            }
        }

    }
}