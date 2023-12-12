using Demo.BusinessLogicLayer.Interfaces;
using Demo.DataAccessLayer.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogicLayer.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MVCAppG02DbContext _dbContext;

        public IEmployeeReopsitory EmployeeReopsitory { get; set; }
        public IdepartmentRepository departmentRepository { get; set; }


        public UnitOfWork(MVCAppG02DbContext dbContext) 
        
        {
            EmployeeReopsitory = new EmployeeRepository(dbContext);
            departmentRepository=new departmentRepository(dbContext);
           _dbContext = dbContext;
        }

        public async Task<int> complete()
        =>await _dbContext.SaveChangesAsync();

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
