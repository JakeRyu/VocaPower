using System.Linq;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using VocaPower.Application.Word.Command;
using VocaPower.Domain.Users;
using VocaPower.Persistence;
using Xunit;

namespace VocaPower.Application.Tests.Word.Command
{
    public class SaveLookUpHistoryTests : IClassFixture<DatabaseFixture>
    {
        private readonly AppDbContext _context;

        public SaveLookUpHistoryTests(DatabaseFixture fixture)
        {
            _context = fixture.Context;
        }

        [Fact]
        public void Handler_ExecutedWithSqliteDb_SaveLookUpHistoryEntry()
        {
            var command = new SaveLookUpHistoryCommand
            {
                Word = "ace",
                Definition = "top card",
                User = new AppUser()
            };
            var sut = new SaveLookUpHistoryCommand.Handler(_context);

            sut.Handle(command, CancellationToken.None);

            _context.LookUpHistories
                .First(h => h.Word == "ace")
                .Definition.ShouldBe("top card");
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