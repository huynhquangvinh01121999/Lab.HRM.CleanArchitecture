using System;

namespace Application.DTOs.AuthenticateDto
{
    public class LoginResponse
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }

        public string Phone { get; set; }

        public string AccessToken { get; set; }

        public DateTime Expiration { get; set; }
    }
}
