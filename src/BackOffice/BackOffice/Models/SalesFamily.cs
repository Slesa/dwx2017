using Domain.Common;

namespace BackOffice.Models
{
    public class SalesFamily : DomainEntity
    {
        public virtual string Name { get; set; }
        public virtual SalesFamilyGroup SalesFamilyGroup { get; set; }
    }
}