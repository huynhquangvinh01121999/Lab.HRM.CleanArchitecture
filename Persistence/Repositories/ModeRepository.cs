using Domain.Entities;
using Domain.IRepositories;
using Persistence.Repositories.Base;

namespace Persistence.Repositories
{
    public class ModeRepository : Repository<Mode> , IModeRepository
    {
        public ModeRepository(LabContext context) : base(context) { }
    }
}
