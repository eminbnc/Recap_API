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
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginRequest loginRequest)
        {
            var result = await _mediator.Send(new UserForLoginCommand(loginRequest));
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
    }
}
