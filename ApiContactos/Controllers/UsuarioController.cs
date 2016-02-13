using System.Web.Http;
using System.Web.Http.Description;
using ApiContactos.Repositorios;
using ContactosModel.Model;
using Microsoft.Practices.Unity;

namespace ApiContactos.Controllers
{
    public class UsuarioController : ApiController
    {
        [Dependency]
        public UsuarioRepositorio UsuarioRepositorio { get; set; }
        
        [ResponseType(typeof(UsuarioModel))]
        public IHttpActionResult GetValido(string login, string password)
        {
            var data = UsuarioRepositorio.Validar(login, password);
            if (data == null) return NotFound();
            return Ok(data);
        }

        [ResponseType(typeof(UsuarioModel))]
        public IHttpActionResult GetTodos()
        {
            var data = UsuarioRepositorio.Obtener();
            if (data == null) return NotFound();
            return Ok(data);
        }

        [ResponseType(typeof(bool))]
        public IHttpActionResult GetUnico(string login)
        {
            var data = UsuarioRepositorio.IsUnico(login);
            return Ok(data);
        }

        [ResponseType(typeof(UsuarioModel))]
        public IHttpActionResult Post(UsuarioModel model)
        {
            var data = UsuarioRepositorio.Add(model);
            if (data == null) return BadRequest();
            return Ok(data);
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult Put(int id, UsuarioModel model)
        {
            var usuario = UsuarioRepositorio.Get(id);
            if (usuario == null || usuario.id != model.id) return NotFound();
            var data = UsuarioRepositorio.Update(model);
            if (data < 1) return BadRequest();
            return Ok();
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult Delete(int id)
        {
            var data = UsuarioRepositorio.BorrarIndividual(id);
            if (data < 1) return BadRequest();
            return Ok();
        }

        [ResponseType(typeof(void))]
        public IHttpActionResult Delete(UsuarioModel model) 
        {
            var data = UsuarioRepositorio.BorrarIndividual(model);
            if (data < 1) return BadRequest();
            return Ok();
        }
    }
}
