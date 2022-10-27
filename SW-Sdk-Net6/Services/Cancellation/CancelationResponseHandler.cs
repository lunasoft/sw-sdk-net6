using SW.Handlers;
using SW.Helpers;

namespace SW.Services.Cancellation
{
    internal class CancellationResponseHandler : ResponseHandler<CancellationResponse>
    {
        internal CancellationResponse HandleException(Exception ex)
        {
            return ResponseHelper.ToCancelationResponse(ex);
        }
    }
}