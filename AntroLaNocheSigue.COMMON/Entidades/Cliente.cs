using System;
using System.Collections.Generic;
using System.Text;

namespace AntroLaNocheSigue.COMMON.Entidades
{
    public class Cliente:Persona
    {
        public List<DateTime?> HoraDeEntrada { get; set; }
    }
}
