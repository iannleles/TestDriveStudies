namespace API_Estudos.Models
{
    public class Medico : EntidadeBase
    {
        public string Nome { get; set; }

        public string CRM { get; set; } 
        public int EspecialidadeId { get; set; }
        public virtual Especialidade Especialidade { get; set; }
        public List<Paciente> Pacientes { get; set;}

    }
}
