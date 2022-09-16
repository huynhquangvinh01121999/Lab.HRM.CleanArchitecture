using System;

namespace Application.DTOs.EmployeeDto
{
    public class EmployeeRequest
    {
        public string FullName { get; set; }

        public DateTime DoB { get; set; }

        public string PoB { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public int TitleId { get; set; }

        public int DepartmentId { get; set; }

        public int ModeId { get; set; }
    }
}
