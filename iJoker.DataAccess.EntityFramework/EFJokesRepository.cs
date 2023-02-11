using iJoker.DataAccess.Entities;

namespace iJoker.DataAccess.EntityFramework
{
    public class EFJokesRepository : IJokesRepository
    {
        private readonly JokesDbContext _dbContext;

        public EFJokesRepository(JokesDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public int AddJoke(Joke joke)
        {
            throw new NotImplementedException();
        }

        public bool DeleteJoke(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Joke> GetAllJokes()
        {
            return this._dbContext.Jokes.ToList();
        }

        public Joke GetJoke(int id)
        {
            return this._dbContext.Jokes.FirstOrDefault(x => x.JokeId == id) ?? throw new ArgumentException("Wrong joke id.");
        }

        public bool UpdateJoke(Joke joke)
        {
            throw new NotImplementedException();
        }
    }
}