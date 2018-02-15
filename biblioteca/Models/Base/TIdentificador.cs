using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using biblioteca.Models.Validacao;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace biblioteca.Models.Base
{
    public class TIdentificador : Validador
    {
        [BsonId]
        public ObjectId Id { get; set; }
    }
}