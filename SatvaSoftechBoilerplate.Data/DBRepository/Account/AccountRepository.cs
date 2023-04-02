using SatvaSoftechBoilerplate.Model.Config; 
using SatvaSoftechBoilerplate.Model.ViewModels.Login; 
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Data;
using SatvaSoftechBoilerplate.Common.Helpers;

namespace SatvaSoftechBoilerplate.Data.DBRepository.Account
{
    public class AccountRepository :BaseRepository, IAccountRepository
    {
        #region Fields
        private IConfiguration _config;
        #endregion

        #region Constructor
        public AccountRepository(IConfiguration config, IOptions<DataConfig> dataConfig) : base(dataConfig)
        {
            _config = config;
        }
        #endregion

        #region Post
        public async Task<LoginResponseModel> LoginUser(LoginRequestModel model)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@EmailId", model.EmailId);
                param.Add("@Password", model.Password);
                return await QueryFirstOrDefaultAsync<LoginResponseModel>(StoredProcedures.LoginUser, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw; // :) Good Stuff!
            }
        } 
        #endregion
    }
}
