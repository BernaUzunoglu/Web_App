using AutoMapper;
using ItServiceApp.Models.Entities;
using ItServiceApp.ViewModel;
//using ItServiceApp.ViewModels;

namespace ItServiceApp.MapperProfiles
{
    public class SubscriptionProfiles : Profile
    {
        public SubscriptionProfiles()
        {
            CreateMap<SubscriptionType, SubscriptionTypeViewModel>().ReverseMap();
            CreateMap<Address, AddressViewModel>().ReverseMap();

        }
    }
}