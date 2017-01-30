using System;
using System.IO;
using PCLAppConfig;

namespace Garage.RL.Droid.Infrastructure
{
    public static class DatabaseManager
    {
        #region Public Methods

        public static string GetPathToDatabase()
        {
            string databaseName = ConfigurationManager.AppSettings["DatabaseName"];
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string path = Path.Combine(documentsPath, databaseName);

            return path;
        }

        #endregion
    }
}