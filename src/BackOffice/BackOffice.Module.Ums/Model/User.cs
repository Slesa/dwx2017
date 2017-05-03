﻿using Domain.Common;

namespace BackOffice.Module.Ums.Model
{
    public class User : DomainEntity
    {
        public virtual string Name { get; set; }
        public virtual string Password { get; set; }
        public virtual UserRole UserRole { get; set; }
    }
}