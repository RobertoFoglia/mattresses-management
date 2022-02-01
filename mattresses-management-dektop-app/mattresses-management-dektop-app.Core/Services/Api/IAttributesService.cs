using System.Collections.Generic;
using Attribute = mattresses_management_dektop_app.Core.Models.entities.Attribute;

namespace mattresses_management_dektop_app.Core.Services.Api
{
    public interface IAttributesService : ICRUDService<Attribute, int>
    {
        List<Attribute> GetDefaultAttributes();
    }
}