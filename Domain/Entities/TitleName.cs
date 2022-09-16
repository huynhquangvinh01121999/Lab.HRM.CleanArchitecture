using System.Collections.Generic;

namespace Domain.Entities
{
    public class TitleName : BaseEntity
    {
        public string TName { get; set; }

        public List<Employees> Personnels { get; set; }
    }
}
