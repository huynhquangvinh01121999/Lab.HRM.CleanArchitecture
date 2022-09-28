using API.SignalR.Clients;
using Application.Features.Notifications.Commands.CreatePushNotify;
using Application.Features.Notifications.Queries;
using Application.Features.Notifications.Queries.GetListNotifiesByUserId;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace API.SignalR
{
    public class Chathub : Hub<IChatClient>
    {
        private readonly IMediator _mediator;

        public Chathub(IMediator mediator)
        {
            _mediator = mediator;
        }

        // C1
        //public async Task SendMessage(PushNotify command)
        //{
        //    await Clients.All.SendAsync("ReceiveNotification", command);
        //}

        public async Task SendNotification(PushNotifyCommand message)
        {
            await _mediator.Send(message);
            await Clients.All.ReceiveNotification(message);
        }

        public async Task CheckNewNotify(Guid userId)
        {
            var result = await _mediator.Send(new GetListNotifyByUserIdQuery { UserId = userId});
            await Clients.All.HasBeenCheckedNewNotify(result.Data);
        }
    }
}
