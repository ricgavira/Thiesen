﻿using Microsoft.Extensions.DependencyInjection;
using Thiesen.Application.Mapping;

namespace Thiesen.Infra.IoC.AutoMapper
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfiles));

            return services;
        };
    }
}
