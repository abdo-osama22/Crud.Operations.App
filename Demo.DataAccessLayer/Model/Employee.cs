using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccessLayer.Model
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
       
        public string Name { get; set; }
  
        public int Age { get; set; }
  

        [DataType(DataType.Currency)]
        public decimal salary { get; set; }
        public bool IsActive { get; set; }

        public string  Email { get; set; }
 
        public string PhoneNumber { get; set; }

        public DateTime HireDate { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.Now;


        public string ImageName { get; set; }

        public int? DepartmentId { get; set; }


        //Navigational property 1
        public Department Department { get; set; }




    }
}
