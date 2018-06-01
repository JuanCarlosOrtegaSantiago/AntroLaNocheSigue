using AntroLaNocheSigue.COMMON.Entidades;
using AntroLaNocheSigue.COMMON.Interfaces;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace AntroLaNocheSigue.BIZ
{
    public class ManejadorDeReguistroDeEntradas : IManejadorDeReguistroDeEntradas
    {
        IRepositorio<ReguistroDeEntradas> repositorio;
        public ManejadorDeReguistroDeEntradas(IRepositorio<ReguistroDeEntradas> repositorio)
        {
            this.repositorio = repositorio;
        }
        public List<ReguistroDeEntradas> Listar => repositorio.listar;

        public bool Agregar(ReguistroDeEntradas Entidad)
        {
            return repositorio.Crear(Entidad);
        }

        public bool Editar(ReguistroDeEntradas entidad)
        {
            return repositorio.Editar(entidad);
        }

        public bool Eliminar(ObjectId Id)
        {
            return repositorio.Eliminar(Id);
        }
    }
}
