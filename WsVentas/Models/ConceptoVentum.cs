﻿using System;
using System.Collections.Generic;

#nullable disable

namespace WsVentas.Models
{
    public partial class ConceptoVentum
    {
        public long Id { get; set; }
        public long IdVenta { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Importe { get; set; }
        public int IdProducto { get; set; }

        public virtual Producto IdProductoNavigation { get; set; }
        public virtual VentasCliente IdVentaNavigation { get; set; }
    }
}
