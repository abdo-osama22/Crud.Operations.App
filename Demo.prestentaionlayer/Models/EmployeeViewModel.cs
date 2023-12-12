using Demo.DataAccessLayer.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Demo.prestentaionlayer.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name Is Required !!")]
        [MaxLength(50)]
        [MinLength(5)]
        public string Name { get; set; }
        [Range(22, 30)]
        public int Age { get; set; }


        
        public decimal salary { get; set; }
        public bool IsActive { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }

        public DateTime HireDate { get; set; }

        public IFormFile  Image { get; set; }
        public string ImageName  { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.Now;


        public int? DepartmentId { get; set; }


        //Navigational property 1
        public Department Department { get; set; }


    }
}
