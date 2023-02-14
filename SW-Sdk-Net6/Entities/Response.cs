using System.Runtime.Serialization;

namespace SW.Entities
{
    public class Response
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string MessageDetail { get; set; }
    }
}