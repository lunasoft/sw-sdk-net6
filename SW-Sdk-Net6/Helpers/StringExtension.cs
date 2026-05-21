using System.Text;

namespace SW.Helpers
{
    internal static class StringExtension
    {
        internal static string ConvertToB64(this string str)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(str));
        }
        internal static string ConvertFromB64(this string b64)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(b64));
        }
    }
}