using Microsoft.EntityFrameworkCore;
using TTechBasicInfo.Infrastructure.Data.Sql.Queries.Keywords.Entities;
using Zamin.Infra.Data.Sql.Queries;

namespace TTechBasicInfo.Infrastructure.Data.Sql.Queries.Common;

public class TTechBasicInfoQueryDbContext : BaseQueryDbContext
{
    public DbSet<Keyword> Keywords { get; set; }
    public TTechBasicInfoQueryDbContext(DbContextOptions options) : base(options)
    {
    }
}
