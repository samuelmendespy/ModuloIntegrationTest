namespace api.Models
{
    public class Curso
    {
        public int Id { get; set; }
        public string Nome { get; set; } = "";
        public string Descricao { get; set; } = "";
        public bool Ofertado { get; set; } = false;
        public int IdUsuario { get; set; }
        public virtual Usuario Usuario { get; set; } = new Usuario();
    }
}