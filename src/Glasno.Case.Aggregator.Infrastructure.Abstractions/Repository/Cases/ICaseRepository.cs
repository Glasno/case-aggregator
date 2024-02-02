using Glasno.Case.Aggregator.Infrastructure.Abstractions.Repository.Cases.Contracts;

namespace Glasno.Case.Aggregator.Infrastructure.Abstractions.Repository.Cases;

public interface ICaseRepository
{
    Task<Domain.Cases.Case?> GetById(Guid id, CancellationToken cancellationToken);
    
    Task<IEnumerable<Domain.Cases.Case>> Search(SearchQuery query, CancellationToken cancellationToken);

    Task Add(Domain.Cases.Case entity, CancellationToken cancellationToken);
    
    Task Add(Domain.Cases.Case[] entities, CancellationToken cancellationToken);
    
    Task Update(Domain.Cases.Case entity, CancellationToken cancellationToken);
}