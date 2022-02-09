using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FastTypingApi.Entities;
using FastTypingApi.Models;
namespace FastTypingApi
{
    public class FastTypingMappingProfile: Profile
    {
        public FastTypingMappingProfile()
        {
            CreateMap<Text, TextDto>();
            CreateMap<Score, ScoreDto>();
            CreateMap<CreateTextDto, Text>();
            CreateMap<CreateScoreDto, Score>();
            CreateMap<ScoreDto, Score>();
        }
    }
}
