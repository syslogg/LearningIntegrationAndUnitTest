using Domain.Entities.Base;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Agencia : Entity
    {
        public Agencia()
        {
            ContasPoupanca = new List<Poupanca>();
            ContasCorrente = new List<Corrente>();
        }
        public string Nome { get; set; }

        public Banco Banco { get; set; }

        public int BancoId { get; set; }

        public string Endereco { get; set; }

        public IList<Poupanca> ContasPoupanca { get; private set; }

        public IList<Corrente> ContasCorrente { get; private set; }

        public string Codigo { get; set; }

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