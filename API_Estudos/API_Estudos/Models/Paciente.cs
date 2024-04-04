namespace API_Estudos.Models
{
    public class Paciente : EntidadeBase
    {
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public int? MedicoId { get; set; }
        public virtual Medico? Medico { get; set; }

    }
}
