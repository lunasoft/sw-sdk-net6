using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW.Services.Cancelation
{
    public class CancelationRequest
    {
        /// <summary>
        /// RFC del emisor.
        /// </summary>
        public string rfc { get; set; }
        /// <summary>
        /// Folio del comprobante a cancelar.
        /// </summary>
        public Guid uuid { get; set; }
        /// <summary>
        /// Motivo de cancelación.
        /// </summary>
        public string motivo { get; set; }
        /// <summary>
        /// Folio de sustitucion.
        /// </summary>
        public Guid? folioSustitucion { get; set; }
    }
}
