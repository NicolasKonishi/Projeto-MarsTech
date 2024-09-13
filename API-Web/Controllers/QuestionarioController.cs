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

        public QuestionarioController(QuestionarioContext context, ILogger<QuestionarioController> logger)
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
                    var averageExhibitions = CalcularMedia(respostas);
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

        [HttpGet("average-satisfaction")]
        public async Task<ActionResult<double>> GetAverageSatisfaction()
        {
            try
            {
                var respostas = await _context.QuestionarioRespostas
                    .Select(q => q.SatisfacaoGeral)
                    .ToListAsync();

                if (respostas.Any())
                {
                    var averageSatisfaction = CalcularMedia(respostas);
                    return Ok(averageSatisfaction);
                }
                else
                {
                    return Ok(0);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao calcular a média de satisfação.");
                return StatusCode(500, "Erro interno do servidor.");
            }
        }
        private double CalcularMedia(List<string> respostas)
        {
            var valores = respostas
                .Select(ConvertSatisfacaoToNumeric)
                .Where(n => n.HasValue)
                .Select(n => n.Value)
                .ToList();

            _logger.LogInformation("Valores numéricos convertidos: {Valores}", string.Join(", ", valores));

            if (valores.Any())
            {
                var media = valores.Average();
                _logger.LogInformation("Média calculada: {Media}", media);
                return media;
            }
            else
            {
                _logger.LogWarning("Nenhum valor válido encontrado para calcular a média.");
                return 0;
            }
        }


        private double? ConvertSatisfacaoToNumeric(string satisfacao)
        {
            satisfacao = satisfacao?.Trim().ToLower();

            return satisfacao switch
            {
                "excelente" => 5,
                "muito boa" => 4,
                "boa" => 3,
                "regular" => 2,
                "ruim" => 1,
                _ => null
            };
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuestionario(int id, [FromBody] QuestionarioResposta updatedQuestionario)
        {
            if (updatedQuestionario == null || id != updatedQuestionario.Id)
            {
                return BadRequest("Dados inválidos para a atualização.");
            }

            var existingQuestionario = await _context.QuestionarioRespostas.FindAsync(id);

            if (existingQuestionario == null)
            {
                return NotFound(new { message = "Questionário não encontrado." });
            }

            existingQuestionario.Comentario = updatedQuestionario.Comentario;
            existingQuestionario.Email = updatedQuestionario.Email;
            existingQuestionario.QualidadeExposicao = updatedQuestionario.QualidadeExposicao;
            existingQuestionario.SatisfacaoGeral = updatedQuestionario.SatisfacaoGeral;

            try
            {
                _context.QuestionarioRespostas.Update(existingQuestionario);
                await _context.SaveChangesAsync();
                return Ok(existingQuestionario);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar o questionário.");
                return StatusCode(500, "Erro interno do servidor.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestionario(int id)
        {
            var questionario = await _context.QuestionarioRespostas.FindAsync(id);

            if (questionario == null)
            {
                return NotFound(new { message = "Questionário não encontrado." });
            }

            try
            {
                _context.QuestionarioRespostas.Remove(questionario);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Questionário excluído com sucesso." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao excluir o questionário.");
                return StatusCode(500, "Erro interno do servidor.");
            }
        }

    }
}