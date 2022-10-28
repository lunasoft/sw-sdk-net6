using SW.Services.Cancellation;
using System.Net.Mail;

namespace SW.Helpers
{
    internal class ValidationHelper
    {
        internal static bool ValidateEmail(string[] emails)
        {
            try
            {
                emails.ToList().ForEach(l => new MailAddress(l));
            }
            catch
            {
                return false;
            }
            return true;
        }
        internal static bool ValidateCustomHeaders(string customId, string[] email, out string message)
        {
            if (String.IsNullOrEmpty(customId) || customId.Length > 100)
            {
                message = "El CustomId no es válido o no se especificó.";
                return false;
            }
            if (email != null)
            {
                if (email.Length <= 0 || !ValidationHelper.ValidateEmail(email))
                {
                    message = "El listado de correos no tiene un formato válido o está vacío.";
                    return false;
                }
                else if (email.Length > 5)
                {
                    message = "El header email contiene más de 5 correos.";
                    return false;
                }
            }
            message = String.Empty;
            return true;
        }
        internal static bool ValidateCancellationRequest(CancellationRequest request, out string message)
        {
            if (String.IsNullOrEmpty(request.Rfc))
            {
                message = "El RFC no es válido.";
                return false;
            }
            if (!new string[] { "01", "02", "03", "04" }.Contains(request.Motivo) || (request.FolioSustitucion != null && request.Motivo != "01"))
            {
                message = "El motivo de cancelación no es válido.";
                return false;
            }
            message = String.Empty;
            return true;
        }
    }
}
