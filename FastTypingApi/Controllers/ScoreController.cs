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
    [Route("api/text/{textId}/score")]
    [ApiController]
    public class ScoreController : ControllerBase
    {
        private readonly IScoresService _scoreService;
        public ScoreController(IScoresService scoreService)
        {
            _scoreService = scoreService;
        }

        [HttpPost]
        public ActionResult Post([FromRoute] int textId, [FromBody] CreateScoreDto dto)
        {
            var newScoreId = _scoreService.Create(textId, dto);

            return Created($"api/text/{textId}/score/{newScoreId}", null);
        }
        [HttpGet("{newScoreId}")]
        public ActionResult<ScoreDto> Get([FromRoute] int textId, [FromRoute] int newScoreId)
        {
            var scores = _scoreService.GetById(textId, newScoreId);
            return Ok(scores);
        }
        [HttpGet]
        public ActionResult<List<ScoreDto>> Get([FromRoute] int textId)
        {
            var result = _scoreService.GetAll(textId);
            return Ok(result);
        }
        [HttpDelete]
        public ActionResult Delete([FromRoute] int textId)
        {
            _scoreService.RemoveAll(textId);

            return NoContent();
        }
    }
}

