using SW.Entities;
using SW.Services.Authentication;
using SW.Services.Cancellation;
using SW.Services.Pdf;
using SW.Services.Stamp;
using SW.Services.Storage;

namespace SW.Helpers
{
    internal class ResponseHelper
    {
        internal static string GetErrorDetail(Exception ex)
        {
            if (ex.InnerException != null)
                return ex.InnerException.Message;
            else
                return ex.StackTrace?.Trim() ?? String.Empty;
        }
    }
}