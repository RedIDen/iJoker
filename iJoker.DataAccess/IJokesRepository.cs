using iJoker.DataAccess.Entities;

namespace iJoker.DataAccess
{
    public interface IJokesRepository
    {
        public Joke GetJoke(int id);

        public IEnumerable<Joke> GetAllJokes();

        public int AddJoke(Joke joke);

        public bool UpdateJoke(Joke joke);

        public bool DeleteJoke(int id);
    }
}
