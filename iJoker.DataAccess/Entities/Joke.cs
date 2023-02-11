namespace iJoker.DataAccess.Entities
{
    public class Joke
    {
        public int JokeId { get; set; }

        public string? Text { get; set; }

        public string? Author { get; set; }

        public DateTime CreationTime { get; set; }
    }
}
