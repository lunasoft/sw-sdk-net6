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
        public string Rfc { get; set; }
        /// <summary>
        /// Folio del comprobante a cancelar.
        /// </summary>
        public Guid Uuid { get; set; }
        /// <summary>
        /// Motivo de cancelación.
        /// </summary>
        public string Motivo { get; set; }
        /// <summary>
        /// Folio de sustitucion.
        /// </summary>
        public Guid? FolioSustitucion { get; set; }
    }
}
