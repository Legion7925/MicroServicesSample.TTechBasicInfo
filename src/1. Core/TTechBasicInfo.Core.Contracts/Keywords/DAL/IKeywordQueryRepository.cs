using TTechBasicInfo.Core.Contracts.Keywords.Queries.SearchTitle;
using Zamin.Core.Contracts.Data.Queries;
using Zamin.Core.RequestResponse.Queries;

namespace TTechBasicInfo.Core.Contracts.Keywords.DAL
{
    public interface IKeywordQueryRepository : IQueryRepository
    {
        PagedData<KeywordSearchResult> Query(SearchTitleAndStatusQuery titleAndStatusQuery);
    }
}
