using Application.Features.Notifications.Commands.CreatePushNotify;
using Application.Features.Notifications.Queries.GetListNotifies;
using Application.Features.Notifications.Queries.GetListNotifiesByUserId;
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
            return Ok(await Mediator.Send(new GetListNotifyQuery()));
        }

        [HttpGet("getByUserId")]
        [Authorize]
        public async Task<IActionResult> GetByUserId(Guid userId)
        {
            return Ok(await Mediator.Send(new GetListNotifyByUserIdQuery { UserId = userId }));
        }

        [HttpPost("createNew")]
        [Authorize]
        public async Task<IActionResult> CreateNotification([FromBody] PushNotifyCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
