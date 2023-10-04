using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs
{
    public class UsuarioDTO
    {
    public string Nome { get; set; } = "";
    public string Telefone { get; set; } = "";
    public bool Ativo { get; set; } = false;
    }
}