using Business.Commands.JobApplicationCommands;
using Entities.DTO.Request.JobApplicationRequest;
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
    public class JobApplicationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public JobApplicationsController(IMediator mediatr)
        {
            _mediator = mediatr;
        }

        /// <summary>
        /// Add User Job Application
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> UserJobApplicationAdd(UserJobApplicationRequest request)
        {
            var result = await _mediator.Send(new UserJobApplicationCommand(request));
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
    }
}
