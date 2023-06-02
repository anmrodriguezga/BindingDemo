using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WebApplication2.DTO;

namespace WebApplication2.Entities.Config
{
    public class ParcelDtoConfig : IEntityTypeConfiguration<ParcelDto>
    {
        public void Configure(EntityTypeBuilder<ParcelDto> builder)
        {
            builder.ToTable("parceldto", "dbo")
                .HasNoKey();
        }
    }
}
