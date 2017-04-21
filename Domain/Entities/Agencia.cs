using Domain.Entities.Base;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Agencia : Entity
    {
        public Agencia()
        {
            Contas = new List<Conta>();
        }
        public string Nome { get; set; }

        public Banco Banco { get; set; }

        public string Endereco { get; set; }

        public IList<Conta> Contas { get; private set; }

        public string Codigo { get; set; }

        public void AddConta(Conta conta)
        {
            this.Contas.Add(conta);
        }
        
    }
}