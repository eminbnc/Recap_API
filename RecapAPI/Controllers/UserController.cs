using Business.Commands.UserCommands;
using Entities.DTO.Request;
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
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediatr)
        {
            _mediator = mediatr;
        }
        /// <summary>
        /// User Login Operation
        /// </summary>
        /// <param name="loginRequest"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginRequest loginRequest)
        {
            var result = await _mediator.Send(new UserForLoginCommand(loginRequest));
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
        /// <summary>
        /// User Registration Operation
        /// </summary>
        /// <param name="registerRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> RegisterForUser(UserForRegisterRequest registerRequest)
        {
            var result = await _mediator.Send(new UserForRegisterCommand(registerRequest));
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
    }
}
