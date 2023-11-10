using Kanban.Models;
using Kanban.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Kanban.Controllers
{
    public class TareaController : ControllerBase
    {
        private readonly ILogger<TareaController> _logger;
        private ITareaRepository _repository;

        public TareaController(ILogger<TareaController> logger)
        {
            _logger = logger;
            _repository = new TareaRepository();
        }

        [HttpPost("CreateTarea")]
        public ActionResult<Tarea> Create(int idTablero, Tarea tarea)
        {
            Tarea nuevaTarea = _repository.Create(idTablero, tarea);
            return Ok(nuevaTarea);
        }

        [HttpGet("GetTareaByID")]
        public ActionResult<Tarea> GetTarea(int id)
        {
            Tarea tarea = _repository.Get(id);
            return Ok(tarea);
        }

        [HttpGet("GetAllByTablero")]
        public ActionResult<List<Tarea>> GetTareaByTablero(int idTablero)
        {
            List<Tarea> tareas = _repository.GetAllPorTablero(idTablero);
            return Ok(tareas);
        }

        [HttpGet("GetAllByUsuario")]
        public ActionResult<List<Tarea>> GetTareaByUsuario(int idUsuario)
        {
            List<Tarea> tareas = _repository.GetAllPorUsuario(idUsuario);
            return Ok(tareas);
        }

        [HttpPut("UpdateTarea")]
        public ActionResult Update(int idTarea, Tarea tarea)
        {
            _repository.Update(idTarea, tarea);
            return Ok();
        }

        [HttpDelete("DeleteTarea")]
        public ActionResult Delete(int idTarea)
        {
            _repository.Delete(idTarea);
            return Ok();
        }

        [HttpPut("AsiganarUsuarioATarea")]
        public ActionResult AsignarUsuarioATarea(int idUsuario, int idTarea)
        {
            _repository.AsignarUsuarioATarea(idUsuario, idTarea);
            return Ok();
        }
    }
}
