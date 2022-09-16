using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class AppUsers : IdentityUser<Guid>
    {
        public List<UserNotify> UserNotifications { get; set; }
    }
}
