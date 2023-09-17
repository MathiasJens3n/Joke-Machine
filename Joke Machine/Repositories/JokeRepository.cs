using Joke_Machine.Interfaces;
using Joke_Machine.Models;

namespace Joke_Machine.Repositories
{
    public class JokeRepository : IJokeRepository
    {
        public List<Joke> JokeList { get; set; }

        public JokeRepository()
        {
            JokeList = new List<Joke>()
            {
                new Joke() { Id = 1, Text = "Hvad ligner en neger hvis man stikker 12 advarselstrekanter op i røven på ham? \r\n– En Toblerone", Category = Categories.racist.ToString(), Language = Languages.dk.ToString() },
                new Joke() { Id = 2, Text = "What does a negro look like if you stick 12 warning triangles up his ass? \\A Toblerone", Category = Categories.racist.ToString(), Language = Languages.en.ToString() },
                new Joke() { Id = 3, Text = "Hvad er mågers ynglings tv program?\r\n– Go’ mågen Danmark", Category = Categories.seagull.ToString(), Language = Languages.dk.ToString() },
                new Joke() { Id = 4, Text = "What is the seagulls' favorite TV show?\r\n- Go' mågen Danmark", Category = Categories.seagull.ToString(), Language = Languages.en.ToString() },
                new Joke() { Id = 5, Text = "Hvorfor skulle skyen i skole?\r\n– Fordi den skulle lære at regne", Category = Categories.dad.ToString(), Language = Languages.dk.ToString() },
                new Joke() { Id = 6, Text = "Why should the cloud go to school?\n- Because it needed to learn arithmetic", Category = Categories.dad.ToString(), Language = Languages.en.ToString() },
                new Joke() { Id = 7, Text = "Hvorfor er det at fisk er så grimme?\r\n– Det er jo selvfølgelig fordi at de er van(d)skabte", Category = Categories.dad.ToString(), Language = Languages.dk.ToString() },
                new Joke() { Id = 8, Text = "Why are fish so ugly?\n- Of course, it's because they are mis(d)created", Category = Categories.dad.ToString(), Language = Languages.en.ToString() },
                new Joke() { Id = 9, Text = "Hvor sover mågerne når de er på tur?\r\n– På Mågtel", Category = Categories.seagull.ToString(), Language = Languages.dk.ToString() },
                new Joke() { Id = 10, Text = "Where do seagulls sleep when they travel?\n- On Seagull Island", Category = Categories.seagull.ToString(), Language = Languages.en.ToString() },
            };
        }

        public List<string> GetCategories()
        {
            return JokeList.Select(x => x.Category).Distinct().ToList();
        }

        public Joke GetJoke(int id)
        {
            return JokeList.Where(x => x.Id == id).FirstOrDefault();
        }

        public void DeleteJoke(Joke joke)
        {
            JokeList.Remove(joke);
        }
    }
}