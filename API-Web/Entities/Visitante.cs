namespace API_Web.Entities
{
    public class Visitante
    {
        public int Id { get; set; } 
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Comentario { get; set; }
        public string AvaliacaoGeral { get; set; }
        public string AvaliacaoQualidade { get; set; }
    }
}
