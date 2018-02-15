using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace biblioteca.Lib.Configuracao
{
    public static class Configuracoes
    {
        public static string MongoDbConnection => ConfigurationManager.AppSettings["MongoDbConnection"];
        public static string MongoDbDatabase => ConfigurationManager.AppSettings["MongoDbDatabase"];
    }
}
