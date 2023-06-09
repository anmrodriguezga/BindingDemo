using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WebApplication2.DTO;
using WebApplication2.Entities;

namespace WebApplication2.AppDbContext
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Parcel> Parcel { get; set; }
        public DbSet<ParcelDto> ParcelDto { get; set; }

        public List<Dictionary<string, object>> ExecuteSqlScript(string script)
        {
            var connection = this.Database.GetDbConnection();
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = script;

            using var reader = command.ExecuteReader();
            var results = new List<Dictionary<string, object>>();

            while (reader.Read())
            {
                var result = new Dictionary<string, object>();

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    string propertyName = reader.GetName(i);
                    object value = reader.GetValue(i);

                    result[propertyName] = value;
                }

                results.Add(result);
            }

            return results;
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly(),
                t => t.GetInterfaces().Any(i =>
                    i.IsGenericType &&
                    i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>) &&
                    typeof(IApplicationBaseEntity).IsAssignableFrom(i.GenericTypeArguments[0])));

            base.OnModelCreating(builder);
        }
    }
}
