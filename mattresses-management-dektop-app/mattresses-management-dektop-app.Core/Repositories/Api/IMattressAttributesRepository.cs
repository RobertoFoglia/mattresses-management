using mattresses_management_dektop_app.Core.Models.entities;
using System;
using System.Collections.Generic;
using System.Text;
using Attribute = mattresses_management_dektop_app.Core.Models.entities.Attribute;

namespace mattresses_management_dektop_app.Core.Repositories.Api
{
    public interface IMattressAttributesRepository : IRepository<MattressAttribute, int>
    {
        List<MattressAttribute> FindByMattress(Mattress mattress);

        List<Attribute> GetTheAttributesOfTheMattresses(Mattress mattress);
    }
}
