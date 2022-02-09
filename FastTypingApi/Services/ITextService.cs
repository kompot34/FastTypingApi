using FastTypingApi.Models;
using System.Collections.Generic;

namespace FastTypingApi.Services
{
    public interface ITextService
    {
        int Create(CreateTextDto dto);
        IEnumerable<TextDto> GetAll(string searchPhrase, string lenght);
        TextDto GetById(int id);
        bool Delete(int id);
    }
}
