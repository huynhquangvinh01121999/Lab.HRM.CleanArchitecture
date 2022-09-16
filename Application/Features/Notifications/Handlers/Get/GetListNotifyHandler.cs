using Application.DTOs.ResultDto;
using Application.Features.Notifications.Queries;
using Domain.Entities;
using Domain.IRepositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Utilities.Helpers;

namespace Application.Features.Notifications.Handlers.Get
{
    public class GetListNotifyHandler : IRequestHandler<GetListNotify, HandlerResult<IReadOnlyList<Notify>>>
    {
        private readonly INotifyRepository _notificationRepository;

        public GetListNotifyHandler(INotifyRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public async Task<HandlerResult<IReadOnlyList<Notify>>> Handle(GetListNotify request, CancellationToken cancellationToken)
        {
            var results = await _notificationRepository.GetAllAsync();

            if (results == null)
                return new HandlerResult<IReadOnlyList<Notify>>().Failed(Constant.Message.EMPTY_DATA);

            return new HandlerResult<IReadOnlyList<Notify>>().Successed(Constant.Message.FETCHING_DATA_SUCCESSES, results);
        }
    }
}
