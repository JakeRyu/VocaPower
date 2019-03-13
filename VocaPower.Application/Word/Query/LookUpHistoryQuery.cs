using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VocaPower.Persistence;

namespace VocaPower.Application.Word.Query
{
    public class LookUpHistoryQuery : IRequest<LookUpHistoryResponse>
    {
        public class Handler : IRequestHandler<LookUpHistoryQuery, LookUpHistoryResponse>
        {
            private readonly AppDbContext _db;

            public Handler(AppDbContext db)
            {
                _db = db;
            }
            public async Task<LookUpHistoryResponse> Handle(LookUpHistoryQuery request, CancellationToken cancellationToken)
            {
                return new LookUpHistoryResponse
                {
                    PlaceHolder = new string[] {"Hello"}
                };
            }
        }
    }

    public class LookUpHistoryResponse
    {
        public string[] PlaceHolder { get; set; }
    }
}