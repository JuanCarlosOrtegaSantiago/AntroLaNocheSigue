using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace AntroLaNocheSigue.COMMON.Entidades
{
    public abstract class Base
    {
        public ObjectId Id { get; set; }
    }
}
