using System;

namespace Domain.Entities
{
    public class UserNotify
    {
        public int NotificationId { get; set; }

        public Guid UserId { get; set; }

        public Notify Notify { get; set; }

        public AppUsers AppUsers { get; set; }
    }
}
