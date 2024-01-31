using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data.Map;
using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Data
{
    public class SistemaTarefasDBContext : DbContext
    {
        public SistemaTarefasDBContext(DbContextOptions<SistemaTarefasDBContext> options) : base(options)
        {            
        }

        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<TarefaModel> Tarefas { get; set; }

		/*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
                //var connection = Configuration["ConexaoMySql:MySqlConnectionString"];
                string connectionString = "Server=localhost;User Id=root;Password=my5qlL1X0!;Database=DB_SistemaTarefas";
				optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
				//ou usar new MySqlServerVersion(new Version(8, 0, 36))
			}
		}*/

		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new TarefaMap());
			base.OnModelCreating(modelBuilder);
        }
    }
}
