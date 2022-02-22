using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Clientes.Model
{
   
    public class Cliente
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }

        public string? TipoDocumento { get; set; }

        public string? Documento { get; set; }

        public string? RazonSocial { get; set; }

        public string? Proveedores { get; set; }

        public string? VentasUltimo { get; set; }
    }
}
