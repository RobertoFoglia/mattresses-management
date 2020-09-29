using mattresses_management_dektop_app.Core.Models.entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace mattresses_management_dektop_app.Core.Services.Api
{
    public interface IProductsService
    {
        Product Find(int id);

        int Insert(Product item);
    }
}
