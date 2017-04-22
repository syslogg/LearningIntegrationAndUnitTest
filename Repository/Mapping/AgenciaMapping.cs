using Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Repository.Mapping
{
    public class AgenciaMapping : EntityTypeConfiguration<Agencia>
    {
        public AgenciaMapping()
        {
            #region Key

            HasKey(x => x.Id);

            #endregion

            #region Propriedades

            Property(x => x.Nome);
            Property(x => x.Codigo);
            Property(x => x.Endereco);

            #endregion

            #region Referencias

            HasRequired(x => x.Banco).WithMany(x => x.Agencias).HasForeignKey(x => x.BancoId).WillCascadeOnDelete(true);

            #endregion
        }
    }
}
