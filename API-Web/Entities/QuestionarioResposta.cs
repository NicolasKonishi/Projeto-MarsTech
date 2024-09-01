using System.ComponentModel.DataAnnotations;

namespace API_Web.Entities
{
    public class QuestionarioResposta
    {
        public int Id { get; set; }
        public string SatisfacaoGeral { get; set; }
        public string QualidadeExposicao { get; set; }
        [StringLength(100)]
        public string Comentario { get; set; }
        [StringLength(100)]
        public string Email { get; set; }

    }
}
