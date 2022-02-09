using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastTypingApi.Models;
using FastTypingApi.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace FastTypingApi.Services
{
    public interface IScoresService
    {
        int Create(int textId, CreateScoreDto dto);
        ScoreDto GetById(int textId, int newScoreId);
        List<ScoreDto> GetAll(int textId);
        void RemoveAll(int textId);
    }
    public class ScoreService : IScoresService
    {
        private readonly TextDbContext _context;
        private readonly IMapper _mapper;
        public ScoreService(TextDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public int Create(int textId, CreateScoreDto dto)
        {
            var patient = GetTextById(textId);

            var scoreEntity = _mapper.Map<Score>(dto);
            scoreEntity.TextId = textId;

            _context.Scores.Add(scoreEntity);
            _context.SaveChanges();

            return scoreEntity.Id;
        }
        public ScoreDto GetById(int textId, int newScoresId)
        {
            var text = GetTextById(textId);

            var scores = _context.Scores.FirstOrDefault(d => d.Id == newScoresId);
            if (scores is null || scores.TextId != textId)
            {
                throw new DllNotFoundException("Nie ");
            }

            var scoresDto = _mapper.Map<ScoreDto>(scores);
            return scoresDto;
        }
        public List<ScoreDto> GetAll(int textId)
        {
            //var text = GetTextById(textId);
            var texts = _context
                 .Scores
                 .Where(r => r.TextId==textId)
                 .OrderBy(r => r.Time)
                 .OrderBy(r => r.Mistakes);
            var scoresDtos = _mapper.Map<List<ScoreDto>>(texts);
            return scoresDtos;
        }
        public void RemoveAll(int textId)
        {
            var text = GetTextById(textId);

            _context.RemoveRange(text.Score);
            _context.SaveChanges();

        }
        private Text GetTextById(int textId)
        {
            var text = _context
                .Texts
                .Include(r => r.Score)
                .FirstOrDefault(r => r.Id == textId);
            if (text is null)
                throw new DllNotFoundException("Nie znaleziono tekstu");
            return text;
        }
    }
}
