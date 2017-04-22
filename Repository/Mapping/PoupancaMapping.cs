using Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Repository.Mapping
{
    public class PoupancaMapping : EntityTypeConfiguration<Poupanca>
    {

        public PoupancaMapping()
        {
            #region Key

            HasKey(x => x.Id);

            #endregion

            #region Propriedades

            Property(x => x.Codigo);
            Property(x => x.JurosMensal);
            Property(x => x.Saldo);

            #endregion

            #region Referencias

            HasRequired(x => x.Agencia).WithMany(x => x.ContasPoupanca).HasForeignKey(x => x.AgenciaId).WillCascadeOnDelete(true);

            HasRequired(x => x.Usuario).WithMany(x => x.ContasPoupanca).HasForeignKey(x => x.UsuarioId).WillCascadeOnDelete(true);

            #endregion
        }

    }
}
