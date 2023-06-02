using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication2.Entities.Config
{
    public class ParcelConfig : IEntityTypeConfiguration<Parcel>
    {
        public void Configure(EntityTypeBuilder<Parcel> builder)
        {
            builder.ToTable("parcel", "dbo")
                .HasNoKey();
        }
    }
}
