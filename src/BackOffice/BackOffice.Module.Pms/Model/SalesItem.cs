using Domain.Common;

namespace BackOffice.Module.Pms.Model
{
    public class SalesItem : DomainEntity
    {
        public virtual string Name { get; set; }
        public virtual SalesFamily SalesFamily { get; set; }
    }
}