using AntroLaNocheSigue.COMMON.Entidades;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace AntroLaNocheSigue.COMMON.Interfaces
{
    public interface IManejadorDeReguistroDeEntradas<T> where T : Base
    {
        bool Agregar(T Entidad);
        List<T> Listar { get; }
        bool Eliminar(ObjectId Id);
        bool Editar(T entidad);
    }
}
