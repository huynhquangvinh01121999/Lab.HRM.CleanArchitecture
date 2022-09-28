using Application.DTOs.ResultDto;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace Application.Features.Notifications.Queries.GetListNotifies
{
    public class GetListNotifyQuery : IRequest<HandlerResult<IReadOnlyList<Notify>>>
    {
    }
}
