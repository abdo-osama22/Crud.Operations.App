using AutoMapper;
using Demo.prestentaionlayer.Models;
using Microsoft.AspNetCore.Identity;

namespace Demo.prestentaionlayer.MappingProfiles
{
    public class RoleProfile :Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleViewModel, IdentityRole>()
                .ForMember(d => d.Name, O => O.MapFrom(s => s.RoleName)).ReverseMap();
        }

    }
}
