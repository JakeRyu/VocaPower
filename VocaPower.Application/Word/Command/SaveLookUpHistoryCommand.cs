using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VocaPower.Application.Interface;
using VocaPower.Domain.LookUp;
using VocaPower.Domain.Users;

namespace VocaPower.Application.Word.Command
{
    public class SaveLookUpHistoryCommand : IRequest
    {
        public string Word { get; set; }
        public string Definition { get; set; }
        public AppUser User { get; set; }


        public class Handler : IRequestHandler<SaveLookUpHistoryCommand>
        {
            private readonly IDatabaseService _db;

            public Handler(IDatabaseService db)
            {
                _db = db;
            }

            public Task<Unit> Handle(SaveLookUpHistoryCommand command, CancellationToken cancellationToken)
            {
                var newEntry = new LookUpHistory
                {
                    Word = command.Word,
                    Definition = command.Definition,
                    User = command.User
                };

                _db.LookUpHistories.Add(newEntry);

                _db.SaveChanges();

                return Task.FromResult(Unit.Value);
            }
        }
    }
}