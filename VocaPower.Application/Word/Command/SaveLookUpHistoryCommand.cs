using System.Collections.Generic;
using VocaPower.Application.Interface;
using VocaPower.Domain.Entity;

namespace VocaPower.Application.Word.Command
{
    public class SaveLookUpHistoryCommand
    {
        public string Word { get; set; }
        public string Definition { get; set; }

        public class Handler
        {
            private readonly IDatabaseService _db;

            public Handler(IDatabaseService db)
            {
                _db = db;
            }
            public void Execute(SaveLookUpHistoryCommand command)
            {
                var newEntry = new LookUpHistory
                {
                    Word = command.Word,
                    Definition = command.Definition
                };
                
                _db.LookUpHistories.Add(newEntry);

                _db.SaveChanges();
            }
        }
    }
}