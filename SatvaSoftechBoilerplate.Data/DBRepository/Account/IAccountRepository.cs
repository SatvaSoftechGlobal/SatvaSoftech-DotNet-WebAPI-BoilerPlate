using SatvaSoftechBoilerplate.Model.ViewModels.Login; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatvaSoftechBoilerplate.Data.DBRepository.Account
{
    public interface IAccountRepository
    {
        #region Post
        Task<LoginResponseModel> LoginUser(LoginRequestModel model); 
        #endregion
    }
}
