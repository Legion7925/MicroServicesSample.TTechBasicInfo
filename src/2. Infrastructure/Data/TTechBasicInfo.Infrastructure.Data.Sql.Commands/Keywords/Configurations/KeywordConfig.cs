using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TTechBasicInfo.Core.Domain.Keywords.Entities;

namespace TTechBasicInfo.Infrastructure.Data.Sql.Commands.Keywords.Configurationsl;

public class KeywordConfig : IEntityTypeConfiguration<Keyword>
{
    public void Configure(EntityTypeBuilder<Keyword> builder)
    {
        builder.Property(k=>  k.Title).HasConversion<KeywordTitleValueConversion>().HasMaxLength(50);    
    }
}
