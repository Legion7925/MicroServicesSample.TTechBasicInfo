using TTechBasicInfo.Core.Domain.Keywords.Entities;
using Zamin.Core.RequestResponse.Queries;

namespace TTechBasicInfo.Core.Contracts.Keywords.Queries.SearchTitle;

public class SearchTitleAndStatusQuery :
    PageQuery<PagedData<KeywordSearchResult>>
{
    public string? Title { get; set; }

    public KeywordStatus? Status { get; set; }
}
