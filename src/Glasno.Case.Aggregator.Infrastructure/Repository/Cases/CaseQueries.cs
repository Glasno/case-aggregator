using System.Text.Json;
using System.Text.Json.Serialization;
using Dapper;
using Glasno.Case.Aggregator.Infrastructure.Abstractions.Repository.Cases.Contracts;

namespace Glasno.Case.Aggregator.Infrastructure.Repository.Cases;

internal static class CaseQueries
{
    public static CommandDefinition GetByIdQuery(Guid id, CancellationToken cancellationToken)
    {
        const string query = 
@"
select *
from case
where case_id = @Id;
";
        return new CommandDefinition(
            query,
            new 
            {
                Id = id
            },
            cancellationToken: cancellationToken);
    }

    public static CommandDefinition Add(Domain.Cases.Case entity, CancellationToken cancellationToken)
    {
        const string query = 
            @"
INSERT INTO cases
(
 case_id,
 case_type,
 court_name,
 date,
 judge_name,
 plaintiffs,
 respondents) 
VALUES
     (
        @CaseId,
        @CaseType,
        @CourtName,
        CAST(@Date as timestamp without time zone),
        @JudgeName,
        @Plaintiffs::jsonb,
        @Respondents::jsonb
     );
";
        return new CommandDefinition(
            query,
            new 
            {
                entity.CaseId,
                entity.CaseNumber,
                CaseType = Enum.GetName(entity.CaseType),
                entity.CourtName,
                entity.JudgeName,
                Date = DateTime.SpecifyKind(entity.Date ?? DateTime.UtcNow, DateTimeKind.Utc),
                Plaintiffs = JsonSerializer.Serialize(entity.Plaintiffs),
                Respondents = JsonSerializer.Serialize(entity.Respondents)
            },
            cancellationToken: cancellationToken);
    }

    public static CommandDefinition Search(SearchQuery searchQuery, CancellationToken cancellationToken)
    {
        const string query = 
            @"
select
    *
from
    case
where 
    case_id = @Id
limit @Limit
offset @Skip;
";
        return new CommandDefinition(
            query,
            new 
            {
                Limit = searchQuery.Limit,
                Skip = searchQuery.Skip
            },
            cancellationToken: cancellationToken);
    }

    public static CommandDefinition Update(Domain.Cases.Case entity, CancellationToken cancellationToken)
    {
        const string query = 
            @"
UPDATE cases
SET 
    case_type = @CaseType
    court_name = @CourtName
    date = @Date
    judge_name = @JudgeName
WHERE  
    case_id = @Id;
";
        return new CommandDefinition(
            query,
            new 
            {
                Id = entity.CaseId.ToString(),
                CaseType = entity.CaseType,
                Date = entity.Date,
                CourtName = entity.CourtName,
                JudgeName = entity.JudgeName,
            },
            cancellationToken: cancellationToken);
    }
}