using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using FastTypingApi.Entities;

namespace FastTypingApi
{
    public class FastTypingSeeder
    {
        private readonly TextDbContext _dbContext;
        public FastTypingSeeder(TextDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Texts.Any())
                {
                    var texts = GetTexts();
                    _dbContext.Texts.AddRange(texts);
                    //zapisz zmiany
                    _dbContext.SaveChanges();
                }
            }

        }
        private IEnumerable<Text> GetTexts()
        {
            //Dodaj pacjenta
            var texts = new List<Text>()
            {
                new Text
                {
                    language = "Polski",
                    text = "Król Karol kupił królowej Karolinie korale koloru koralowego",
                    lenght = "short",
                    Score = new List<Score>()
                    {
                        new Score()
                        {
                            Name = "Tomasz",
                            Mistakes= 4,
                            Time = 100
                        },
                    },
            }
        };
            return texts;
        }
    }
}

