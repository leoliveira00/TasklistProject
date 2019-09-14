using Microsoft.EntityFrameworkCore;
using TasklistProject1.Models;

namespace TasklistProject1.Data
{
    public class TasklistContext:DbContext
    {
        public TasklistContext(DbContextOptions<TasklistContext> options) : base(options)
        {

        }

        /**
         * Referencia a tabela no banco de dados. 
         * O .NET core implementa injeção de dependência por padrão, portanto é necessário 
         * registrar o contexto como serviço em Startup.cs através de services.AddDbContext
         * bem como a string de conexão em appsettings.json.
         */
        public DbSet<Tasklist> Tasklists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tasklist>().ToTable("Tasklist");
        }
    }
}
