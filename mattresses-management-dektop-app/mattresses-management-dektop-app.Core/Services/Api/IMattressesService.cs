using mattresses_management_dektop_app.Core.Models.entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace mattresses_management_dektop_app.Core.Services.Api
{
    public interface IMattressesService : ICRUDService<Mattress, int>
    {
        Mattress SetProducts(Mattress mattress);

        Mattress SetAttributes(Mattress mattress);
    }
}
