namespace API_Estudos.Models
{
    public class EntidadeBase
    {
        public int Id {  get; set; }
        public DateTime CriadoEm { get; set; }
        public bool Excluido { get; set; }
        public void InserirDadosBase()
        {
            CriadoEm = DateTime.Now;
            Excluido = false;
        }
    }
}
