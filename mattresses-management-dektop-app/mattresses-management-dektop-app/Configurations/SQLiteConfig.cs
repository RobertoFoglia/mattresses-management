using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mattresses_management_dektop_app.Configurations
{
    public class SQLiteConfig
    {
        public string DatabasePath { get; }

        public SQLiteConfig() {
            // Get an absolute path to the database file
            DatabasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "mattresses-management\\mattresses-management.db");

            if (!File.Exists(DatabasePath))
            {
                FileInfo fileInfo = new FileInfo(DatabasePath);
                Directory.CreateDirectory(fileInfo.Directory.FullName);
                using (File.Create(DatabasePath))
                {
                    System.Diagnostics.Debug.WriteLine("file created with path" + fileInfo.Directory.FullName);
                }
            }
        }
    }
}
