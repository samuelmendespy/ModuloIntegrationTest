using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace api.ViewModels.Usuarios
{
    public class BuscarUsuariosViewModelOutput
    {
        public List<Usuario> Usuarios {get; set;} = new List<Usuario>();
      
    }
}