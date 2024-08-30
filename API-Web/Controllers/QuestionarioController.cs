using API_Web.Context;
using API_Web.Entities;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace API_Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionarioController : ControllerBase
    {
        private readonly QuestionarioContext _context;
        private readonly ILogger<QuestionarioController> _logger;

        public QuestionarioController(QuestionarioContext context, ILogger<QuestionarioController> logger)  // Adicione o logger ao construtor
        {
            _context = context;
            _logger = logger;
        }
        [HttpPost]
        public async Task<IActionResult> PostQuestionario([FromBody] QuestionarioResposta questionario)
        {
            if (questionario == null)
            {
                return BadRequest("Questionario é nulo.");
            }

            _context.QuestionarioRespostas.Add(questionario);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetQuestionario), new { id = questionario.Id }, questionario);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<QuestionarioResposta>> GetQuestionario(int id)
        {
            var questionario = await _context.QuestionarioRespostas.FindAsync(id);

            if (questionario == null)
            {
                return NotFound();
            }

            return questionario;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuestionarioResposta>>> GetQuestionarios()
        {
            var questionarios = await _context.QuestionarioRespostas.ToListAsync();
            return Ok(questionarios);
        }

        [HttpGet("random-comment")]
        public async Task<ActionResult> GetRandomComment()
        {
            var comentarios = await _context.QuestionarioRespostas
                                            .Where(q => !string.IsNullOrEmpty(q.Comentario) && !string.IsNullOrEmpty(q.Email))
                                            .Select(q => new { q.Comentario, q.Email })
                                            .ToListAsync();

            if (!comentarios.Any())
            {
                return NotFound(new { message = "Nenhum comentário encontrado." });
            }

            var random = new Random();
            var randomComentario = comentarios[random.Next(comentarios.Count)];

            return Ok(randomComentario);
        }

        [HttpGet("average-exhibitions")]
        public async Task<ActionResult<double>> GetAverageExhibitions()
        {
            try
            {
                var respostas = await _context.QuestionarioRespostas
                    .Select(q => q.QualidadeExposicao)
                    .ToListAsync();

                if (respostas.Any())
                {
                    var averageExhibitions = respostas
                        .Select(ConvertSatisfacaoToNumeric)
                        .Where(n => n.HasValue)
                        .Average(n => n.Value);

                    return Ok(averageExhibitions);
                }
                else
                { 
                    return Ok(0);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao calcular a média das exposições.");
                return StatusCode(500, "Erro interno do servidor.");
            }
        }

        private double? ConvertSatisfacaoToNumeric(string satisfacao)
        {
            return satisfacao switch
            {
                "Excelente" => 5,
                "Muito boa" => 4,
                "Boa" => 3,
                "Regular" => 2,
                "Ruim" => 1,
                _ => null
            };
        }


    }

}
