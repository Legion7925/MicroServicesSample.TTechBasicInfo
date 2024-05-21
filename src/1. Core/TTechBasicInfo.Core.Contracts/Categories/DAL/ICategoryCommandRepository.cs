using TTechBasicInfo.Core.Domain.Categories.Entities;
using Zamin.Core.Contracts.Data.Commands;


namespace TTechBasicInfo.Core.Contracts.Categories.DAL;

public interface ICategoryCommandRepository : ICommandRepository<Category, long>
{
}
