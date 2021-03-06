using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VocaPower.Application.Events;
using VocaPower.Application.Word.Query;
using VocaPower.Infrastructure.OxfordDictionaryApi;

namespace VocaPower.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordDefinitionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WordDefinitionController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet("{word}")]
        public async Task<ActionResult> LookUp(string word)
        {
            var request = new LookUpWordQuery
            {
                Word = word
            };
            
            var response = await _mediator.Send(request);

            await _mediator.Publish(new LookUpCalled(response));
            
            return Ok(response);
        }
    }
}