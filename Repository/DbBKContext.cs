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
        public virtual IDbSet<Usuario> Usuario { get; set; }

        /// <summary>
        /// DbSet Poupanca
        /// </summary>
        public virtual IDbSet<Poupanca> Poupanca { get; set; }

        /// <summary>
        /// DbSet Corrente
        /// </summary>
        public virtual IDbSet<Corrente> Corrente { get; set; }

        /// <summary>
        /// DbSet Agencia
        /// </summary>
        public virtual IDbSet<Agencia> Agencia { get; set; }

        /// <summary>
        /// DbSet Banco
        /// </summary>
        public virtual DbSet<Banco> Banco { get; set; }

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
