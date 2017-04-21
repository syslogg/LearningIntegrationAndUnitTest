using Domain.Entities.Base;

namespace Domain.Entities
{
    public class Poupanca : Conta
    {
        
        private static string CodigoPoupanca = "500";
        
        /// <summary>
        /// Definido intervalo entre 0 e 1.
        /// </summary>
        public float JurosMensal
        {
            set
            {
                this.JurosMensal = value < 0 ? 0 : (value > 1 ? 1 : value);
            }
            get { return this.JurosMensal; }
        }

        /// <summary>
        /// Adicionado código da <see cref="Poupanca"/>
        /// </summary>
        public override string Codigo
        {
            get
            {
                return base.Codigo + "/"+ Poupanca.CodigoPoupanca;
            }

            set
            {
                base.Codigo = value;
            }
        }
    }
}
