using Dapper;
using Glasno.Case.Aggregator.Infrastructure.Abstractions.Repository.Cases;
using Glasno.Case.Aggregator.Infrastructure.Abstractions.Repository.Cases.Contracts;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Glasno.Case.Aggregator.Infrastructure.Repository.Cases;

internal  class CaseRepository : ICaseRepository
{
    private readonly NpgsqlConnection _connection;

    public CaseRepository(IConfiguration configuration)
    {
        _connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection"));
        _connection.Open();
    }

    public async Task<Domain.Cases.Case?> GetById(Guid id, CancellationToken cancellationToken)
    {
        var query = CaseQueries.GetByIdQuery(id, cancellationToken);
        var cases = await _connection.QueryAsync<Domain.Cases.Case>(query);

        return cases.SingleOrDefault();
    }

    public async Task<IEnumerable<Domain.Cases.Case>> Search(SearchQuery query, CancellationToken cancellationToken)
    {
        var command = CaseQueries.Search(query, cancellationToken);
        var cases = await _connection.QueryAsync<Domain.Cases.Case>(command);

        return cases;
    }

    public async Task Add(Domain.Cases.Case entity, CancellationToken cancellationToken)
    {
        var query = CaseQueries.Add(entity, cancellationToken);
        await _connection.ExecuteAsync(query);
    }

    public Task Add(Domain.Cases.Case[] entities, CancellationToken cancellationToken)
    {
        var tasks = entities.Select(entity => Add(entity, cancellationToken));
        return Task.WhenAll(tasks);
    }

    public async Task Update(Domain.Cases.Case entity, CancellationToken cancellationToken)
    {
        var query = CaseQueries.Update(entity, cancellationToken);
        await _connection.ExecuteAsync(query);
    }
}