using AntroLaNocheSigue.COMMON.Entidades;
using AntroLaNocheSigue.COMMON.Interfaces;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AntroLaNocheSigue.BIZ
{
    public class ManejadorDeContrasena : IManejadorDeContrasena
    {
        IRepositorio<Contrasena> repositorio;
        public ManejadorDeContrasena(IRepositorio<Contrasena> repositorio)
        {
            this.repositorio = repositorio;
        }
        public List<Contrasena> Listar => repositorio.listar;

        public bool Agregar(Contrasena Entidad)
        {
            return repositorio.Crear(Entidad);
        }

        public Contrasena buscaPorId(ObjectId id)
        {
            return Listar.Where(e=>e.Id==id).SingleOrDefault();
        }

        public bool Editar(Contrasena entidad)
        {
            return repositorio.Editar(entidad);
        }

        public bool Eliminar(ObjectId Id)
        {
            return repositorio.Eliminar(Id);
        }
    }
}
