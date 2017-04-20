using BackOffice.Domain;

namespace BackOffice.Models
{
    public class UserRole : DomainEntity
    {
        public virtual string Name { get; set; }
    }
}