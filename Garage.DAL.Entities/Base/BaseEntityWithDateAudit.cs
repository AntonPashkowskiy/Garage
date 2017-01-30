using System;

namespace Garage.DAL.Entities.Base
{
    public abstract class BaseEntityWithDateAudit: BaseEntity
    {
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
