using System;
using System.Collections.Generic;

#nullable disable

namespace WsVentas.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            VentasClientes = new HashSet<VentasCliente>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<VentasCliente> VentasClientes { get; set; }
    }
}
