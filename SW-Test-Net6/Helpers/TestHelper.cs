using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW.Test.Helpers
{
    internal class TestHelper
    {
        public static string TestLog(string status, string message, string messageDetail)
        {
            return $"El resultado fue {status}, {message}, {messageDetail}";
        }
    }
}
