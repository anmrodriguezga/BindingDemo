using Microsoft.EntityFrameworkCore;
using WebApplication2.DTO;
using WebApplication2.Entities;

namespace WebApplication2.AppDbContext
{
    public interface IAppDbContext
    {
        DbSet<Parcel> Parcel { get; set; }
        DbSet<ParcelDto> ParcelDto { get; set; }

        public List<Dictionary<string, object>> ExecuteSqlScript(string script);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
