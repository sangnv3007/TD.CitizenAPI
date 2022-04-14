namespace TD.CitizenAPI.Application.Catalog.FoodFactories;

public class UpdateFoodFactoryRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Address { get; set; }
    //Linh vuc kinh doanh
    public string? BusinessArea { get; set; }

    //So chung nhan
    public string? CertificationNumber { get; set; }
    public string? Image { get; set; }
    public string? Images { get; set; }
    public string? Description { get; set; }
    //Chu co so
    public string? OwnerName { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? TaxCode { get; set; }
    //Dia chi cong ty
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public string? Files { get; set; }
    //Ngay cap
    public DateTime? DateOfIssue { get; set; }
    //Ngay het han
    public DateTime? ExpirationDate { get; set; }
}

public class UpdateFoodFactoryRequestValidator : CustomValidator<UpdateFoodFactoryRequest>
{
    public UpdateFoodFactoryRequestValidator(IRepository<FoodFactory> repository, IStringLocalizer<UpdateFoodFactoryRequestValidator> localizer) =>
        RuleFor(p => p.Name)
            .NotEmpty();
}

public class UpdateFoodFactoryRequestHandler : IRequestHandler<UpdateFoodFactoryRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<FoodFactory> _repository;
    private readonly IStringLocalizer<UpdateFoodFactoryRequestHandler> _localizer;

    public UpdateFoodFactoryRequestHandler(IRepositoryWithEvents<FoodFactory> repository, IStringLocalizer<UpdateFoodFactoryRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(UpdateFoodFactoryRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(string.Format(_localizer["FoodFactory.notfound"], request.Id));

        item.Update(request.Name, request.Address, request.BusinessArea, request.CertificationNumber, request.Image, request.Images, request.Description, request.OwnerName, request.Email, request.Phone, request.TaxCode, request.Latitude, request.Longitude, request.Files, request.DateOfIssue, request.ExpirationDate);

        await _repository.UpdateAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}