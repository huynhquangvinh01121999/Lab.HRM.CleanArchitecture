using Domain.Entities;
using Domain.IRepositories.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface INotifyRepository : IRepository<Notify>
    {
        Task<IEnumerable<Notify>> GetListNotifyByUserId(Guid userId);
    }
}
