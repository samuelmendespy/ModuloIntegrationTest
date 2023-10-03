using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Data
{
    public class EscolaContext : DbContext
    {
        public EscolaContext(DbContextOptions<EscolaContext> options) : base(options)
        {

        }
        public DbSet<Usuario> Cursos {get; set;}
        public DbSet<Usuario> Usuarios {get; set;}

        }
        
    }
}