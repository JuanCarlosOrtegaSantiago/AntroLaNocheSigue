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
        IRepositorio<Empleado> repositorio;
        public ManejadorDeEmpleados(IRepositorio<Empleado> repositorio)
        {
            this.repositorio = repositorio;
        }
        public List<Empleado> Listar => repositorio.listar;

        public bool Agregar(Empleado Entidad)
        {
            return repositorio.Crear(Entidad);
        }

        public bool Editar(Empleado entidad)
        {
            return repositorio.Editar(entidad);
        }

        public bool Eliminar(ObjectId Id)
        {
            return repositorio.Eliminar(Id);
        }
    }
}
