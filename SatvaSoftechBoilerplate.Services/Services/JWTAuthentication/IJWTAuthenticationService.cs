using SatvaSoftechBoilerplate.Model.ViewModels.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatvaSoftechBoilerplate.Service.Services.JWTAuthentication
{
    public interface IJWTAuthenticationService
    {
        AccessTokenModel GenerateToken(UserTokenModel userToken, string JWT_Secret, int JWT_Validity_Mins);
        UserTokenModel GetUserTokenData(string jwtToken);
    }
}
