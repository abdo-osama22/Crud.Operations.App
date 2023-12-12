using Demo.BusinessLogicLayer.Interfaces;
using Demo.DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.DataAccessLayer;
using Demo.DataAccessLayer.Contexts;

namespace Demo.BusinessLogicLayer.Repositories
{
    public class departmentRepository :GenericRepository<Department>, IdepartmentRepository
    {
        public departmentRepository(MVCAppG02DbContext dbContext):base(dbContext)
        {

        }


    }
}
