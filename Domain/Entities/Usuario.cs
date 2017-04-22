using Domain.Entities.Base;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Usuario : Entity
    {

        public Usuario()
        {
            ContasPoupanca = new List<Poupanca>();
            ContasCorrente = new List<Corrente>();
        }

        public string Nome { get; set; }

        public string Endereco { get; set; }

        public IList<Poupanca> ContasPoupanca { get; private set; }

        public IList<Corrente> ContasCorrente { get; private set; }

        public void AddPoupanca(Poupanca conta)
        {
            this.ContasPoupanca.Add(conta);
        }

        public void AddCorrente(Corrente conta)
        {
            this.ContasCorrente.Add(conta);
        }
    }
}