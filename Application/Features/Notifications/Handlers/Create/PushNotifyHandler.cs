using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System;
using Domain.IRepositories;
using Domain.Entities;
using Application.Features.Notifications.Commands.Create;
using Application.DTOs.ResultDto;
using Utilities.Helpers;
using AutoMapper;

namespace Application.Features.Notifications.Handlers.Create
{
    public class PushNotifyHandler : IRequestHandler<PushNotify, HandlerResult<Notify>>
    {
        private readonly INotifyRepository _notificationRepository;
        private readonly IMapper _mapper;

        public PushNotifyHandler(INotifyRepository notificationRepository, IMapper mapper)
        {
            _notificationRepository = notificationRepository;
            _mapper = mapper;
        }

        public async Task<HandlerResult<Notify>> Handle(PushNotify request, CancellationToken cancellationToken)
        {
            var notify = _mapper.Map<Notify>(request);
            var result = await _notificationRepository.CreateAsync(notify);

            if (result != null)
                return new HandlerResult<Notify>().Successed(Constant.Message.CREATED_SUCCESSES, result);

            return new HandlerResult<Notify>().Failed(Constant.Message.FAILURE);
        }
    }
}
