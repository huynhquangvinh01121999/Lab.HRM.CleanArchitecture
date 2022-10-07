using Domain.Entities;
using Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Persistence.Repositories.Base;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class EmployeeRepository : Repository<Employees>, IEmployeeRepository
    {
        private readonly LabContext _dbContext;
        public EmployeeRepository(LabContext context) : base(context)
        {
            _dbContext = context;
        }

        public async Task<Employees> GetLastEmployee()
        {
            var employees = from s in _dbContext.Employees
                            select s;
            return await employees.Include(x => x.Mode)
                            .Include(x => x.Department)
                            .Include(x => x.TitleName)
                            .OrderByDescending(x => x.Id)
                            .Take(1).FirstOrDefaultAsync();
        }
    }
}
