using Domain.Entities;
using Repository.Mapping;
using System.Data.Entity;

namespace Repository
{
    public class DbBKContext : DbContext
    {

        public DbBKContext()
            : base("name=DbContextConn")
        {

        }
        
        /// <summary>
        /// DbSet Usuario
        /// </summary>
        public DbSet<Usuario> Usuario { get; set; }

        /// <summary>
        /// DbSet Poupanca
        /// </summary>
        public DbSet<Poupanca> Poupanca { get; set; }

        /// <summary>
        /// DbSet Corrente
        /// </summary>
        public DbSet<Corrente> Corrente { get; set; }

        /// <summary>
        /// DbSet Agencia
        /// </summary>
        public DbSet<Agencia> Agencia { get; set; }

        /// <summary>
        /// DbSet Banco
        /// </summary>
        public DbSet<Banco> Banco { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Mapeamento banco de dados
            modelBuilder.Configurations.Add(new UsuarioMapping());
            modelBuilder.Configurations.Add(new BancoMapping());
            modelBuilder.Configurations.Add(new AgenciaMapping());
            modelBuilder.Configurations.Add(new PoupancaMapping());
            modelBuilder.Configurations.Add(new CorrenteMapping());

            base.OnModelCreating(modelBuilder);
        }


    }
}
