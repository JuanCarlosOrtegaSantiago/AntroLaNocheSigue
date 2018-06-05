using System;
using System.Collections.Generic;
using System.Text;

namespace AntroLaNocheSigue.COMMON.Entidades
{
    public class Contrasena:Base
    {
        public string usuario { get; set; }
        public string Contrasenas { get; set; }
        public override string ToString()
        {
            return string.Format("{0}",usuario);
        }
    }
}
