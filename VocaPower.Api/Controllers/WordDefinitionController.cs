using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using VocaPower.Application.Word.Query;
using VocaPower.Infrastructure.OxfordDictionaryApi;

namespace VocaPower.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordDefinitionController : ControllerBase
    {
        [Route("{word}")]
        [HttpGet]
        public ActionResult LookUp(string word)
        {
            var request = new LookUpWordQuery {Word = word};
            
            var handler = new LookUpWordQuery.Handler(new OxfordDictionaryApiClient());

            var response = handler.Execute(request);
            
            
            return new JsonResult(response);
        }
    }
}