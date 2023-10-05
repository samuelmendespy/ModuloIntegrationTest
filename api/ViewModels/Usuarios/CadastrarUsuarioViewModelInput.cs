using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.ViewModels.Usuarios
{
    public class CadastrarUsuarioViewModelInput
    {
        public string Nome { get; set; } = "";
        public string Telefone { get; set; } = "";
        public bool Ativo { get; set; } = true;

      
    }
}