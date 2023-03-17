using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SatvaSoftechBoilerplate.Model.ViewModels.Token
{
    public class UserTokenModel
    {
        public long UserId { get; set; }
        public long RoleId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? EmailId { get; set; }
        public int UserLoginId { get; set; }
        public int LoginHistoryId { get; set; }
        public string? UserName { get; set; }
        public DateTime TokenValidTo { get; set; }
        public long CompanyId { get; set; }
    }
}
