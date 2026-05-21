
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