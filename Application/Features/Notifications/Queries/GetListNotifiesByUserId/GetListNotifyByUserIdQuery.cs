using Application.DTOs.ResultDto;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;

namespace Application.Features.Notifications.Queries.GetListNotifiesByUserId
{
    public class GetListNotifyByUserIdQuery : IRequest<HandlerResult<IEnumerable<Notify>>>
    {
        public Guid UserId { get; set; }
    }
}
