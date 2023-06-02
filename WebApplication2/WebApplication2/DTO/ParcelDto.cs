using WebApplication2.Entities;
using WebApplication2.Mapping;

namespace WebApplication2.DTO
{
    public class ParcelDto : IMapFrom<Parcel>, IApplicationBaseEntity
    {
        public string parcel_number { get; set; }
        public DateTime? parcel_created { get; set; }
        public int? parcel_created_year { get; set; }
        public string parcel_created_level { get; set; }
        public string details { get; set; }
    }
}
