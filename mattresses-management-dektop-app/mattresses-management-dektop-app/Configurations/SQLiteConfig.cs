using mattresses_management_dektop_app.Core.Logging;
using System;
using System.IO;

namespace mattresses_management_dektop_app.Configurations
{
    public class SQLiteConfig
    {
        private static readonly Log LOG = LogFactory.CreateNewIstance(typeof(SQLiteConfig));

        public string DatabasePath { get; }

        public SQLiteConfig()
        {
            // Get an absolute path to the database file
            DatabasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "mattresses-management\\mattresses-management.db");

            if (!File.Exists(DatabasePath))
            {
                FileInfo fileInfo = new FileInfo(DatabasePath);
                Directory.CreateDirectory(fileInfo.Directory.FullName);
                using (File.Create(DatabasePath))
                {
                    LOG.Information("File created with path {DatabasePath}.", DatabasePath);
                }
            }
            else
            {
                LOG.Information("DB file has as path {DatabasePath}.", DatabasePath);
            }
        }
    }
}
