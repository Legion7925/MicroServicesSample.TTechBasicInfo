using TTechBasicInfo.Core.Contracts.Keywords.DAL;
using TTechBasicInfo.Core.Domain.Keywords.Entities;
using TTechBasicInfo.Infrastructure.Data.Sql.Commands.Common;
using Zamin.Infra.Data.Sql.Commands;

namespace TTechBasicInfo.Infrastructure.Data.Sql.Commands.Keywords
{
    public class KeywordCommandRepository : BaseCommandRepository<Keyword, TTechBasicInfoCommandDbContext>, IKeywordCommandRepository
    {
        public KeywordCommandRepository(TTechBasicInfoCommandDbContext dbContext) : base(dbContext)
        {
        }
    }
}
