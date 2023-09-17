using Joke_Machine.Models;

namespace Joke_Machine.Interfaces
{
    public interface IJokeRepository
    {
        public List<Joke> JokeList { get; set; }
        public List<string> GetCategories();
        public Joke GetJoke(int id);
        public void DeleteJoke(Joke joke);

    }
}
