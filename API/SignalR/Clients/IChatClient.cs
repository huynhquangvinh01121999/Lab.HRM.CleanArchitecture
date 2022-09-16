using Application.Features.Notifications.Commands.Create;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.SignalR.Clients
{
    public interface IChatClient
    {
        Task ReceiveNotification(PushNotify message);

        Task HasBeenCheckedNewNotify(IEnumerable<Notify> notifies);
    }
}
