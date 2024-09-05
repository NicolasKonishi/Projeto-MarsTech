using API_Web.Entities;
using Microsoft.EntityFrameworkCore;

namespace API_Web.Context
{
    public class QuestionarioContext:DbContext
    {
        public QuestionarioContext(DbContextOptions<QuestionarioContext> options) : base(options) { }

        public DbSet<QuestionarioResposta> QuestionarioRespostas { get; set; }

    }
}
