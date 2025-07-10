using Microsoft.EntityFrameworkCore;
using Actividad4LengProg3.Models;

namespace Actividad4LengProg3.Data
{
    public class MiContexto : DbContext
    {
        public MiContexto(DbContextOptions<MiContexto> options)
            : base(options)
        {
        }

        public DbSet<Estudiante> Estudiantes { get; set; } = null!;
        public DbSet<Materia> Materias { get; set; } = null!;
    }
}
