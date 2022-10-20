using SW.Services.Authentication;
using SW.Services.Cancelation;
using SW.Services.IssueJson;
using SW.Services.Stamp;
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
                Status = "error",
                Message = ex.Message,
                MessageDetail = GetErrorDetail(ex)
            };
        }
        internal static StampResponseV1 ToStampResponseV1(Exception ex)
        {
            return new StampResponseV1()
            {
                Status = "error",
                Message = ex.Message,
                MessageDetail = GetErrorDetail(ex)
            };
        }
        internal static StampResponseV2 ToStampResponseV2(Exception ex)
        {
            return new StampResponseV2()
            {
                Status = "error",
                Message = ex.Message,
                MessageDetail = GetErrorDetail(ex)
            };
        }
        internal static StampResponseV3 ToStampResponseV3(Exception ex)
        {
            return new StampResponseV3()
            {
                Status = "error",
                Message = ex.Message,
                MessageDetail = GetErrorDetail(ex)
            };
        }
        internal static StampResponseV4 ToStampResponseV4(Exception ex)
        {
            return new StampResponseV4()
            {
                Status = "error",
                Message = ex.Message,
                MessageDetail = GetErrorDetail(ex)
            };
        }
        internal static CancelationResponse ToCancelationResponse(Exception ex)
        {
            return new CancelationResponse()
            {
                Status = "error",
                Message = ex.Message,
                MessageDetail = GetErrorDetail(ex)
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
