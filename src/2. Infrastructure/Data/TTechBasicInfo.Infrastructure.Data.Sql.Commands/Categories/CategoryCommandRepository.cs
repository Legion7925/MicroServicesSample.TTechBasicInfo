using TTechBasicInfo.Core.Contracts.Categories.DAL;
using TTechBasicInfo.Core.Domain.Categories.Entities;
using TTechBasicInfo.Infrastructure.Data.Sql.Commands.Common;
using Zamin.Infra.Data.Sql.Commands;

namespace TTechBasicInfo.Infrastructure.Data.Sql.Commands.Categories;

public class CategoryCommandRepository : BaseCommandRepository<Category, TTechBasicInfoCommandDbContext>, ICategoryCommandRepository
{
    public CategoryCommandRepository(TTechBasicInfoCommandDbContext dbContext) : base(dbContext)
    {
    }
}
