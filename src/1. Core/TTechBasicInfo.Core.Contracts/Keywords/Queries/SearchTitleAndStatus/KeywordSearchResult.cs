using TTechBasicInfo.Core.Domain.Keywords.Entities;

namespace TTechBasicInfo.Core.Contracts.Keywords.Queries.SearchTitle;

public class KeywordSearchResult
{
    public long Id { get; set; }

    public Guid BusinessId { get; set; }

    public KeywordStatus Status { get; set; }

    public string Title { get; set; }
}
