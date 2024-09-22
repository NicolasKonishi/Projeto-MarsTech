using System.ComponentModel.DataAnnotations;

namespace PIM_WPF.Entities
{
    public class QuestionarioResposta
    {
        public int Id { get; set; }
        public string SatisfacaoGeral { get; set; }
        public string QualidadeExposicao { get; set; }
        public string Comentario { get; set; }
        public string Email { get; set; }

    }
}
