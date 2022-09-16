using Application.Features.Notifications.Commands.Create;
using Application.Features.Notifications.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiVersion("1.0")]
    public class NotifyController : BaseApiController
    {
        [HttpGet("getList")]
        [Authorize]
        public async Task<IActionResult> GetAllNotifies()
        {
            return Ok(await Mediator.Send(new GetListNotify()));
        }

        [HttpGet("getByUserId")]
        [Authorize]
        public async Task<IActionResult> GetByUserId(Guid userId)
        {
            return Ok(await Mediator.Send(new GetListNotifyByUserId { UserId = userId }));
        }

        [HttpPost("createNew")]
        [Authorize]
        public async Task<IActionResult> CreateNotification([FromBody] PushNotify command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
