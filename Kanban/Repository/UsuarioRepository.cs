using Kanban.Models;
using System.Data.SQLite;

namespace Kanban.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string cadenaConexion = "Data Source=DB/kanban.db;Cache=Shared";

        public void Create(Usuario usuario)
        {
            var query = $"INSERT INTO usuario (nombre_de_usuario) VALUES (@nombre_de_usuario)";

            using (SQLiteConnection conexion = new SQLiteConnection(cadenaConexion))
            {
                conexion.Open();

                var command = new SQLiteCommand(query, conexion);

                command.Parameters.Add(new SQLiteParameter("@nombre_de_usuario", usuario.NombreDeUsuario));

                command.ExecuteNonQuery();

                conexion.Close();
            }
        }
        public List<Usuario> GetAll()
        {
            List<Usuario> usuarios = new List<Usuario>();
            var query = $"SELECT * FROM usuario;";

            using(SQLiteConnection conexion = new SQLiteConnection(cadenaConexion))
            {
                SQLiteCommand command = new SQLiteCommand(query, conexion);

                conexion.Open();

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var usuario = new Usuario();
                        usuario.Id = Convert.ToInt32(reader["id_usuario"]);
                        usuario.NombreDeUsuario = reader["nombre_de_usuario"].ToString();
                        usuarios.Add(usuario);
                    }
                }
                conexion.Close();
            }
            return usuarios;
        }
        public Usuario GetUsuario(int idUsuario)
        {
            Usuario usuario = new Usuario();

            var query = $"SELECT * FROM usuario WHERE id_usuario = {idUsuario}";

            using (SQLiteConnection conexion = new SQLiteConnection(cadenaConexion))
            {
                SQLiteCommand command = new SQLiteCommand(query, conexion);

                conexion.Open();

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        usuario.Id = Convert.ToInt32(reader["id_usuario"]);
                        usuario.NombreDeUsuario = reader["nombre_de_usuario"].ToString();
                    }
                }

                conexion.Close();
            }

            return usuario;
        }
        public void Update(int idUsuario, Usuario usuario)
        {
            using (SQLiteConnection conexion = new SQLiteConnection(cadenaConexion))
            {
                conexion.Open();

                SQLiteCommand command = conexion.CreateCommand();

                command.CommandText = $"UPDATE usuario SET nombre_de_usuario = @nombre WHERE id_usuario = @idUsuario";

                command.Parameters.Add(new SQLiteParameter("@idUsuario", usuario.Id));
                command.Parameters.Add(new SQLiteParameter("@nombre", usuario.NombreDeUsuario));

                command.ExecuteNonQuery();

                conexion.Close();
            }
        }

        public void Delete(int idUsuario)
        {
            using (SQLiteConnection conexion = new SQLiteConnection(cadenaConexion))
            {
                conexion.Open();

                SQLiteCommand command = conexion.CreateCommand();

                command.CommandText = $"DELETE FROM usuario WHERE id_usuario = @idUsuario";

                command.Parameters.Add(new SQLiteParameter("@idUsuario", idUsuario));

                command.ExecuteNonQuery();

                conexion.Close();
            }
        }
    }
}
