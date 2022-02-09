namespace FastTypingApi.Entities
{
    public class Score
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Mistakes { get; set; }
        public int Time { get; set; }
        public int TextId { get; set; } 
        public virtual Text Text { get; set; }
    }
}
