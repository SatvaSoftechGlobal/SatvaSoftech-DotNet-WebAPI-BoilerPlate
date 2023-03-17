using SatvaSoftechBoilerplate.Model.ViewModels.Login; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatvaSoftechBoilerplate.Service.Services.Account
{
    public interface IAccountService
    {
        #region Post
        Task<LoginResponseModel> LoginUser(LoginRequestModel model); 
        #endregion
    }
}
