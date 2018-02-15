using biblioteca.Models;
using biblioteca.Repositorio.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using biblioteca.Lib.Exceptions;

namespace biblioteca.Repositorio
{
    public class LivroRepositorio : MongoDBRepositorio<Livro>
    {
        private static LivroRepositorio _instance;
        public static LivroRepositorio Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new LivroRepositorio();
                }
                return _instance;
            }
        }

        private LivroRepositorio() : base() { }

        public new IEnumerable<Livro> List()
        {
            try
            {
                return base.GetCollection().AsQueryable().OrderBy(o => o.Titulo).ToList();
            }
            catch (Exception e)
            {
                throw new MongoDbException(e);
            }
        }

    }
}