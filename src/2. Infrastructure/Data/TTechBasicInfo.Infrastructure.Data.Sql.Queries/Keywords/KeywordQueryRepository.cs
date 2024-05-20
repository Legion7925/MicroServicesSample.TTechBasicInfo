using Microsoft.EntityFrameworkCore;
using TTechBasicInfo.Core.Contracts.Keywords.DAL;
using TTechBasicInfo.Core.Contracts.Keywords.Queries.SearchTitle;
using TTechBasicInfo.Infrastructure.Data.Sql.Queries.Common;
using Zamin.Core.Contracts.Data.Queries;
using Zamin.Core.RequestResponse.Queries;
using Zamin.Infra.Data.Sql.Queries;

namespace TTechBasicInfo.Infrastructure.Data.Sql.Queries.Keywords;

public class KeywordQueryRepository : BaseQueryRepository<TTechBasicInfoQueryDbContext>, IKeywordQueryRepository
{
    public KeywordQueryRepository(TTechBasicInfoQueryDbContext dbContext) : base(dbContext)
    {
    }

    public PagedData<KeywordSearchResult> Query(SearchTitleAndStatusQuery titleAndStatusQuery)
    {
        PagedData<KeywordSearchResult> result = new();
        var query = _dbContext.Keywords.AsNoTracking();
        if(titleAndStatusQuery.Status.HasValue)
        {
            query = query.Where(c=> c.Status == titleAndStatusQuery.Status.Value);
        }

        if(!string.IsNullOrEmpty(titleAndStatusQuery.Title))
        {
           query =  query.Where(c=> c.Title.StartsWith(titleAndStatusQuery.Title)); 
        }

        result.QueryResult = query.OrderBy(c => c.Title)
           .Skip(titleAndStatusQuery.SkipCount)
           .Take(titleAndStatusQuery.PageSize)
           .Select(c => new KeywordSearchResult
           {
               Title = c.Title,
               Status = c.Status,
               BusinessId = c.BusinessId,
               Id = c.Id
           }).ToList();


        if (titleAndStatusQuery.NeedTotalCount)
        {
            result.TotalCount = query.Count();
        }

        return result;
    }
}
