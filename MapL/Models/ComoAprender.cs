namespace MapL.Models
{
    public class ComoAprender
    {
        public int  Id { get; set; }
        public string? Texto { get; set; }
        public int ProjetoId { get; set; }
        public Projeto Projeto { get; set; }
    }
}
