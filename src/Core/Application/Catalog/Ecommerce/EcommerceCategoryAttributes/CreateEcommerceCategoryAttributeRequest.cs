namespace TD.CitizenAPI.Application.Catalog.EcommerceCategoryAttributes;

public class CreateEcommerceCategoryAttributeRequest : IRequest<Result<Guid>>
{
    public Guid? EcommerceCategoryId { get; set; }
    public Guid? AttributeId { get; set; }
    public int Position { get; set; } = 0;

}

public class CreateEcommerceCategoryAttributeRequestValidator : CustomValidator<CreateEcommerceCategoryAttributeRequest>
{
    public CreateEcommerceCategoryAttributeRequestValidator(IReadRepository<EcommerceCategoryAttribute> repository, IStringLocalizer<CreateEcommerceCategoryAttributeRequestValidator> localizer) =>
        RuleFor(p => p.AttributeId).NotEmpty();
}

public class CreateEcommerceCategoryAttributeRequestHandler : IRequestHandler<CreateEcommerceCategoryAttributeRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<EcommerceCategoryAttribute> _repository;
    private readonly IStringLocalizer<CreateEcommerceCategoryAttributeRequestHandler> _localizer;

    public CreateEcommerceCategoryAttributeRequestHandler(IRepositoryWithEvents<EcommerceCategoryAttribute> repository, IStringLocalizer<CreateEcommerceCategoryAttributeRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(CreateEcommerceCategoryAttributeRequest request, CancellationToken cancellationToken)
    {
        var item = new EcommerceCategoryAttribute(request.EcommerceCategoryId,request.AttributeId, request.Position);

        await _repository.AddAsync(item, cancellationToken);
        return Result<Guid>.Success(item.Id);
    }
}