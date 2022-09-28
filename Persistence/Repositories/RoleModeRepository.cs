using Domain.Entities;
using Domain.IRepositories;
using Persistence.Contexts;
using Persistence.Repositories.Base;

namespace Persistence.Repositories
{
    public class RoleModeRepository : Repository<RoleModes> , IRoleModeRepository
    {
        public RoleModeRepository(LabContext context) : base(context) { }
    }
}
