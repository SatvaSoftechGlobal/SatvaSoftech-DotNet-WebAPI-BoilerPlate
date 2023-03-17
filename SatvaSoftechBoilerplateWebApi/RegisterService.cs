using SatvaSoftechBoilerplate.Data;
using SatvaSoftechBoilerplate.Service;
using Microsoft.Extensions.DependencyInjection;
using SatvaSoftechBoilerplateWebApi.Logger;
using System;
using System.Collections.Generic;
using SatvaSoftechBoilerplate.Service.Services.JWTAuthentication;
using SatvaSoftechBoilerplate.Service.Services.Account;
using SatvaSoftechBoilerplate.Data.DBRepository.Account;
using SatvaSoftechBoilerplate.Services.JWTAuthentication;

namespace SatvaSoftechBoilerplateWebApi
{
    public static class RegisterService
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            Configure(services, DataRegister.GetTypes());
            Configure(services, ServiceRegister.GetTypes());
        }

        private static void Configure(IServiceCollection services, Dictionary<Type, Type> types)
        {
            foreach (var type in types)
                services.AddScoped(type.Key, type.Value);
        }

        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
            services.AddSingleton<IJWTAuthenticationService, JWTAuthenticationService>();
        }
    }
}
