using iJoker.DataAccess;
using iJoker.Service.DomainModels;

namespace iJoker.Service.Default
{
    public class JokesDefautService : IJokesService
    {
        private readonly IJokesRepository _repository;
        public JokesDefautService(IJokesRepository repository)
        {
            this._repository = repository;
        }

        public int AddJoke(JokeModel joke)
        {
            throw new NotImplementedException();
        }

        public bool DeleteJoke(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<JokeModel> GetAllJokes()
        {
            return this._repository.GetAllJokes().Select(x => new JokeModel()
            {
                JokeId = x.JokeId,
                Author = x.Author,
                Text = x.Text,
                CreationTime = $"{GetDateString(x.CreationTime)} в {x.CreationTime.ToShortTimeString()}",
                Likes = new Random().Next(50),
            });
        }

        public JokeModel GetJoke(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateJoke(JokeModel joke)
        {
            throw new NotImplementedException();
        }

        private static string GetDateString(DateTime date)
        {
            DateTime now = DateTime.Now;

            return date switch
            {
                _ when date.Year != now.Year => date.ToString("dd MMM yyyy"),
                _ when date.Month != now.Month => date.ToString("dd MMM"),
                _ when date.Day == now.Day => "Сегодня",
                _ when date.Day == now.Day - 1 => "Вчера",
                _ => date.ToString("dd MMM"),
            };
        }
    }
}