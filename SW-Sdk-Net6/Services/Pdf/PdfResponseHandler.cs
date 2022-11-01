using SW.Handlers;
using SW.Helpers;

namespace SW.Services.Pdf
{
    internal class PdfResponseHandler : ResponseHandler<PdfResponse>
    {
        internal PdfResponse HandleException(Exception ex)
        {
            return ResponseHelper.ToPdfResponse(ex);
        }
    }
}