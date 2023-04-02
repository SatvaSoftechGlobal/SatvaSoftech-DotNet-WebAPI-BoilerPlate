using SatvaSoftechBoilerplate.Model.ViewModels.Token;
using SatvaSoftechBoilerplate.Services.JWTAuthentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using System;
using System.IO;
using System.Threading.Tasks;
using SatvaSoftechBoilerplate.Service.Services.JWTAuthentication;

namespace SatvaSoftechBoilerplateWebApi.Middleware
{
    public class RequestResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;
        private readonly IJWTAuthenticationService _jwtAuthenticationService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="next"></param>
        /// <param name="memoryCache"></param>
        public RequestResponseLoggingMiddleware(RequestDelegate next, 
            Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment, IJWTAuthenticationService jwtAuthenticationService)
        {
            _next = next;
            _hostingEnvironment = hostingEnvironment;
            _jwtAuthenticationService = jwtAuthenticationService;
        }

        /// <summary>
        /// Invoke on every request response
        /// </summary>
        /// <param name="context"></param>
        /// <param name="settingService"></param>
        public async Task Invoke(HttpContext context)
        {                        
            try
            {
                // Delete files from folder for logs of request and response older than 7 days.
                DeleteOldReqResLogFiles();
                
                // Check JWT Token validity expiry
                string jwtToken = context.Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
                if (!string.IsNullOrEmpty(jwtToken))
                {
                    UserTokenModel userTokenModel = _jwtAuthenticationService.GetUserTokenData(jwtToken);

                    if (userTokenModel != null)
                    {                        
                        if (userTokenModel.TokenValidTo < DateTime.UtcNow.AddMinutes(1))
                        {
                            context.Response.StatusCode = 401;
                            return;
                        }
                    }
                }

                await _next(context);
            }
            catch (Exception ex)
            {
                // Add error logs in folder
                AddExceptionLogsToFiles(ex, context);
            }
        }

        /// <summary>
        /// Delete files from error logs folder which is older than 7 days.//Very good stuff!
        /// </summary>
        public void DeleteOldReqResLogFiles() {
            var directoryPath = Path.Combine(_hostingEnvironment.ContentRootPath, "ReqResLog");
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            string[] files = Directory.GetFiles(directoryPath);

            foreach (string file in files)
            {
                FileInfo fi = new FileInfo(file);
                if (fi.LastAccessTime < DateTime.Now.AddDays(-7))
                {
                    fi.Delete();
                }
            }
        }

        /// <summary>
        /// Add error logs in folder 
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="context"></param>
        public void AddExceptionLogsToFiles(Exception ex, HttpContext context) 
        {
            var exfilePath = Path.Combine(_hostingEnvironment.ContentRootPath, "ReqResLog", "Exception_" + Path.GetFileName(DateTime.Now.ToString("dd_MM_yyyy") + ".txt"));

            if (!File.Exists(exfilePath))
            {
                var myFile = File.Create(exfilePath);
                myFile.Close();
            }

            using StreamWriter sw = File.AppendText(exfilePath);
            sw.WriteLine("");
            sw.WriteLine("--------------------------------- " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt") + " ----------------------------------");
            sw.WriteLine("Requested URL: " + context.Request.Path.Value);
            sw.WriteLine("Exception: " + ex.Message);
            sw.WriteLine("Exception: " + ex.InnerException);
            if (ex.InnerException != null)
            {
                sw.WriteLine("Exception: " + ex.InnerException.InnerException);
            }
        }

    }
}
