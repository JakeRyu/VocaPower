using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Shouldly;
using VocaPower.Domain.LookUp;
using VocaPower.Domain.Users;
using VocaPower.Persistence;
using Xunit;

namespace VocaPower.Application.Tests.Infrastructure
{
    public class SQLiteInMemoryDbTests
    {
        [Fact]
        public void Add_writes_to_database()
        {
            // In-memory database only exists while the connection is open
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            try
            {
                var options = new DbContextOptionsBuilder<AppDbContext>()
                    .UseSqlite(connection)
                    .Options;

                // Create the schema in the database
                using (var context = new AppDbContext(options))
                {
                    context.Database.EnsureCreated();
                }

                // Run the test against one instance of the context
                using (var context = new AppDbContext(options))
                { 
                    var history = new LookUpHistory
                    {
                        Word = "ace",
                        Definition = "top card",
                        User = new AppUser()
                    };
                    context.LookUpHistories.Add(history);
                    context.SaveChanges();
                }

                // Use a separate instance of the context to verify correct data was saved to database
                using (var context = new AppDbContext(options))
                {
                    context.LookUpHistories.Count().ShouldBe(1);
                }
            }
            finally
            {
                connection.Close();
            }
        }
    }
}