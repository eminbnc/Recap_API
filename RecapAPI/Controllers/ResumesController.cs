using Business.Commands.ResumeCommands;
using Business.Queries.ResumeQueries;
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
    public class ResumesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ResumesController(IMediator mediatr)
        {
            _mediator = mediatr;
        }
        /// <summary>
        /// Resume Add By User Id
        /// </summary>
        /// <param name="resumeFile"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("{id}")]
        public async Task<IActionResult> ResumeAddByUserId(IFormFile resumeFile, int id)
        {
            var result = await _mediator.Send(new UserResumeAddCommand(resumeFile ,id));
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
        /// <summary>
        /// Get Resumes By User Id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetResumeByUserId(int userId)
        {
            var result = await _mediator.Send(new GetResumeByUserIdQuery(userId));
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }

    }
}
