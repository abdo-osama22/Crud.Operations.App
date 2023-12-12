using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogicLayer.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IEmployeeReopsitory EmployeeReopsitory { get; set; }
        public IdepartmentRepository departmentRepository { get; set; }

        Task<int> complete();
    }
}
