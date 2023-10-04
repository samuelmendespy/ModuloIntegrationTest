
namespace api.DTOs
{
    public class CursoDTO
    {
    public int Id { get; set; }
    public string Nome { get; set; } = "";
    public string Descricao { get; set; } = "";
    public bool Ofertado { get; set; }
    public int IdUsuario { get; set; }
}
}