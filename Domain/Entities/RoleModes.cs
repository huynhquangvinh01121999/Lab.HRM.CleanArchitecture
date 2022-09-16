using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class RoleModes : BaseEntity
    {
        public Guid RoleId { get; set; }

        public int ModeId { get; set; }
    }
}
