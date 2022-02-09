using System.Collections.Generic;

namespace FastTypingApi.Entities
{
    public class Text
    {
        public int Id { get; set; }
        public string language { get; set; }
        public string text { get; set; }
        public string lenght { get; set; }
        public virtual List<Score> Score { get; set; }
    }
}
