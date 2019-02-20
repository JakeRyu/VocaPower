using System.Reflection;
using AutoMapper;
using VocaPower.Domain.Entities;
using VocaPower.Infrastructure.OxfordDictionaryApi;

namespace VocaPower.Infrastructure.Infrastructure
{
    public class InfrastructureProfile : Profile
    {
        public InfrastructureProfile()
        {
            CreateMap<Result, WordEntry>();
            CreateMap<Result.LexicalEntry, LexicalEntry>();
        }
    }
}