using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System;
using Domain.IRepositories;
using Domain.Entities;
using Application.Features.Notifications.Commands.Create;
using Application.DTOs.ResultDto;
using Utilities.Helpers;

namespace Application.Features.Notifications.Handlers.Create
{
    public class PushNotifyHandler : IRequestHandler<PushNotify, HandlerResult<Notify>>
    {
        private readonly INotifyRepository _notificationRepository;

        public PushNotifyHandler(INotifyRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public async Task<HandlerResult<Notify>> Handle(PushNotify request, CancellationToken cancellationToken)
        {
            var result = await _notificationRepository.CreateAsync(new Notify
            {
                Title = request.Title,
                Content = request.Content,
                Created = DateTime.Now,
                UserId = request.UserId
            });

            if (result != null)
                return new HandlerResult<Notify>().Successed(Constant.Message.CREATED_SUCCESSES, result);

            return new HandlerResult<Notify>().Failed(Constant.Message.FAILURE);
        }
    }
}
