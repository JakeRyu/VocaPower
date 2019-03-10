using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VocaPower.Application.Interface;
using VocaPower.Application.Word.Model;

namespace VocaPower.Application.Word.Query
{
    public class LookUpWordQuery : IRequest<LookUpResponse>
    {
        public string Word { get; set; }
        
        public class Handler : IRequestHandler<LookUpWordQuery, LookUpResponse>
        {
            private readonly IDictionaryApiClient _dictionaryService;

            public Handler(IDictionaryApiClient dictionaryService)
            {
                _dictionaryService = dictionaryService;
            }
        
            public Task<LookUpResponse> Handle(LookUpWordQuery request, CancellationToken cancellationToken)
            {
                return Task.FromResult(_dictionaryService.LookUp(request.Word));
            }
        }
    }
}