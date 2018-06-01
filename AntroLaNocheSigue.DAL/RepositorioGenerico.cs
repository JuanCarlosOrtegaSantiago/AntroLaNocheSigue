using AntroLaNocheSigue.COMMON.Entidades;
using AntroLaNocheSigue.COMMON.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace AntroLaNocheSigue.DAL
{
    public class RepositorioGenerico<T> : IRepositorio<T> where T:Base

    {
        private MongoClient client;
        private IMongoDatabase db;

        public RepositorioGenerico()
        {
            client = new MongoClient(new MongoUrl("mongodb://Erasmo:Erasmo1234@ds115350.mlab.com:15350/antrolanochesigue"));
            db = client.GetDatabase("antrolanochesigue");
        }
        private IMongoCollection<T> collection()
        {
            return db.GetCollection<T>(typeof(T).Name);
        }

        public List<T> listar => collection().AsQueryable().ToList();

        public bool Crear(T entidad)
        {
            try
            {
                collection().InsertOne(entidad);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Editar(T entidad)
        {
            try
            {
                return collection().ReplaceOne(p=> p.Id== entidad.Id,entidad).ModifiedCount==1;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public bool Eliminar(ObjectId Id)
        {
            try
            {
                return collection().DeleteOne(p => p.Id == Id).DeletedCount == 1;

            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
