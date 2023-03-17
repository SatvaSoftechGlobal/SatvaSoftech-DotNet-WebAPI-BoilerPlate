using SatvaSoftechBoilerplate.Model.ViewModels.Login;
using SatvaSoftechBoilerplate.Data.DBRepository.Account;

namespace SatvaSoftechBoilerplate.Service.Services.Account
{
    public class AccountService : IAccountService
    {
        #region Fields
        private readonly IAccountRepository _repository;
        #endregion

        #region Construtor
        public AccountService(IAccountRepository repository)
        {
            _repository = repository;
        }
        #endregion

        #region Post
        public async Task<LoginResponseModel> LoginUser(LoginRequestModel model)
        {
            return await _repository.LoginUser(model);
        } 
        #endregion
    }
}
