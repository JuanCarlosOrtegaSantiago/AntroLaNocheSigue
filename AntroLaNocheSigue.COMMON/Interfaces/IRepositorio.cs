using AntroLaNocheSigue.COMMON.Entidades;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace AntroLaNocheSigue.COMMON.Interfaces
{
    public interface IRepositorio<T> where T:Base
    {
        bool Crear(T entidad);
        bool Editar(T entidad);
        bool Eliminar(ObjectId Id);
        List<T> listar { get; }


    }
}
