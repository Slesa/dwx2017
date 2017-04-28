using Domain.Common;

namespace BackOffice.Models
{
    public class UserRole : DomainEntity
    {
        public virtual string Name { get; set; }
    }
}