using TTechBasicInfo.Core.Domain.Keywords.Entities;

namespace TTechBasicInfo.Infrastructure.Data.Sql.Queries.Keywords.Entities;

public class Keyword
{
    public long Id { get; set; }

    public Guid BusinessId { get; set; }

    public KeywordStatus Status { get; set; }

    public string Title { get; set; }
}
