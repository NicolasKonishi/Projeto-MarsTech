using API_Web.Context;
using API_Web.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace API_Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VisitantesController:ControllerBase
    {
        private readonly QuestionarioContext _context;

        public VisitantesController(QuestionarioContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Visitante>> GetVisitanteById(int id)
        {
            var visitante = await _context.Visitantes.FindAsync(id);
            if (visitante == null)
            {
                return NotFound();
            }

            return Ok(visitante);
        }

        [HttpPost]
        public async Task<IActionResult> CreateVisitante([FromBody] Visitante visitante)
        {
            if (visitante == null)
            {
                return BadRequest();
            }

            _context.Visitantes.Add(visitante);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetVisitanteById), new { id = visitante.Id }, visitante);
        }

    }
}
