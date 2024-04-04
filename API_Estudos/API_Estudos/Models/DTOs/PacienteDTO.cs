namespace API_Estudos.Models.DTOs
{
    public class PacienteDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public int? MedicoId { get; set; }
    }
}
