using Garage.DAL.Services.Interfaces.UnitOfWork;
using SQLite;

namespace Garage.DAL.Services.Implementations.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Fields

        private readonly SQLiteConnection _databaseConnection;
        private bool _isDatabaseConnectionDisposed;

        #endregion

        #region Ctor

        public UnitOfWork(string pathToDatabase)
        {
            _databaseConnection = new SQLiteConnection(pathToDatabase);
        }

        #endregion

        #region Public Method

        public void Dispose()
        {
            if (!_isDatabaseConnectionDisposed)
            {
                _databaseConnection.Dispose();
            }
        } 

        #endregion
    }
}
