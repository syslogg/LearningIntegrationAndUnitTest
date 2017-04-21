using Domain.Entities.Base;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Usuario : Entity
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public IList<Conta> Contas { get; set; }
    }
}