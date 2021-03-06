﻿using System;

namespace BackOffice.Domain
{
    public class DomainEntity : IEquatable<DomainEntity>
    {
	    private long _id;

        protected DomainEntity()
        {
        }

        protected DomainEntity(int id)
        {
            _id = id;
        }

        public long Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public virtual int Version { get; protected set; }

        public virtual bool Equals(DomainEntity other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id.Equals(default(int)) ? base.Equals(other) : other.Id.Equals(Id);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as DomainEntity);
        }

        public override int GetHashCode()
        {
            return Id.Equals(default(int)) ? base.GetHashCode() : Id.GetHashCode();
        }

        public static bool operator ==(DomainEntity left, DomainEntity right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(DomainEntity left, DomainEntity right)
        {
            return !Equals(left, right);
        }
    }
}