using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class EscolaContext : DbContext
    {
        public EscolaContext(DbContextOptions<EscolaContext> options) : base(options)
        {

        }
        public DbSet<Curso> Cursos {get; set;}
        public DbSet<Usuario> Usuarios {get; set;}

    }
        
}