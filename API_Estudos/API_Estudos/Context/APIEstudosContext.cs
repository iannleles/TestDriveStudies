using API_Estudos.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Estudos.Context
{
    public class APIEstudosContext : DbContext
    {
        public APIEstudosContext(DbContextOptions<APIEstudosContext> options) : base(options)
        {

        }

        public DbSet<Paciente> Pacientes { get; set; } = default!;
        public DbSet<Medico> Medicos { get; set; } = default!;
        public DbSet<Especialidade> Especialidades { get; set; } = default!;
    }
}
