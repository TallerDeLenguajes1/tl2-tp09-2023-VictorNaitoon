using Kanban.Models;
using Kanban.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Kanban.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly ILogger<UsuarioController> _logger;
        private UsuarioRepository _usuario;

        public UsuarioController(ILogger<UsuarioController> logger)
        {
            _logger = logger;
            _usuario = new UsuarioRepository();
        }

        [HttpPost("Create")]
        public ActionResult Create(Usuario usuario)
        {
            _usuario.Create(usuario);
            return Ok();
        }

        [HttpGet("GetAllUsuers")]
        public ActionResult<List<Usuario>> GetAll()
        {
            return _usuario.GetAll();
        }

        [HttpGet("GetUser")]
        public ActionResult<Usuario> Get(int id)
        {
            Usuario usuario = _usuario.GetUsuario(id);
            return Ok(usuario);
        }

        [HttpPut("Update")]
        public ActionResult Update(int id, Usuario usuario)
        {
            _usuario.Update(id, usuario);
            return Ok();
        }

        [HttpDelete("Delete")]
        public ActionResult Delete(int id)
        {
            _usuario.Delete(id);
            return Ok();
        }
    }
}
