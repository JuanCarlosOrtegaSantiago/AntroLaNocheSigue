using AntroLaNocheSigue.COMMON.Entidades;
using AntroLaNocheSigue.COMMON.Interfaces;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace AntroLaNocheSigue.BIZ
{
    public class ManejadorDeClientes : IManegadorDeClientes
    {
        IRepositorio<Cliente> repositorio;
        public ManejadorDeClientes(IRepositorio<Cliente> repositorio)
        {
            this.repositorio = repositorio;
        }
        public List<Cliente> Listar => repositorio.listar;

        public bool Agregar(Cliente Entidad)
        {
            return repositorio.Crear(Entidad);
        }

        public bool Editar(Cliente entidad)
        {
            return repositorio.Editar(entidad);
        }

        public bool Eliminar(ObjectId Id)
        {
            return repositorio.Eliminar(Id);
        }
    }
}
