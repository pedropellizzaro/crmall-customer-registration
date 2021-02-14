using AutoMapper;
using CustomerRegistration.Application.ViewModels;
using CustomerRegistration.Domain.Entities;

namespace CustomerRegistration.Application.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Customer, CustomerViewModel>();
        }
    }
}