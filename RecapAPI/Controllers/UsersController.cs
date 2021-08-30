using Business.Commands.UserCommands;
using Business.Queries.UserQueries;
using Entities.DTO.Request.UserRequest;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace RecapAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediatr)
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
        /// <summary>
        /// Get All Accessible Users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            var result = await _mediator.Send(new GetAllUserQuery());
            if (result.Success) return Ok(result);
            return BadRequest(result);
        }
    }
}
