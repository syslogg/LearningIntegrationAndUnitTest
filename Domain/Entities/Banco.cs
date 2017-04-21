using Domain.Entities.Base;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Banco : Entity
    {
        public string Nome { get; set; }
        public IList<Agencia> Agencias { get; private set; }
        public string Codigo { get; set; }

        public void AddAgencia(Agencia agencia)
        {
            this.Agencias.Add(agencia);
        }
    }
}