using SW.Handlers;
using SW.Helpers;
using SW.Services.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW.Services.Stamp
{
    internal class StampResponseHandlerV1 : ResponseHandler<StampResponseV1>
    {
        internal StampResponseV1 HandleException(Exception ex)
        {
            return ResponseHelper.ToStampResponseV1(ex);
        }
    }
    internal class StampResponseHandlerV2 : ResponseHandler<StampResponseV2>
    {
        internal StampResponseV2 HandleException(Exception ex)
        {
            return ResponseHelper.ToStampResponseV2(ex);
        }
    }
    internal class StampResponseHandlerV3 : ResponseHandler<StampResponseV3>
    {
        internal StampResponseV3 HandleException(Exception ex)
        {
            return ResponseHelper.ToStampResponseV3(ex);
        }
    }
    internal class StampResponseHandlerV4 : ResponseHandler<StampResponseV4>
    {
        internal StampResponseV4 HandleException(Exception ex)
        {
            return ResponseHelper.ToStampResponseV4(ex);
        }
    }
}
