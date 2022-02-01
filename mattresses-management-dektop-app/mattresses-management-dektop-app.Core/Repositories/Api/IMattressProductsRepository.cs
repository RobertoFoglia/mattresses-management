﻿using mattresses_management_dektop_app.Core.Models.entities;
using System.Collections.Generic;

namespace mattresses_management_dektop_app.Core.Repositories.Api
{
    public interface IMattressProductsRepository : IRepository<MattressProduct, int>
    {
        List<Product> GetTheProductsOfTheMattresses(Mattress mattress);

        List<MattressProduct> FindByMattress(Mattress mattress);

        bool BelongsToAMattress(Product entity);
    }
}