using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Togla.Data.Models;

namespace Togla.Data
{
    public class StockEntityTypeConfiguration : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            // Load in the csv
            builder.Property(s => s.Id)
                .IsRequired();
        }
    }
}