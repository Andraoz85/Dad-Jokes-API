namespace DadJokes.Models
{
    public class RootModel
    {
        public string? Id { get; set; }
        public string? Joke { get; set; }
        public int? Status { get; set; }
        public DateTime FetchedAt { get; set; } = DateTime.Now;
    }
}
