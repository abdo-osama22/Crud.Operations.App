using Demo.DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogicLayer.Interfaces
{
    public interface IEmployeeReopsitory:IGenericRepository<Employee>
    {
        IQueryable<Employee> GetEmployeesByAddress(string Address);

        IQueryable<Employee> SearchEmployeeByName(string name);
    }
}
