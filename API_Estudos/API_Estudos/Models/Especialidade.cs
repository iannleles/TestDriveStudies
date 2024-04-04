namespace API_Estudos.Models
{
    public class Especialidade : EntidadeBase
    {
        public string Nome { get; set; }

        public virtual List<Medico> Medicos { get; set; }   
    }
}
