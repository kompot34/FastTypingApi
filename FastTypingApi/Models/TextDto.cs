using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastTypingApi.Models
{
    public class TextDto
    {
        public int Id { get; set; }
        public string language { get; set; }
        public string text { get; set; }
        public string lenght { get; set; }
        public virtual List<ScoreDto> Score { get; set; }
    }
}
