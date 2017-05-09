using Domain.Common;

namespace BackOffice.Module.Ums.Models
{
    public class UserRole : DomainEntity
    {
        public virtual string Name { get; set; }
    }
}