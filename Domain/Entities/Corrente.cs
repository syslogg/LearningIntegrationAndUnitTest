using Domain.Entities.Base;

namespace Domain.Entities
{
    public class Corrente : Conta
    {
        public float CreditoPreAprovado { get; set; }
    }
}
