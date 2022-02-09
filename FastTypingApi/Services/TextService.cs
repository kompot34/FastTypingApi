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
    public class TextService: ITextService
    {
        private readonly TextDbContext _dbContext;
        private readonly IMapper _mapper;

        public TextService(TextDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public TextDto GetById(int id)
        {
            var texts = _dbContext
                .Texts
                .Include(t => t.Score)
                .FirstOrDefault(r => r.Id == id);
            if (texts is null) return null;
            var result = _mapper.Map<TextDto>(texts);
            return result;
        }
        public IEnumerable<TextDto> GetAll(string language, string lenght)
        {
            var texts = _dbContext
               .Texts
               .Where(r => language == null || (r.language.ToLower().Contains(language)))
               .Where(r => lenght == null || (r.lenght.ToLower().Contains(lenght)))
               .Include(r => r.Score)
               .ToList();

            var textsDtos = _mapper.Map<List<TextDto>>(texts);
            return textsDtos;
        }
        public int Create(CreateTextDto dto)
        {
            var texts = _mapper.Map<Text>(dto);
            _dbContext.Texts.Add(texts);
            _dbContext.SaveChanges();
            return texts.Id;
        }
        public bool Delete(int id)
        {
            var texts = _dbContext
               .Texts
               .FirstOrDefault(r => r.Id == id);

            if (texts is null) return false;

            _dbContext.Texts.Remove(texts);
            _dbContext.SaveChanges();

            return true;

        }
    }
}
