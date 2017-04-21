﻿namespace Domain.Entities.Base
{
    public class Conta : Entity
    {
        public Agencia Agencia { get;set; }

        public Usuario Usuario { get; set; }

        public virtual string Codigo { get; set; }

        public float Saldo { get; set; }
    }
}
