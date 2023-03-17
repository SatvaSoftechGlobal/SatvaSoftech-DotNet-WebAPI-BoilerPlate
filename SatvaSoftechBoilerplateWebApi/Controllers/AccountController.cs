using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SatvaSoftechBoilerplate.Common.Helpers;
using SatvaSoftechBoilerplate.Model.Settings;
using SatvaSoftechBoilerplate.Model.ViewModels.Login;
using SatvaSoftechBoilerplate.Model.ViewModels.Token;
using SatvaSoftechBoilerplate.Service.Services.Account;
using SatvaSoftechBoilerplate.Service.Services.JWTAuthentication;
using SatvaSoftechBoilerplateWebApi.Logger;

namespace SatvaSoftechBoilerplateWebApi.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        #region Fields
        private readonly ILoggerManager _logger;
        private IAccountService _accountService;
        private readonly AppSettings _appSettings;
        private readonly IJWTAuthenticationService _jwtAuthenticationService;
        #endregion

        #region Constructor
        public AccountController(ILoggerManager logger,
                               IAccountService accountService,
                               IOptions<AppSettings> appSettings,
                               IJWTAuthenticationService jwtAuthenticationService)
        {
            _logger = logger;
            _accountService = accountService;
            _jwtAuthenticationService = jwtAuthenticationService;
            _appSettings = appSettings.Value;
        }
        #endregion

        #region Post
        /// <summary>
        /// User will login by passing emailid and password
        /// </summary>
        /// <param name="model">object with emailid and password details in request</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiPostResponse<LoginBaseReponseModel>> LoginUser([FromBody] LoginRequestModel model)
        {
            ApiPostResponse<LoginBaseReponseModel> response = new ApiPostResponse<LoginBaseReponseModel>();
            LoginBaseReponseModel loginBaseReponseModel = new LoginBaseReponseModel();

            try
            {                
                model.Password = EncryptionDecryption.GetEncrypt(model.Password);
                LoginResponseModel result = await _accountService.LoginUser(model);

                if (result != null && result.UserId > 0)
                {                    
                    UserTokenModel objTokenData = new UserTokenModel();
                    objTokenData.EmailId = model.EmailId;
                    objTokenData.UserId = result.UserId;
                    objTokenData.UserName = result.FullName;

                    AccessTokenModel objAccessTokenData = new AccessTokenModel();
                    objAccessTokenData = _jwtAuthenticationService.GenerateToken(objTokenData, _appSettings.JWT_Secret, _appSettings.JWT_Validity_Mins);
                      
                    AccessTokenResponseModel AccessToken = new AccessTokenResponseModel();
                    AccessToken.Token = objAccessTokenData.Token;
                    AccessToken.ExpiresOnUTC = objAccessTokenData.ExpiresOnUTC;

                    UserProfileModel UserProfile = new UserProfileModel();
                    UserProfile.UserId = result.UserId;
                    UserProfile.FullName = result.FullName;
                    UserProfile.EmailId = result.EmailId;

                    loginBaseReponseModel.AccessToken = AccessToken;
                    loginBaseReponseModel.UserProfile = UserProfile;

                    response.Success = true;
                    response.Message = ErrorMessages.LoginSuccess;
                }
                else
                {                    
                    response.Success = false;
                    response.Message = ErrorMessages.LoginError;
                }
                response.Data = loginBaseReponseModel;
                return response;
            }
            catch (Exception ex)
            {
                _logger.Information(ex.ToString());
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        #endregion
    }
}
