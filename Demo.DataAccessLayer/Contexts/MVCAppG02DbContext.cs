using Demo.DataAccessLayer.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccessLayer.Contexts
{
    public class MVCAppG02DbContext :IdentityDbContext<ApplicationUser>
    {

        public MVCAppG02DbContext(DbContextOptions<MVCAppG02DbContext> options):base(options) 
        {

        }

    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    => optionsBuilder.UseSqlServer("Server=.;Database= MVCAppG02Db;Trusted_Connection = true");

        public DbSet<Department> Departments { get; set; }

        public DbSet<Employee> Employees { get; set; }

        //public DbSet<IdentityUser> Users { get; set; }

        //public DbSet<IdentityRole> Roles { get; set; }

    }
}
