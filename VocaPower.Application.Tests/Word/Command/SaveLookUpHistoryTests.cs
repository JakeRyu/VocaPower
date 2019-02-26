using System.Linq;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using VocaPower.Application.Word.Command;
using VocaPower.Persistence;
using Xunit;

namespace VocaPower.Application.Tests.Word.Command
{
    public class SaveLookUpHistoryTests
    {
        [Fact]
        public void Handler_WhenCalled_SaveLookUpHistoryEntry()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            try
            {
                var options = new DbContextOptionsBuilder<DatabaseService>()
                    .UseSqlite(connection)
                    .Options;

                // Create the schema in the database
                using (var context = new DatabaseService(options))
                {
                    context.Database.EnsureCreated();
                }

                using (var context = new DatabaseService(options))
                {
                    var command = new SaveLookUpHistoryCommand
                    {
                        Word = "ace",
                        Definition = "top card"
                    };
                    var sut = new SaveLookUpHistoryCommand.Handler(context);
            
                    sut.Execute(command);
                }

                using (var context = new DatabaseService(options))
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

            var db = new DatabaseService();
            
        }
    }
}