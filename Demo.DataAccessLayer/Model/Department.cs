using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccessLayer.Model
{
    public class Department
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Code Is Required")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Name Is Required")]
        [MaxLength(50)]
        public string Name { get; set; }
        public DateTime DateOfCreation { get; set; }
        

        //navigational property [Many]
        public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
    }
}
