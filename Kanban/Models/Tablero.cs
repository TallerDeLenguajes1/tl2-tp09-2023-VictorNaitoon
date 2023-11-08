namespace Kanban.Models
{
    public class Tablero
    {
        public int IdTablero { get; set; }
        public int IdUsuarioPropietario { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
    }
}
