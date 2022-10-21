using SW.Handlers;
using SW.Helpers;

namespace SW.Services.Authentication
{
    internal class AuthenticationResponseHandler : ResponseHandler<AuthenticationResponse>
    {
        internal AuthenticationResponse HandleException(Exception ex)
        {
            return ResponseHelper.ToAuthenticationResponse(ex);
        }
    }
}