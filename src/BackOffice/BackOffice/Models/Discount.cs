﻿using BackOffice.Domain;

namespace BackOffice.Models
{
    public class Discount : DomainEntity
    {
        public virtual string Name { get; set; }
        public virtual decimal Rate { get; set; }
        public virtual bool IsAbsolute { get; set; }
        public virtual bool UseForSale { get; set; }
        public virtual bool UseForOrders { get; set; }
    }
}