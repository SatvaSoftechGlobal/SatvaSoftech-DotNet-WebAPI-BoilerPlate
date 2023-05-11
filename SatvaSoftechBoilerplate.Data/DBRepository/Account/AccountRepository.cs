using Dapper;
using Microsoft.Extensions.Options;
using SatvaSoftechBoilerplate.Common.Helpers;
using SatvaSoftechBoilerplate.Model.Config;
using SatvaSoftechBoilerplate.Model.ViewModels.Login;
using System.Data;

namespace SatvaSoftechBoilerplate.Data.DBRepository.Account
{
    public class AccountRepository : BaseRepository, IAccountRepository
    {        
        #region Constructor
        public AccountRepository(IOptions<DataConfig> dataConfig) : base(dataConfig)
        {
        }
        #endregion

        #region Post
        public async Task<LoginResponseModel> LoginUser(LoginRequestModel model)
        {
            var param = new DynamicParameters();
            param.Add("@EmailId", model.EmailId);
            param.Add("@Password", model.Password);
            return await QueryFirstOrDefaultAsync<LoginResponseModel>(StoredProcedures.LoginUser, param, commandType: CommandType.StoredProcedure);
        }
        #endregion
    }
}
