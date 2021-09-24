using AutoMapper;
using CoreTraining.Models;
using CoreTraining.ViewModels;

namespace CoreTraining.Profiles
{
    public class HubProfile : Profile
    {
        public HubProfile()
        {
            CreateMap<Activity, ActivityViewModel>();
            CreateMap<Property, PropertyViewModel>();
            CreateMap<Address, AddressViewModel>();
        }
    }
}