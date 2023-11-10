using Kanban.Models;
using Kanban.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Kanban.Controllers
{
    public class TableroController : Controller
    {
        private readonly ILogger<TableroController> _logger;
        private ITableroRepository _repository;

        public TableroController(ILogger<TableroController> logger)
        {
            _logger = logger;
            _repository = new TableroRepository();
        }

        [HttpPost("CreateTablero")]
        public ActionResult Create(Tablero tablero)
        {
            _repository.Create(tablero);
            return Ok();
        }

        [HttpGet("GetAllTableros")]
        public ActionResult<Tablero> GetAll()
        {
            List<Tablero> tableros = _repository.GetAll();
            return Ok(tableros);
        }

        [HttpGet("GetTablero")]
        public ActionResult<Tablero> GetTablero(int id)
        {
            Tablero tablero = _repository.Get(id);
            return Ok(tablero);
        }

        [HttpPut("UpdateTablero")]
        public ActionResult Update(int id, Tablero tablero)
        {
            _repository.Update(id, tablero);
            return Ok();
        }

        [HttpGet("GetTablerosByUserID")]
        public ActionResult<List<Tablero>> GetTableros(int idUsuario)
        {
            List<Tablero> tableros = _repository.GetAllTableros(idUsuario);
            return Ok(tableros);
        }

        [HttpDelete("DeleteTablero")]
        public ActionResult Delete(int idTablero)
        {
            _repository.Delete(idTablero);
            return Ok();    
        }
    }
}
