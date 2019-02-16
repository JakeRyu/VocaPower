using VocaPower.Application.Word.Model;

namespace VocaPower.Application.Word.Query
{
    public class SearchWordQueryHandler
    {
        public SearchResultModel Handle(SearchWordQuery request)
        {
            return new SearchResultModel
            {
                Word = new Domain.Entities.Word
                {
                    Id = "Hello",
                    Definition = "Greeting"
                }
            };
        }
     }
}