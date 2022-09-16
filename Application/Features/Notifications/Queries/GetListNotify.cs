using Application.DTOs.ResultDto;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace Application.Features.Notifications.Queries
{
    public class GetListNotify : IRequest<HandlerResult<IReadOnlyList<Notify>>>
    {
    }
}
