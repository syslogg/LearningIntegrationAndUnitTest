using Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Repository.Mapping
{
    public class BancoMapping : EntityTypeConfiguration<Banco>
    {
        public BancoMapping()
        {
            #region Key

            HasKey(x => x.Id);

            #endregion

            #region Propriedades

            Property(x => x.Nome);
            Property(x => x.Codigo);

            #endregion

            #region Referencias

            HasMany(x => x.Agencias).WithRequired(x => x.Banco).HasForeignKey(x => x.BancoId).WillCascadeOnDelete(true);

            #endregion
        }
    }
}
