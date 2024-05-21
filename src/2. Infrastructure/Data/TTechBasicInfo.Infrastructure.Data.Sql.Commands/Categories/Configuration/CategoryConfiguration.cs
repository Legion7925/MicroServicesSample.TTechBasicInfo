using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TTechBasicInfo.Core.Domain.Categories.Entities;

namespace TTechBasicInfo.Infrastructure.Data.Sql.Commands.Categories.Configs;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.Property(c => c.Title).HasMaxLength(50);
    }
}
