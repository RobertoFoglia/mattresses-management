using mattresses_management_dektop_app.Core.Repositories.Api;
using mattresses_management_dektop_app.Core.Services.Api;
using System.Collections.Generic;
using Attribute = mattresses_management_dektop_app.Core.Models.entities.Attribute;

namespace mattresses_management_dektop_app.Core.Services
{
    public class AttributesService : AbstractCRUDService<Attribute, int>, IAttributesService
    {
        private IAttributesRepository AttributesRepository;
        private IMattressAttributesRepository MattressAttributesRepository;

        public AttributesService(
            IAttributesRepository attributesRepository,
            IMattressAttributesRepository mattressAttributesRepository)
            : base(attributesRepository)
        {
            this.AttributesRepository = attributesRepository;
            this.MattressAttributesRepository = mattressAttributesRepository;
        }

        public List<Attribute> GetDefaultAttributes()
        {
            return AttributesRepository.Where(attribute => attribute.Default);
        }
    }
}