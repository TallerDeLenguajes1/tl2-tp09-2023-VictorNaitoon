namespace Kanban.Models
{
    public enum EstadoTarea
    {
        Ideas,
        ToDo,
        Doing,
        Review,
        Done
    }
    public class Tarea
    {
        public int IdTarea { get; set; }
        public int IdTablero { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Descripcion {  get; set; }
        public string? Color {  get; set; }
        public EstadoTarea Estado {  get; set; }
        public int IdUsuarioAsignado { get; set; }
    }
}
