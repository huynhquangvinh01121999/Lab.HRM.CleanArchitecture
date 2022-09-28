using Domain.Entities;
using Domain.IRepositories;
using Persistence.Contexts;
using Persistence.Repositories.Base;

namespace Persistence.Repositories
{
    public class TitleNameRepository : Repository<TitleName> , ITitleNameRepository
    {
        public TitleNameRepository(LabContext context) : base(context) { }
    }
}
