using VocaPower.Application.Interface;
using VocaPower.Application.Word.Model;

namespace VocaPower.Application.Word.Query
{
    public class LookUpWordQuery
    {
        public string Word { get; set; }
        
        public class Handler
        {
            private readonly IDictionaryApiClient _dictionaryService;

            public Handler(IDictionaryApiClient dictionaryService)
            {
                _dictionaryService = dictionaryService;
            }
        
            public LookUpResponse Execute(LookUpWordQuery request)
            {
                return _dictionaryService.LookUp(request.Word);
            }
        }
    }
}