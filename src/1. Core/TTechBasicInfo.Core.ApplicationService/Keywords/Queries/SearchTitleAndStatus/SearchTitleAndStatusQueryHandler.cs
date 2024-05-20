using TTechBasicInfo.Core.Contracts.Keywords.DAL;
using TTechBasicInfo.Core.Contracts.Keywords.Queries.SearchTitle;
using Zamin.Core.ApplicationServices.Queries;
using Zamin.Core.RequestResponse.Queries;
using Zamin.Utilities;

namespace TTechBasicInfo.Core.ApplicationService.Keywords.Queries.SearchTitleAndStatus;

public class SearchTitleAndStatusQueryHandler : QueryHandler<SearchTitleAndStatusQuery, PagedData<KeywordSearchResult>>
{
    private readonly IKeywordQueryRepository _repository;
    public SearchTitleAndStatusQueryHandler(ZaminServices zaminServices, IKeywordQueryRepository repository) : base(zaminServices)
    {
        _repository = repository;
    }

    public override async Task<QueryResult<PagedData<KeywordSearchResult>>> Handle(SearchTitleAndStatusQuery query)
    {
        var result = _repository.Query(query);
        return await ResultAsync(result);
    }
}
