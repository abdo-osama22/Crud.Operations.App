using Demo.BusinessLogicLayer.Interfaces;
using Demo.DataAccessLayer.Contexts;
using Demo.DataAccessLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessLogicLayer.Repositories
{
    public class GenericRepository<T> :IGenericRepository<T> where T :class
    {
        private protected readonly MVCAppG02DbContext _dbContext;

        public GenericRepository(MVCAppG02DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Add(T item)
       
           =>await _dbContext.Set<T>().AddAsync(item);
       
       

        public void delete(T item)
        =>_dbContext.Set<T>().Remove(item);
        

        public async Task<T> Get(int id)
        {
            
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            if (typeof(T)==typeof(Employee))
            {
                return   (IEnumerable<T>) await _dbContext.Employees.Include(e=>e.Department).ToListAsync();
            }else
            return await _dbContext.Set<T>().ToListAsync();
        }

        public void update(T item)
        
        => _dbContext.Set<T>().Update(item);
        
    }
}
