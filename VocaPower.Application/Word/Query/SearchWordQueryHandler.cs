using VocaPower.Application.Interface;
using VocaPower.Application.Word.Model;
using VocaPower.Domain.Entities;

namespace VocaPower.Application.Word.Query
{
    public class SearchWordQueryHandler
    {
        private readonly IDictionaryApiClient _dictionaryService;

        public SearchWordQueryHandler(IDictionaryApiClient dictionaryService)
        {
            _dictionaryService = dictionaryService;
        }
        
        public SearchResultModel Handle(SearchWordQuery request)
        {
            var response = _dictionaryService.LookUp(request.Word);
            
            return new SearchResultModel
            {
                WordEntry = response
            };
        }
     }
}