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
        public void SearchWord_WordFound_ResultContainsWordDefinition()
        {
            var dictionaryApiClient = new OxfordDictionaryApiClient();
            var sut = new SearchWordQueryHandler(dictionaryApiClient);
            var request = new SearchWordQuery
            {
                Word = "ace"
            };

            var result = sut.Handle(request);

            result.ShouldBeOfType<SearchResultModel>();
            result.WordEntry.Word.ShouldBe("ace");
            result.WordEntry.LexicalEntries.First()
                .SenseEntries.First()
                .Definition.ShouldBe("a playing card with a single spot on it, ranked as the highest card in its suit in most card games");
        }
    }
}