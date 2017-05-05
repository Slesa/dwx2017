using Domain.Common;

namespace BackOffice.Models
{
    public class Waiter : DomainEntity
    {
        public virtual string Name { get; set; }
        public virtual User User { get; set; }
        public virtual WaiterTeam WaiterTeam { get; set; }
    }
}