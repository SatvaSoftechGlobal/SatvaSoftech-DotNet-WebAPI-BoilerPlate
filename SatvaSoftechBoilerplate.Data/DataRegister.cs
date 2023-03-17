using SatvaSoftechBoilerplate.Data.DBRepository.Account;
using System;
using System.Collections.Generic;

namespace SatvaSoftechBoilerplate.Data
{
    public static class DataRegister
    {
        public static Dictionary<Type, Type> GetTypes()
        {
            var dataDictionary = new Dictionary<Type, Type>
            {
                { typeof(IAccountRepository), typeof(AccountRepository) }
            };
            return dataDictionary;
        }
    }
}
