using Application.Features.Users.Commands.Authenticate;
using Application.Features.Users.Commands.RegisterAdmin;
using Application.Features.Users.Commands.RegisterCommon;
using Application.Features.Users.Commands.RegisterUser;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiVersion("1.0")]
    public class UsersController : BaseApiController
    {
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await Mediator.Send(command));
        }

        [HttpPost("registerCommon")]
        public async Task<IActionResult> Register([FromBody] RegisterCommonCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await Mediator.Send(command));
        }

        [HttpPost("registerUser")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await Mediator.Send(command));
        }

        [HttpPost("registerAdmin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterAdminCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await Mediator.Send(command));
        }
    }
}
