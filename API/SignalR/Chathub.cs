using API.SignalR.Clients;
using Application.Features.Notifications.Commands.Create;
using Application.Features.Notifications.Queries;
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

        public async Task SendNotification(PushNotify message)
        {
            await _mediator.Send(message);
            await Clients.All.ReceiveNotification(message);
        }

        public async Task CheckNewNotify(Guid userId)
        {
            var result = await _mediator.Send(new GetListNotifyByUserId { UserId = userId});
            await Clients.All.HasBeenCheckedNewNotify(result.Data);
        }
    }
}
