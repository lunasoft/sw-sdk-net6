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
        internal static Response ToResponse(Exception ex)
        {
            return new()
            {
                Status = "error",
                Message = ex.Message,
                MessageDetail = GetErrorDetail(ex)
            };
        }
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
        internal static CancellationResponse ToCancelationResponse(Exception ex)
        {
            return new CancellationResponse()
            {
                Status = "error",
                Message = ex.Message,
                MessageDetail = GetErrorDetail(ex)
            };
        }
        internal static StorageResponse ToStorageResponse(Exception ex)
        {
            return new StorageResponse()
            {
                Status = "error",
                Message = ex.Message,
                MessageDetail = GetErrorDetail(ex)
            };
        }
        internal static StorageExtraResponse ToStorageExtraResponse(Exception ex)
        {
            return new StorageExtraResponse()
            {
                Status = "error",
                Message = ex.Message,
                MessageDetail = GetErrorDetail(ex)
            };
        }
        internal static PdfResponse ToPdfResponse(Exception ex)
        {
            return new PdfResponse()
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
                return ex.StackTrace ?? String.Empty;
        }
    }
}