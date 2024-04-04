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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Especialidade>()
               .HasMany(e => e.Medicos)
               .WithOne(e => e.Especialidade)
               .HasForeignKey(e => e.EspecialidadeId)
               .IsRequired();

            modelBuilder.Entity<Medico>()
                .HasMany(x => x.Pacientes)
                .WithOne(x => x.Medico)
                .HasForeignKey(x => x.MedicoId)
                .IsRequired(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
