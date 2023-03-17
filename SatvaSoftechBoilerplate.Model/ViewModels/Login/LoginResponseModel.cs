using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatvaSoftechBoilerplate.Model.ViewModels.Login
{    
    public class LoginResponseModel
    {       
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string EmailId { get; set; }
        public bool IsActive { get; set; }
    }

}
