namespace TD.CitizenAPI.Application.Catalog.Industries;

public partial class CreateIndustryRequest : IRequest<Result<Guid>>
{
    public string Name { get; set; } = default!;
    public string? Code { get; set; }
    public string? Description { get; set; }
}

public class CreateIndustryRequestValidator : CustomValidator<CreateIndustryRequest>
{
    public CreateIndustryRequestValidator(IReadRepository<Industry> repository, IStringLocalizer<CreateIndustryRequestValidator> localizer) =>
        RuleFor(p => p.Name).NotEmpty();
}

public class CreateIndustryRequestHandler : IRequestHandler<CreateIndustryRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Industry> _repository;

    public CreateIndustryRequestHandler(IRepositoryWithEvents<Industry> repository) => _repository = repository;

    public async Task<Result<Guid>> Handle(CreateIndustryRequest request, CancellationToken cancellationToken)
    {
        var item = new Industry(request.Name, request.Code, request.Description);
        await _repository.AddAsync(item, cancellationToken);
        return Result<Guid>.Success(item.Id);
    }
}