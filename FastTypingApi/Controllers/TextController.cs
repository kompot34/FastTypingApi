using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastTypingApi.Entities;
using AutoMapper;
using FastTypingApi.Models;
using Microsoft.EntityFrameworkCore;
using FastTypingApi.Services;

namespace FastTypingApi.Controllers
{
    [Route("api/text")]

    public class TextController : ControllerBase
    {
        private readonly ITextService _textService;

        public TextController(ITextService textService)
        {
            _textService = textService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<TextDto>> GetAll([FromQuery] string language, string lenght)
        {
            var textdtos = _textService.GetAll(language, lenght);
            return Ok(textdtos);
        }
        [HttpPost]
        public ActionResult CreateText([FromBody] CreateTextDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var id = _textService.Create(dto);

            return Created($"/api/text/{id}", null);
        }
        [HttpGet("{id}")]
        public ActionResult<Text> Get([FromRoute] int id)
        {
            var text = _textService.GetById(id);

            if (text is null)
            {
                return NotFound();
            }
            return Ok(text);
        }
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            var isDeleted = _textService.Delete(id);

            if (isDeleted)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
