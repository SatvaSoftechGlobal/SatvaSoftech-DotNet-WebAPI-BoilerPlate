using SatvaSoftechBoilerplate.Service.Services.Account;
using System;
using System.Collections.Generic;

namespace SatvaSoftechBoilerplate.Service
{
    public static class ServiceRegister
    {
        public static Dictionary<Type, Type> GetTypes()
        {
            var serviceDictonary = new Dictionary<Type, Type>
            {
                { typeof(IAccountService), typeof(AccountService) }
            };
            return serviceDictonary;
        }
    }
}
