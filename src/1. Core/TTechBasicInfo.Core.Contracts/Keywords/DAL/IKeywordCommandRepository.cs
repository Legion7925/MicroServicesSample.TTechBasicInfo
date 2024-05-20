using TTechBasicInfo.Core.Domain.Keywords.Entities;
using Zamin.Core.Contracts.Data.Commands;

namespace TTechBasicInfo.Core.Contracts.Keywords.DAL;

public interface IKeywordCommandRepository : ICommandRepository<Keyword , long> 
{
}
