using SQLite;

namespace Garage.DAL.Entities.Base
{
    public abstract class BaseEntity
    {
        #region Properties

        [PrimaryKey, AutoIncrement, Column("Id")]
        public int Id { get; set; }

        #endregion
    }
}
