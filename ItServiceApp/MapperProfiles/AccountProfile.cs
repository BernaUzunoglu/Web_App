using AutoMapper;
using ItServiceApp.Models.Identity;
using ItServiceApp.ViewModel;

namespace ItServiceApp.MapperProfiles
{
    public class AccountProfile:Profile
    {
        public AccountProfile()
        {
            CreateMap<ApplicationUser,UserProfileViewModel>().ReverseMap();
            // CreateMap<UserProfileViewModel,ApplicationUser>()  // Yukarda ReverseMap() işlemi yapıldığı için 
        }
    }
}
