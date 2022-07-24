using Ardalis.Specification;

namespace Kameyo.Core.Application.Modules.Catalog.Specifications
{
    public class GetCatalogByNameSpec : Specification<Domain.Entities.Catalog>
    {
        public GetCatalogByNameSpec(string name)
        {
            Query
                .Where(x => x.Name == name && x.Active);
        }
    }
}
