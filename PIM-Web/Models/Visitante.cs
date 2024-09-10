namespace PIM_Web.Models
{
    public class Visitante
    {
        public int Id { get; set; }
        public string Nome { get; set; } 
        public string Email { get; set; }
        public DateTime DataVisita { get; set; } 
        public string Comentario { get; set; } 
        public int Avaliacao { get; set; }
    }
}
