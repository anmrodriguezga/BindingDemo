namespace WebApplication2.Entities
{
    public class Parcel : IApplicationBaseEntity
    {
        public string parcel_number { get; set; }
        public DateTime? parcel_created { get; set; }
        public int? parcel_created_year { get; set; }
        public string parcel_created_level { get; set; }
    }
}
