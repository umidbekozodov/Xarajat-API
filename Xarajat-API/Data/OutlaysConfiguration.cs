using Microsoft.EntityFrameworkCore;
using Xarajat_API.Entities;

namespace Xarajat_API.Data;

public class OutlaysConfiguration : IEntityTypeConfiguration<Outlay>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Outlay> builder)
    {
        builder.Property(o => o.Id).HasMaxLength(20).IsRequired();
        builder.Property(o => o.Description).HasColumnName("salomoutlaydescription").HasMaxLength(48).IsRequired(false);
    }


}