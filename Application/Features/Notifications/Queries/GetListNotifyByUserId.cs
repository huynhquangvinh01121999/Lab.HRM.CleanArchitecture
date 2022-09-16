using Application.DTOs.ResultDto;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;

namespace Application.Features.Notifications.Queries
{
    public class GetListNotifyByUserId : IRequest<HandlerResult<IEnumerable<Notify>>>
    {
        public Guid UserId { get; set; }
    }
}
