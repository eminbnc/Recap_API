using Business.Commands.CompanyCommands;
using Entities.DTO.Request.CompanyRequest;
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
    public class CompaniesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CompaniesController(IMediator mediatr)
        {
            _mediator = mediatr;
        }

       /// <summary>
       /// Company Login Operation
       /// </summary>
       /// <param name="loginRequest"></param>
       /// <returns></returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login(CompanyForLoginRequest loginRequest)
        {
            var result = await _mediator.Send(new CompanyForLoginCommand(loginRequest));
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
        /// <summary>
        /// Company Registration Operation
        /// </summary>
        /// <param name="registerRequest"></param>
        /// 
        /// 
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> RegisterForUser(CompanyForRegisterRequest registerRequest)
        {
            var result = await _mediator.Send(new CompanyForRegisterCommand(registerRequest));
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
    }
}
