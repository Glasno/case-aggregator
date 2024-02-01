using AutoMapper;
using Glasno.Case.Aggregator.Application.Contracts;
using Glasno.Case.Aggregator.Application.Contracts.ValueObjects;
using Glasno.Case.Aggregator.ExternalServices.KadArbitr.Contracts.ValueObjects;

namespace Glasno.Case.Aggregator.Application.Mappers;

internal class InternalMappingProfile : Profile
{
    public InternalMappingProfile()
    {			
        CreateMap<CaseExternal, CaseInternal>()
            .ReverseMap();

        CreateMap<CaseTypeExternal, CaseTypeInternal>()
            .ReverseMap();
        
        CreateMap<PlaintiffExternal, PlaintiffInternal>()
            .ReverseMap();
        CreateMap<RespondentExternal, RespondentInternal>()
            .ReverseMap();
    }
}