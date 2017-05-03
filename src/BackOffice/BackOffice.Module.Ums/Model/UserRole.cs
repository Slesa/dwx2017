using Domain.Common;

namespace BackOffice.Module.Ums.Model
{
    public class UserRole : DomainEntity
    {
        public virtual string Name { get; set; }
    }
}