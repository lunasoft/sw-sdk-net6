using SW.Entities;
using System.Runtime.Serialization;

namespace SW.Services.Cancellation
{
    public class CancellationResponse : Response
    {
        [DataMember]
        public CancellationData Data { get; set; }
    }
    public partial class CancellationData
    {
        [DataMember]
        public string Acuse { get; set; }
        [DataMember]
        public Dictionary<string, string> Uuid { get; set; }
    }
}