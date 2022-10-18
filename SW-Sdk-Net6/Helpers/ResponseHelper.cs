using SW.Services.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW.Helpers
{
    internal class ResponseHelper
    {
        internal static AuthenticationResponse ToAuthenticationResponse(Exception ex)
        {
            return new AuthenticationResponse()
            {
                status = "error",
                message = ex.Message,
                messageDetail = GetErrorDetail(ex)
            };
        }
        private static string GetErrorDetail(Exception ex)
        {
            if (ex.InnerException != null)
                return ex.InnerException.Message;
            else
                return ex.StackTrace ?? "Error no clasificado.";
        }
    }
}
