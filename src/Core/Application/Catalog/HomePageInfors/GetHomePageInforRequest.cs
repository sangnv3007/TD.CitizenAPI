namespace TD.CitizenAPI.Application.Catalog.HomePageInfors;

public class GetHomePageInforRequest : IRequest<Result<HomePageInforDetailsDto>>
{
    public Guid Id { get; set; }

    public GetHomePageInforRequest(Guid id) => Id = id;
}

public class HomePageInforByIdSpec : Specification<HomePageInfor, HomePageInforDetailsDto>, ISingleResultSpecification
{
    public HomePageInforByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id);
}

public class GetCategoryRequestHandler : IRequestHandler<GetHomePageInforRequest, Result<HomePageInforDetailsDto>>
{
    private readonly IRepository<HomePageInfor> _repository;
    private readonly IStringLocalizer<GetCategoryRequestHandler> _localizer;

    public GetCategoryRequestHandler(IRepository<HomePageInfor> repository, IStringLocalizer<GetCategoryRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<Result<HomePageInforDetailsDto>> Handle(GetHomePageInforRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetBySpecAsync(
            (ISpecification<HomePageInfor, HomePageInforDetailsDto>)new HomePageInforByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["homepageinfor.notfound"], request.Id));
        return Result<HomePageInforDetailsDto>.Success(item);

    }
}