using Domain.Entities;
using Domain.IRepositories;
using Persistence.Contexts;
using Persistence.Repositories.Base;

namespace Persistence.Repositories
{
    public class UserNotifyRepository : Repository<UserNotify>, IUserNotifyRepository
    {
        public UserNotifyRepository(LabContext context) : base(context) { }
    }
}
