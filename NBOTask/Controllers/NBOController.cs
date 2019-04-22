using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NBOTask.Services.NBO;
using Newtonsoft.Json.Linq;

namespace NBOTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NBOController : ControllerBase
    {
        private IMediator mediator;
        public NBOController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("suggestions")]
        public async Task<IActionResult> GetProductSuggestions([FromBody] JObject parameters)
        {
            var response = await mediator.Send(parameters.ToObject<SuggestionRequest>());

            return Ok(response.GetResponse());
        }

        [HttpPost("feedback")]
        public async Task<IActionResult> Feedback([FromBody] JObject feedback)
        {
            var response = await mediator.Send(feedback.ToObject<FeedbackRequest>());
            return Ok(response.GetResponse());
        }
    }
}