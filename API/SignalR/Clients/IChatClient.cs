using Application.Features.Notifications.Commands.CreatePushNotify;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.SignalR.Clients
{
    public interface IChatClient
    {
        Task ReceiveNotification(PushNotifyCommand message);

        Task HasBeenCheckedNewNotify(IEnumerable<Notify> notifies);
    }
}
