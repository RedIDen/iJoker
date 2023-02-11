namespace iJoker.Service.DomainModels
{
    public class JokeModel
    {
        public int JokeId { get; set; }

        public string? Text { get; set; }

        public string? Author { get; set; }

        public string? CreationTime { get; set; }

        public int Likes { get; set; }
    }
}
