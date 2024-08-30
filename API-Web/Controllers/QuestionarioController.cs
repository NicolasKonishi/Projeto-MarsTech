using API_Web.Context;
using API_Web.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API_Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionarioController : ControllerBase
    {
        private readonly QuestionarioContext _context;

        public QuestionarioController(QuestionarioContext context)
        {
            _context = context;
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
    }

}
