using System.Linq;

namespace TD.CitizenAPI.Application.Catalog.Companies;

public class CompaniesBySearchRequestSpec : EntitiesByPaginationFilterSpec<Company, CompanyDto>
{
    public CompaniesBySearchRequestSpec(SearchCompaniesRequest request)
        : base(request) =>
        Query
            .Include(p => p.Province)
            .Include(p => p.District)
            .Include(p => p.Commune)
            .Where(p => p.ProvinceId.Equals(request.ProvinceId!.Value), request.ProvinceId.HasValue)
            .Where(p => p.DistrictId.Equals(request.DistrictId!.Value), request.DistrictId.HasValue)
            .Where(p => p.CommuneId.Equals(request.CommuneId!.Value), request.CommuneId.HasValue)
            .Where(p => p.UserName == request.UserName, !string.IsNullOrWhiteSpace(request.UserName))
        ;

}