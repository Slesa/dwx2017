using BackOffice.Domain;

namespace BackOffice.Models
{
    public class SalesItem : DomainEntity
    {
        public virtual string Name { get; set; }
        public virtual SalesFamily SalesFamily { get; set; }
    }
}