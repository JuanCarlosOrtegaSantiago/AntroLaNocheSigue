using AntroLaNocheSigue.COMMON.Entidades;
using AntroLaNocheSigue.COMMON.Interfaces;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace AntroLaNocheSigue.BIZ
{
    public class ManejadorDeClienteVip : IManejadorDeClientesVip
    {
        IRepositorio<ClienteVip> repositorio;
        public ManejadorDeClienteVip(IRepositorio<ClienteVip> repositorio)
        {
            this.repositorio = repositorio;
        }
        public List<ClienteVip> Listar => repositorio.listar;

        public bool Agregar(ClienteVip Entidad)
        {
            return repositorio.Crear(Entidad);
        }

        public bool Editar(ClienteVip entidad)
        {
            return repositorio.Editar(entidad);
        }

        public bool Eliminar(ObjectId Id)
        {
            return repositorio.Eliminar(Id);
        }
    }
}
