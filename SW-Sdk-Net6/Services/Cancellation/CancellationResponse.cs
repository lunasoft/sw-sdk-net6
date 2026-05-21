using SW.Entities;
using System.Runtime.Serialization;

namespace SW.Services.Cancellation
{
    public class CancellationResponse : Response
    {
        public CancellationData Data { get; set; }
    }
    public partial class CancellationData
    {
        public string Acuse { get; set; }
        public Dictionary<string, string> Uuid { get; set; }
    }
}