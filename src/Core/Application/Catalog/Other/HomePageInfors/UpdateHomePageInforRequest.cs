namespace TD.CitizenAPI.Application.Catalog.HomePageInfors;

public class UpdateHomePageInforRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
    public string? ImagePad { get; set; }
    public string? Image { get; set; }
    public string? Url { get; set; }
    public string? Title { get; set; }
    public int? Order { get; set; }
    public bool? Status { get; set; }
}

public class UpdateHomePageInforRequestValidator : CustomValidator<UpdateHomePageInforRequest>
{
    public UpdateHomePageInforRequestValidator(IRepository<HomePageInfor> repository, IStringLocalizer<UpdateHomePageInforRequestValidator> localizer) =>
        RuleFor(p => p.Title)
            .NotEmpty();
}

public class UpdateHomePageInforRequestHandler : IRequestHandler<UpdateHomePageInforRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<HomePageInfor> _repository;
    private readonly IStringLocalizer<UpdateHomePageInforRequestHandler> _localizer;

    public UpdateHomePageInforRequestHandler(IRepositoryWithEvents<HomePageInfor> repository, IStringLocalizer<UpdateHomePageInforRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(UpdateHomePageInforRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(string.Format(_localizer["homepageinfor.notfound"], request.Id));

        item.Update(request.ImagePad, request.Image, request.Url, request.Title, request.Order, request.Status);

        await _repository.UpdateAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}