using biblioteca.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace biblioteca.Repositorio.Base
{
    public interface IRepositorio<TEntity> where TEntity : TIdentificador
    {
        string Create(TEntity model);
        TEntity Get(string id);
        TEntity Update(string id, TEntity model);
        void Delete(TEntity entity);
        IEnumerable<TEntity> List();
    }
}