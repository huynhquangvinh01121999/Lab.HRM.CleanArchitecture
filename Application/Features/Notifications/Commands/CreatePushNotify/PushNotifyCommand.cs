using Application.DTOs.ResultDto;
using Domain.Entities;
using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

namespace Application.Features.Notifications.Commands.CreatePushNotify
{
    public class PushNotifyCommand : IRequest<HandlerResult<Notify>>
    {
        [Required(ErrorMessage = "Title is required!")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Content is required!")]
        public string Content { get; set; }

        [Required(ErrorMessage = "UserId is required!")]
        public Guid UserId { get; set; }
    }
}
