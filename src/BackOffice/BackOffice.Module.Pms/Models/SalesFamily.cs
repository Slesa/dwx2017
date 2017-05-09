using Domain.Common;

namespace BackOffice.Module.Pms.Models
{
    public class SalesFamily : DomainEntity
    {
        public virtual string Name { get; set; }
        public virtual SalesFamilyGroup SalesFamilyGroup { get; set; }
    }
}