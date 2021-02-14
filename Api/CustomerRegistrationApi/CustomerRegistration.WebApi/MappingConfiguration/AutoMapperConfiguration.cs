using CustomerRegistration.Application.Mappings;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CustomerRegistration.WebApi.MappingConfiguration
{
    public static class AutoMapperConfiguration
    {
        public static void  AddAutoMapperConfiguration(this IServiceCollection services)
        {
            if (services is null)
                throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(DomainToViewModelMappingProfile),
                typeof(ViewModelToDomainMappingProfile));
        }
    }
}