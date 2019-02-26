using Microsoft.EntityFrameworkCore;
using VocaPower.Application.Interface;
using VocaPower.Domain.Entity;

namespace VocaPower.Persistence
{
    public class DatabaseService : DbContext, IDatabaseService
    {
        public DbSet<LookUpHistory> LookUpHistories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=tcp:jake-test.database.windows.net,1433;Initial Catalog=VocaPowerTest;Persist Security Info=False;User ID={your_username};Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
    }
}