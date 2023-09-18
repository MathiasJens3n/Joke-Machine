using Joke_Machine.Models;

namespace Joke_Machine.Interfaces
{
    public interface IJokeRepository
    {
        public List<Joke> JokeList { get; }

        public List<string> GetCategories();

        public Joke GetJoke();

        public Joke GetJoke(string lang);

        public Joke GetJoke(string lang, string category);

        public void DeleteJoke(Joke joke);
    }
}