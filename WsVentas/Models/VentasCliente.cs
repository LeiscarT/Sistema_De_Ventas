using System;
using System.Collections.Generic;

#nullable disable

namespace WsVentas.Models
{
    public partial class VentasCliente
    {
        public VentasCliente()
        {
            ConceptoVenta = new HashSet<ConceptoVentum>();
        }

        public long Id { get; set; }
        public DateTime Fecha { get; set; }
        public int IdCliente { get; set; }
        public decimal Total { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual ICollection<ConceptoVentum> ConceptoVenta { get; set; }
    }
}
