using Application.DTOs.ResultDto;
using Domain.Entities;
using Domain.IRepositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Utilities.Helpers;

namespace Application.Features.Notifications.Queries.GetListNotifiesByUserId
{
    public class GetListNotifyByUserIdHandler : IRequestHandler<GetListNotifyByUserIdQuery, HandlerResult<IEnumerable<Notify>>>
    {
        private readonly INotifyRepository _notificationRepository;

        public GetListNotifyByUserIdHandler(INotifyRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public async Task<HandlerResult<IEnumerable<Notify>>> Handle(GetListNotifyByUserIdQuery request, CancellationToken cancellationToken)
        {
            var results = await _notificationRepository.GetListNotifyByUserId(request.UserId);

            if (results == null)
                return new HandlerResult<IEnumerable<Notify>>()
                    .Failed(Constant.Message.EMPTY_DATA);

            return new HandlerResult<IEnumerable<Notify>>()
                .Successed(Constant.Message.FETCHING_DATA_SUCCESSES, results);
        }
    }
}
