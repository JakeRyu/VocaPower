using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VocaPower.Application.Word.Query;

namespace VocaPower.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LookUpHistoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LookUpHistoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new LookUpHistoryQuery()));
        }
    }
}