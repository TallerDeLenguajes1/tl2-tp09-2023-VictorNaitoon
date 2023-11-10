using Kanban.Models;

namespace Kanban.Repository
{
    public interface ITableroRepository
    {
        public void Create(Tablero tablero);
        public void Update(int idTablero,  Tablero tablero);
        public Tablero Get(int idTablero);
        public List<Tablero> GetAll();
        public List<Tablero> GetAllTableros(int idUsuario);
        public void Delete(int idTablero);
    }
}
