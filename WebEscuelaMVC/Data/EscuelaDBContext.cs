using Microsoft.EntityFrameworkCore;
using WebEscuelaMVC.Models;

namespace WebEscuelaMVC.Data
{
    public class EscuelaDBContext:DbContext
    {
        public EscuelaDBContext(DbContextOptions<EscuelaDBContext> options) : base(options) { }

        public DbSet<Aula> Aulas { get; set; }
    }
}
