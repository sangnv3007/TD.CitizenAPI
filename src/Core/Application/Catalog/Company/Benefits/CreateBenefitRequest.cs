namespace TD.CitizenAPI.Application.Catalog.Benefits;

public class CreateBenefitRequest : IRequest<Result<Guid>>
{
    public string Name { get; set; } = default!;
    public string? Code { get; set; }
    public string? Icon { get; set; }
    public string? Description { get; set; }
}

public class CreateBenefitRequestValidator : CustomValidator<CreateBenefitRequest>
{
    public CreateBenefitRequestValidator(IReadRepository<Benefit> repository, IStringLocalizer<CreateBenefitRequestValidator> localizer) =>
        RuleFor(p => p.Name).NotEmpty();
}

public class CreateBenefitRequestHandler : IRequestHandler<CreateBenefitRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Benefit> _repository;

    public CreateBenefitRequestHandler(IRepositoryWithEvents<Benefit> repository) => _repository = repository;

    public async Task<Result<Guid>> Handle(CreateBenefitRequest request, CancellationToken cancellationToken)
    {
        var item = new Benefit(request.Name, request.Code, request.Icon, request.Description);
        await _repository.AddAsync(item, cancellationToken);
        return Result<Guid>.Success(item.Id);
    }
}