namespace FastTypingApi.Models
{
    public class CreateScoreDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Mistakes { get; set; }
        public int Time { get; set; }
        public int TextId { get; set; }
    }
}
