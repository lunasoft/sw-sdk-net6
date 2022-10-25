using SW.Handlers;
using SW.Helpers;

namespace SW.Services.Cancelation
{
    internal class CancelationResponseHandler : ResponseHandler<CancelationResponse>
    {
        internal CancelationResponse HandleException(Exception ex)
        {
            return ResponseHelper.ToCancelationResponse(ex);
        }
    }
}