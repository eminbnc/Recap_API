using Business.Queries.JobPostingQueris;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecapAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobPostigsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public JobPostigsController(IMediator mediatr)
        {
            _mediator = mediatr;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> PostingsAppliedByUserId(int id)
        {
            var result = await _mediator.Send(new PostingsIAppliedQuery(id));
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

    }
}
