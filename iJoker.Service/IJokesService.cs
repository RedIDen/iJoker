using iJoker.Service.DomainModels;

namespace iJoker.Service
{
    public interface IJokesService
    {
        public JokeModel GetJoke(int id);

        public IEnumerable<JokeModel> GetAllJokes();

        public int AddJoke(JokeModel joke);

        public bool UpdateJoke(JokeModel joke);

        public bool DeleteJoke(int id);
    }
}