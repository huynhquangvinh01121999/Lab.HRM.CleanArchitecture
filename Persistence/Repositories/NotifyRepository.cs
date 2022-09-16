using Domain.Entities;
using Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class NotifyRepository : Repository<Notify>, INotifyRepository
    {
        private readonly LabContext _db;

        public NotifyRepository(LabContext context) : base(context) {
            _db = context;
        }

        public async Task<IEnumerable<Notify>> GetListNotifyByUserId(Guid userId)
        {
            var listNotify = await _db.Set<Notify>().Where(x => x.UserId.Equals(userId)).ToListAsync();
            return listNotify;
        }
    }
}
