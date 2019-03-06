using System.Threading;
using Microsoft.EntityFrameworkCore;
using VocaPower.Application.Interface;
using VocaPower.Domain.LookUp;

namespace VocaPower.Persistence
{
    public class EfContext : DbContext, IDatabaseService
    {
        public DbSet<LookUpHistory> LookUpHistories { get; set; }

        public EfContext()
        {
            
        }

        public EfContext(DbContextOptions<EfContext> options) : base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString =
                    "Server=tcp:zqla14cbns.database.windows.net,1433;Initial Catalog=VocaPowerTest;Persist Security Info=False;User ID=dbadmin;Password=Hyundai1!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}