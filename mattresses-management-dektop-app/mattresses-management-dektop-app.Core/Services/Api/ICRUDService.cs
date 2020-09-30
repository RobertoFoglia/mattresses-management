using mattresses_management_dektop_app.Core.Repositories.Api;
using System;
using System.Collections.Generic;
using System.Text;

namespace mattresses_management_dektop_app.Core.Services.Api
{
    public interface ICRUDService<E, K> : IRepository<E, K>  where E : new()
    {
    }
}
