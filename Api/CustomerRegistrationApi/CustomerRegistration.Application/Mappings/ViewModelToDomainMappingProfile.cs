using AutoMapper;
using CustomerRegistration.Application.ViewModels;
using CustomerRegistration.Domain.Entities;

namespace CustomerRegistration.Application.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CustomerViewModel, Customer>();
        }
    }
}