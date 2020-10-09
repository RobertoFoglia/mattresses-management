using mattresses_management_dektop_app.Core.Models.entities;
using mattresses_management_dektop_app.Core.Repositories.Api;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace mattresses_management_dektop_app.Core.Repositories.SQLite
{
    public class MattressesSQLiteRepository : AbstractSQLiteRepository<Mattress, int>, IMattressesRepository
    {
        public MattressesSQLiteRepository(SQLiteConnection connectionPool) : base(connectionPool)
        {
        }
    }
}
