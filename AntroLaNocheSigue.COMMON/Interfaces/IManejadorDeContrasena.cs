using AntroLaNocheSigue.COMMON.Entidades;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace AntroLaNocheSigue.COMMON.Interfaces
{
    public interface IManejadorDeContrasena:IManejadorGenerico<Contrasena>
    {
        Contrasena buscaPorId(ObjectId Id);
    }
}
