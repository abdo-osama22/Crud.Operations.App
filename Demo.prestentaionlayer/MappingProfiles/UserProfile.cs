using AutoMapper;
using Demo.DataAccessLayer.Model;
using Demo.prestentaionlayer.Models;

namespace Demo.prestentaionlayer.MappingProfiles
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<ApplicationUser, UserViewModel>().ReverseMap();
        }

    }
}
