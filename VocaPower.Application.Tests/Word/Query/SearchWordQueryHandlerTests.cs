using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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
        public async Task SearchAWord_TheWordFound_ResultReturnsWithTheWord()
        {
            var dictionaryApiClient = new OxfordDictionaryApiClient();
            var sut = new LookUpWordQuery.Handler(dictionaryApiClient);
            var request = new LookUpWordQuery
            {
                Word = "ace"
            };

            var response = await sut.Handle(request, CancellationToken.None);

            response.ShouldBeOfType<LookUpResponse>();
            response.Results[0].Word.ShouldBe(request.Word);
        }
    }
}