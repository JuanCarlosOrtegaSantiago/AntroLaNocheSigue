using System;
using System.Collections.Generic;
using System.Text;

namespace AntroLaNocheSigue.COMMON.Entidades
{
    public class ReguistroDeEntradas:Base
    {
        public Empleado Empleado { get; set; }
        public List<Cliente> Clientes { get; set; }
        public DateTime FechaDeEntarda { get; set; }
    }
}
