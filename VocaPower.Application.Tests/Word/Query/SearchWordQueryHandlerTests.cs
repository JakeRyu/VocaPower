using System.Linq;
using Shouldly;
using VocaPower.Application.Word.Model;
using VocaPower.Application.Word.Query;
using VocaPower.Infrastructure.OxfordDictionaryApi;
using Xunit;

namespace VocaPower.Application.Tests.Word.Query
{
    public class SearchWordQueryHandlerTests
    {
        [Fact]
        public void SearchAWord_TheWordFound_ResultReturnsWithTheWord()
        {
            var dictionaryApiClient = new OxfordDictionaryApiClient();
            var sut = new LookUpWordQuery.Handler(dictionaryApiClient);
            var request = new LookUpWordQuery
            {
                Word = "ace"
            };

            var response = sut.Execute(request);

            response.ShouldBeOfType<LookUpResponse>();
            response.Results[0].Word.ShouldBe(request.Word);
        }
    }
}