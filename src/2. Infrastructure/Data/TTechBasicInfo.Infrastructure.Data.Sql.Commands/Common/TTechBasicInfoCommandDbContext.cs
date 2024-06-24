using Microsoft.EntityFrameworkCore;
using TTechBasicInfo.Core.Domain.Categories.Entities;
using TTechBasicInfo.Core.Domain.Categories.ValueObjects;
using TTechBasicInfo.Core.Domain.Common.ValueObjects;
using TTechBasicInfo.Core.Domain.Keywords.Entities;
using TTechBasicInfo.Infrastructure.Data.Sql.Commands.Categories;
using Zamin.Core.Domain.Toolkits.ValueObjects;
using Zamin.Core.Domain.ValueObjects;
using Zamin.Extensions.Events.Outbox.Dal.EF;
using Zamin.Infra.Data.Sql.Commands;
using Zamin.Infra.Data.Sql.Commands.ValueConversions;

namespace TTechBasicInfo.Infrastructure.Data.Sql.Commands.Common;

public class TTechBasicInfoCommandDbContext : BaseOutboxCommandDbContext
{
    public DbSet<Keyword> Keywords { get; set; }
    public DbSet<Category> Categories { get; set; }

    public TTechBasicInfoCommandDbContext(DbContextOptions<TTechBasicInfoCommandDbContext> options)
        : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        base.OnModelCreating(builder);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<BusinessId>().HaveConversion<BusinessIdConversion>();
        configurationBuilder.Properties<Title>().HaveConversion<TitleConversion>();
        configurationBuilder.Properties<Description>().HaveConversion<DescriptionConversion>();
        configurationBuilder.Properties<TinyString>().HaveConversion<TinyStringValueConversion>();
        configurationBuilder.Properties<CategoryName>().HaveConversion<CategoryNameValueConversion>();
        configurationBuilder.Properties<CategoryTitle>().HaveConversion<CategoryTitleValueConversion>();
    }
}
