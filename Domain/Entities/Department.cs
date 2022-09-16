using System.Collections.Generic;

namespace Domain.Entities
{
    public class Department : BaseEntity
    {
        public string DName { get; set; }

        public List<Employees> Personnels { get; set; }
    }
}
