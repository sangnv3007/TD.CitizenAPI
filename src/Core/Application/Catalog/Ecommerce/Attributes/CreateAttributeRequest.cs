namespace TD.CitizenAPI.Application.Catalog.Attributes;

public class CreateAttributeRequest : IRequest<Result<Guid>>
{
    public string Code { get; set; } = default!;
    public string DisplayName { get; set; } = default!;
    public string? Description { get; set; }
    public bool IsVisibleOnFront { get; set; } = true;
    public bool IsRequired { get; set; } = false;
    public bool IsFilterable { get; set; } = false;
    public bool IsSearchable { get; set; } = false;
    public bool IsEditable { get; set; } = true;
    public bool IsSellerEditable { get; set; } = true;
    public string? DefaultValue { get; set; }
    /*public FrontendInput FrontendInput { get; set; }
    //Datatype : int, decimal, varchar, text, datetime
    public DataType DataType { get; set; }
    public FrontendInput InputType { get; set; }*/
    public string? FrontendInput { get; set; }
    public string DataType { get; set; } = default!;
    public string InputType { get; set; } = default!;

    public bool IsActive { get; set; } = true;
}

public class CreateAttributeRequestValidator : CustomValidator<CreateAttributeRequest>
{
    public CreateAttributeRequestValidator(IReadRepository<Domain.Catalog.Attribute> repository, IStringLocalizer<CreateAttributeRequestValidator> localizer)
    {
        RuleFor(p => p.DisplayName).NotEmpty();
        RuleFor(p => p.Code)
                    .NotEmpty()
                    .MaximumLength(256)
                    .MustAsync(async (code, ct) => await repository.GetBySpecAsync(new AttributeByCodeSpec(code), ct) is null)
                        .WithMessage((_, name) => string.Format(localizer["Attribute.alreadyexists"], name));
    }
}

public class CreateAttributeRequestHandler : IRequestHandler<CreateAttributeRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Domain.Catalog.Attribute> _repository;

    public CreateAttributeRequestHandler(IRepositoryWithEvents<Domain.Catalog.Attribute> repository) => _repository = repository;

    public async Task<Result<Guid>> Handle(CreateAttributeRequest request, CancellationToken cancellationToken)
    {
        var item = new Domain.Catalog.Attribute(request.Code, request.DisplayName, request.Description, request.IsSearchable, request.IsRequired, request.IsFilterable, request.IsSearchable, request.IsEditable, request.IsSellerEditable, request.DefaultValue, request.FrontendInput ?? string.Empty, request.DataType, request.InputType, request.IsActive);
        await _repository.AddAsync(item, cancellationToken);
        return Result<Guid>.Success(item.Id);
    }
}