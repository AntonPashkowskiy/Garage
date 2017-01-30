using Garage.DAL.Entities.Base;
using Garage.DAL.Services.Interfaces.UnitOfWork;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Garage.DAL.Services.Implementations.UnitOfWork
{
    public class Repository<T> : IRepository<T> where T : BaseEntityWithDateAudit, new()
    {
        #region Fields

        private readonly SQLiteConnection _databaseConnection;

        #endregion

        #region Ctor

        public Repository(SQLiteConnection databaseConnection)
        {
            _databaseConnection = databaseConnection;
            _databaseConnection.CreateTable(typeof(T));
        }

        #endregion

        #region Public Methods

        public T GetById(int id)
        {
            return _databaseConnection.Get<T>(id);
        }

        public IList<T> GetAll()
        {
            return (from item in _databaseConnection.Table<T>() select item).ToList();
        }

        public int Create(T entity)
        {
            _databaseConnection.Insert(entity);
            return entity.Id;
        }

        public void Update(T entity)
        {
            _databaseConnection.Update(entity);
        }

        public void Delete(int id)
        {
            _databaseConnection.Delete<T>(id);
        }

        #endregion
    }
}
