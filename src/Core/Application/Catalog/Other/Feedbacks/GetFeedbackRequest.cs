namespace TD.CitizenAPI.Application.Catalog.Feedbacks;

public class GetFeedbackRequest : IRequest<Result<FeedbackDetailsDto>>
{
    public Guid Id { get; set; }

    public GetFeedbackRequest(Guid id) => Id = id;
}

public class HomePageInforByIdSpec : Specification<HomePageInfor, FeedbackDetailsDto>, ISingleResultSpecification
{
    public HomePageInforByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id);
}

public class GetCategoryRequestHandler : IRequestHandler<GetFeedbackRequest, Result<FeedbackDetailsDto>>
{
    private readonly IRepository<HomePageInfor> _repository;
    private readonly IStringLocalizer<GetCategoryRequestHandler> _localizer;

    public GetCategoryRequestHandler(IRepository<HomePageInfor> repository, IStringLocalizer<GetCategoryRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<Result<FeedbackDetailsDto>> Handle(GetFeedbackRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetBySpecAsync(
            (ISpecification<HomePageInfor, FeedbackDetailsDto>)new HomePageInforByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["homepageinfor.notfound"], request.Id));
        return Result<FeedbackDetailsDto>.Success(item);

    }
}