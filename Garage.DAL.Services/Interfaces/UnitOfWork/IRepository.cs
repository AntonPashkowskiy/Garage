using Garage.DAL.Entities.Base;
using System.Collections.Generic;

namespace Garage.DAL.Services.Interfaces.UnitOfWork
{
    public interface IRepository<T> where T: BaseEntityWithDateAudit, new()
    {
        T GetById(int id);
        IList<T> GetAll();
        int Create(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
