using Demo.BusinessLogicLayer.Interfaces;
using Demo.DataAccessLayer.Contexts;
using Demo.DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogicLayer.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeReopsitory
    {

        public EmployeeRepository(MVCAppG02DbContext dbContext):base(dbContext)
        {
            
        }
        public IQueryable<Employee> GetEmployeesByAddress(string Address)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Employee> SearchEmployeeByName(string name)
        => _dbContext.Employees.Where(E => E.Name.ToLower().Contains(name.ToLower()));
    }
}
