using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Internal;
using Shouldly;
using VocaPower.Application.Interface;
using VocaPower.Application.Word.Command;
using VocaPower.Domain.Entity;
using VocaPower.Persistence;
using Xunit;

namespace VocaPower.Application.Tests.Word.Command
{
    public class SaveLookUpHistoryTests
    {
        [Fact]
        public void Handler_WhenCalled_SaveLookUpHistoryEntry()
        {
            var db = new DatabaseService();
            var command = new SaveLookUpHistoryCommand
            {
                Word = "ace",
                Definition = "cool"
            };
            var sut = new SaveLookUpHistoryCommand.Handler(db);
            
            sut.Execute(command);

            db.LookUpHistories
                .First(h => h.Word == "ace")
                .ShouldBeNull();
        }
    }
}