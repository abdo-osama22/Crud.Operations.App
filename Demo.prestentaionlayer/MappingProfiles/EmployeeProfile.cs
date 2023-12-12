
using AutoMapper;
using Demo.DataAccessLayer.Model;
using Demo.prestentaionlayer.Models;

namespace Demo.prestentaionlayer.MappingProfiles

{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeViewModel, Employee>().ReverseMap();
        }

    }
}
