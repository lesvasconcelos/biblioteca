using biblioteca.Lib.Exceptions;
using biblioteca.Models;
using biblioteca.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;

namespace biblioteca.Controllers
{
    public class LivroController : ApiController
    {
        private LivroRepositorio LivroRepositorio => LivroRepositorio.Instance;

        // GET: api/livro
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(LivroRepositorio.List());
            }
            catch (ClientException e)
            {
                return BadRequest(e.Message);
            }
            catch (ServerException e)
            {
                return InternalServerError(e as Exception);
            }
        }

        // GET: api/livro/5
        public IHttpActionResult Get(string id)
        {
            try
            {
                var entity = LivroRepositorio.Get(id);
                
                return Ok(entity);
            }
            catch (ClientException e)
            {
                return BadRequest(e.Message);
            }
            catch (ServerException e)
            {
                return InternalServerError(e as Exception);
            }
        }

        // POST: api/livro
        public IHttpActionResult Post([FromBody]Livro model)
        {
            try
            {
                var id = LivroRepositorio.Create(model);

                return CreatedAtRoute("DefaultApi", new { id = id }, model);
            }
            catch (ClientException e)
            {
                return BadRequest(e.Message);
            }
            catch (ServerException e)
            {
                return InternalServerError(e as Exception);
            }
        }

        // PUT: api/livro/5
        public IHttpActionResult Put(string id, [FromBody]Livro model)
        {
            try
            {
                var entity = LivroRepositorio.Get(id);

                entity.Titulo = model.Titulo;
                entity.Autor = model.Autor;
                entity.Ano = model.Ano;

                LivroRepositorio.Update(id, entity);

                return Ok(entity);
            }
            catch (ClientException e)
            {
                return BadRequest(e.Message);
            }
            catch (ServerException e)
            {
                return InternalServerError(e as Exception);
            }
        }

        // DELETE: api/livro/5
        public IHttpActionResult Delete(string id)
        {
            try
            {
                var entity = LivroRepositorio.Get(id);

                LivroRepositorio.Delete(entity);

                return Ok();
            }
            catch (ClientException e)
            {
                return BadRequest(e.Message);
            }
            catch (ServerException e)
            {
                return InternalServerError(e as Exception);
            }
        }
        
        public IHttpActionResult Options()
        {
            return Ok();
        }
    }
}
