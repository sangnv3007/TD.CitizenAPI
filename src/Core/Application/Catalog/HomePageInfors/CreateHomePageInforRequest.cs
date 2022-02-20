namespace TD.CitizenAPI.Application.Catalog.HomePageInfors;

public partial class CreateHomePageInforRequest : IRequest<Result<Guid>>
{
    public string? ImagePad { get; set; }
    public string? Image { get; set; }
    public string? Url { get; set; }
    public string? Title { get; set; }
    public int? Order { get; set; }
}

public class CreateHomePageInforRequestValidator : CustomValidator<CreateHomePageInforRequest>
{
    public CreateHomePageInforRequestValidator(IReadRepository<HomePageInfor> repository, IStringLocalizer<CreateHomePageInforRequestValidator> localizer) =>
        RuleFor(p => p.Title).NotEmpty();
}

public class CreateCategoryRequestHandler : IRequestHandler<CreateHomePageInforRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<HomePageInfor> _repository;

    public CreateCategoryRequestHandler(IRepositoryWithEvents<HomePageInfor> repository) => _repository = repository;

    public async Task<Result<Guid>> Handle(CreateHomePageInforRequest request, CancellationToken cancellationToken)
    {
        var item = new HomePageInfor(request.ImagePad, request.Image, request.Url, request.Title, request.Order, true);
        await _repository.AddAsync(item, cancellationToken);
        return Result<Guid>.Success(item.Id);
    }
}