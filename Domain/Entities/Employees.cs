using System;

namespace Domain.Entities
{
    public class Employees : BaseEntity
    {
        public string FullName { get; set; }

        public DateTime DoB { get; set; }

        public string PoB { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string ImagePath { get; set; } 

        public int TitleId { get; set; }  

        public int DepartmentId { get; set; } 

        public int ModeId { get; set; }

        public DateTime Timestamp { get; set; }

        public Department Department { get; set; }
        public TitleName TitleName { get; set; }
        public Mode Mode { get; set; }
    }
}
