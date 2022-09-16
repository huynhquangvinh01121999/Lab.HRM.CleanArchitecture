using System.Collections.Generic;

namespace Domain.Entities
{
    public class Mode : BaseEntity
    {
        public string Value { get; set; }

        public string MName { get; set; }

        public List<Employees> Personnels { get; set; }
    }
}
