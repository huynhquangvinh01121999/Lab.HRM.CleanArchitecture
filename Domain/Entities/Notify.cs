using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Notify : BaseEntity
    {

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        public Guid UserId { get; set; }

        public List<UserNotify> UserNotifications { get; set; }
    }
}
