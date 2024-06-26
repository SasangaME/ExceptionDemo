﻿using ExceptionDemo.Repositories;
using ExceptionDemo.Services;

namespace ExceptionDemo.Configs
{
    public static class ServiceResolution
    {
        public static IServiceCollection AddConfigServices(this IServiceCollection services)
        {
            return services
                .AddSingleton<IPersonRepository, PersonRepository>()
                .AddScoped<IPersonService, PersonService>();
        }
    }
}
