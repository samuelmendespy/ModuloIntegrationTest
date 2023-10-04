namespace api.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; } = "";
        public string Telefone { get; set; } = "";
        public bool Ativo { get; set; } = false;
    }
}