using System;
using System.Collections.Generic;
using System.Text;

namespace AntroLaNocheSigue.COMMON.Entidades
{
    public abstract class Persona:Base
    {
        public string ClaveDeElector { get; set; }
        public string Nombre { get; set; }
        public string Domicilio { get; set; }
        public Byte[] Foto { get; set; }
    }
}
