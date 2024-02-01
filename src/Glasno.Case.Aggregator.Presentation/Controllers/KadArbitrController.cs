using Glasno.Case.Aggregator.Application;
using Glasno.Case.Aggregator.Application.Queries.SearchCases;
using Glasno.Case.Aggregator.Application.Queries.SearchCases.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Glasno.Case.Aggregator.Presentation.Controllers;

[ApiController]
[Route(nameof(KadArbitrController))]
public class KadArbitrController : Controller
{
    private readonly IMediator _mediator;

    public KadArbitrController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost (nameof(SearchCases))]
    public Task<SearchCasesResponse> SearchCases(SearchCasesQuery query)
    {
        return _mediator.Send(query);
    }
}