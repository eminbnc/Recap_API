using Business.Commands.JobPostingCommands;
using Business.Queries.JobPostingQueris;
using Entities.DTO.Request.JobPostingRequest;
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
        /// <summary>
        /// Postings Applied By user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> PostingsAppliedByUserId(int id)
        {
            var result = await _mediator.Send(new PostingsIAppliedQuery(id));
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
        /// <summary>
        /// Company Job Posting Add
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> JobPostingAddByCompany(JobPostingAddRequest request)
        {
            var result = await _mediator.Send(new JobPostingAddCommand(request));
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
        /// <summary>
        /// Get All Job Posting
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllJobPosting()
        {
            var result = await _mediator.Send(new GetAllJobQuery());
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
    }
}
