using Kanban.Models;

namespace Kanban.Repository
{
    public interface IUsuarioRepository
    {
        public void Create(Usuario usuario);
        public void Update(int idUsuario, Usuario usuario);
        public List<Usuario> GetAll();
        public Usuario GetUsuario(int idUsuario);
        public void Delete(int idUsuario);
    }
}
