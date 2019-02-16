using Shouldly;
using VocaPower.Application.Word.Model;
using VocaPower.Application.Word.Query;
using Xunit;

namespace VocaPower.Application.Tests.Word.Query
{
    public class SearchWordQueryHandlerTests
    {
        [Fact]
        public void SearchWord_WordFound_ResultContainsWordDefinition()
        {
            var sut = new SearchWordQueryHandler();
            var request = new SearchWordQuery
            {
                Word = "Hello"
            };

            var result = sut.Handle(request);

            result.ShouldBeOfType<SearchResultModel>();
            result.Word.Id.ShouldBe("Hello");
            result.Word.Definition.ShouldBe("Greeting");
        }
    }
}