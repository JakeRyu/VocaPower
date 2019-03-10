using System.Linq;
using System.Threading;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using VocaPower.Application.Word.Command;
using VocaPower.Domain.Users;
using VocaPower.Persistence;
using Xunit;

namespace VocaPower.Application.Tests.Word.Command
{
    public class SaveLookUpHistoryTests
    {
        [Fact]
        public void Handler_ExecutedWithSqliteDb_SaveLookUpHistoryEntry()
        {
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

                using (var context = new AppDbContext(options))
                {
                    var command = new SaveLookUpHistoryCommand
                    {
                        Word = "ace",
                        Definition = "top card",
                        User = new AppUser()
                    };
                    var sut = new SaveLookUpHistoryCommand.Handler(context);
            
                    sut.Handle(command, CancellationToken.None);
                }

                using (var context = new AppDbContext(options))
                {
                    context.LookUpHistories
                        .First(h => h.Word == "ace")
                        .Definition.ShouldBe("top card");
                }
            }
            finally
            {
                connection.Close();
            }

            var db = new AppDbContext();
        }


        [Fact]
        public void Handler_ExcutedWithInMemoryDb_SaveLookUpHistoryEntry()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "unique_name")
                .Options;

            using (var context = new AppDbContext(options))
            {
                var command = new SaveLookUpHistoryCommand
                {
                    Word = "ace",
                    Definition = "top card",
                };
                var sut = new SaveLookUpHistoryCommand.Handler(context);
            
                sut.Handle(command, CancellationToken.None);
            }

            using (var context = new AppDbContext(options))
            {
                context.LookUpHistories
                    .First(h => h.Word == "ace")
                    .Definition.ShouldBe("top card");
            }
        }
    }
}