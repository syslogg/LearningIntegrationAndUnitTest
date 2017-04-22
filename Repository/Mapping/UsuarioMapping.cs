using Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Repository.Mapping
{
    public class UsuarioMapping : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMapping()
        {
            #region Key

            HasKey(x => x.Id);

            #endregion

            #region Propriedades

            Property(x => x.Nome);
            Property(x => x.Endereco);

            #endregion

            #region Referencias

            HasMany(x => x.ContasCorrente).WithRequired().HasForeignKey(x => x.UsuarioId).WillCascadeOnDelete(true);

            HasMany(x => x.ContasPoupanca).WithRequired().HasForeignKey(x => x.UsuarioId).WillCascadeOnDelete(true);
            
            #endregion
        }
    }
}
