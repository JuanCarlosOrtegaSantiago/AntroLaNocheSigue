using AntroLaNocheSigue.COMMON.Entidades;
using AntroLaNocheSigue.COMMON.Interfaces;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace AntroLaNocheSigue.BIZ
{
    public class ManejadorDeEmpleados : IManejadorDeEmpleado
    {
        IRepositorio<Trabajador> repositorio;
        public ManejadorDeEmpleados(IRepositorio<Trabajador> repositorio)
        {
            this.repositorio = repositorio;
        }
        public List<Trabajador> Listar => repositorio.listar;

        public bool Agregar(Trabajador Entidad)
        {
            return repositorio.Crear(Entidad);
        }

        public bool Editar(Trabajador entidad)
        {
            return repositorio.Editar(entidad);
        }

        public bool Eliminar(ObjectId Id)
        {
            return repositorio.Eliminar(Id);
        }
    }
}
