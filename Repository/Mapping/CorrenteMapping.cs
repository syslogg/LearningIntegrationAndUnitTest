using Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Repository.Mapping
{
    public class CorrenteMapping : EntityTypeConfiguration<Corrente>
    {
        public CorrenteMapping()
        {
            #region Key

            HasKey(x => x.Id);

            #endregion

            #region Propriedades

            Property(x => x.Codigo);
            Property(x => x.CreditoPreAprovado);
            Property(x => x.Saldo);

            #endregion

            #region Referencias

            HasRequired(x => x.Agencia).WithMany(x => x.ContasCorrente).HasForeignKey(x => x.AgenciaId).WillCascadeOnDelete(true);

            HasRequired(x => x.Usuario).WithMany(x => x.ContasCorrente).HasForeignKey(x => x.UsuarioId).WillCascadeOnDelete(true);

            #endregion
        }
    }
}
