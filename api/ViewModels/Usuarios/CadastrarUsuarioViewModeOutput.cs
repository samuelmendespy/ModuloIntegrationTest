using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.ViewModels.Usuarios
{
    public class CadastrarUsuarioViewModeOutput
    {
        public int Id { get; set; }
        public string Nome { get; set; } = "";
        public string Telefone { get; set; } = "";
    }
}