using Attribute = TD.CitizenAPI.Domain.Catalog.Attribute;

namespace TD.CitizenAPI.Application.Catalog.Attributes;

public class UpdateAttributeRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
    public string? Code { get; set; } 
    public string? DisplayName { get; set; } 
    public string? Description { get; set; }
    public bool? IsVisibleOnFront { get; set; }
    public bool? IsRequired { get; set; }
    public bool? IsFilterable { get; set; }
    public bool? IsSearchable { get; set; } 
    public bool? IsEditable { get; set; } 
    public bool? IsSellerEditable { get; set; }
    public string? DefaultValue { get; set; }
    /*public FrontendInput FrontendInput { get; set; }
    //Datatype : int, decimal, varchar, text, datetime
    public DataType DataType { get; set; }
    public FrontendInput InputType { get; set; }*/
    public string? FrontendInput { get; set; } 
    public string? DataType { get; set; } 
    public string? InputType { get; set; } 

    public bool? IsActive { get; set; }
}

public class UpdateAttributeRequestValidator : CustomValidator<UpdateAttributeRequest>
{
    public UpdateAttributeRequestValidator(IRepository<Attribute> repository, IStringLocalizer<UpdateAttributeRequestValidator> localizer)
    {
       
        RuleFor(p => p.Code)
               .NotEmpty()
               .MaximumLength(75)
               .MustAsync(async (category, code, ct) =>
                       await repository.GetBySpecAsync(new AttributeByCodeSpec(code), ct)
                           is not Attribute existingCategory || existingCategory.Id == category.Id)
                   .WithMessage((_, code) => string.Format(localizer["area.alreadyexists"], code));
    }
}

public class UpdateAttributeRequestHandler : IRequestHandler<UpdateAttributeRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Attribute> _repository;
    private readonly IStringLocalizer<UpdateAttributeRequestHandler> _localizer;

    public UpdateAttributeRequestHandler(IRepositoryWithEvents<Attribute> repository, IStringLocalizer<UpdateAttributeRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(UpdateAttributeRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(string.Format(_localizer["hotlinecategory.notfound"], request.Id));

        item.Update(request.Code, request.DisplayName, request.Description, request.IsSearchable, request.IsRequired, request.IsFilterable, request.IsSearchable, request.IsEditable, request.IsSellerEditable, request.DefaultValue, request.FrontendInput, request.DataType, request.InputType, request.IsActive);

        await _repository.UpdateAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}