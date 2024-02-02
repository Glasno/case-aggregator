using AutoMapper;
using Glasno.Case.Aggregator.Application.Contracts;
using Glasno.Case.Aggregator.Application.Contracts.ValueObjects;
using Glasno.Case.Aggregator.Domain.Cases.ValueObjects;
using Glasno.Case.Aggregator.ExternalServices.KadArbitr.Contracts.ValueObjects;

namespace Glasno.Case.Aggregator.Application.Mappers;

internal class InternalMappingProfile : Profile
{
    public InternalMappingProfile()
    {
        CreateExternalMapping();

        CreateDomainMapping();
    }

    private void CreateDomainMapping()
    {
        CreateMap<CaseInternal, Domain.Cases.Case>()
            .ReverseMap();

        CreateMap<CaseTypeInternal, CaseType>()
            .ReverseMap();
        
        CreateMap<PlaintiffInternal, Plaintiff>()
            .ReverseMap();
        CreateMap<RespondentInternal, Respondent>()
            .ReverseMap();
    }

    private void CreateExternalMapping()
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