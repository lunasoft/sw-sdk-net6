using SW.Handlers;
using SW.Helpers;
using SW.Services.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
