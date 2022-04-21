using AlunoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AlunoApi.Data
{
    public class AlunoContext : DbContext
    {

        public AlunoContext(DbContextOptions<AlunoContext> opts) : base(opts)  
        {

        }

        public DbSet<Aluno> alunos { get; set; }

    }
}
