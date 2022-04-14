namespace TD.CitizenAPI.Application.Catalog.FoodFactories;

public partial class CreateFoodFactoryRequest : IRequest<Result<Guid>>
{
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

public class CreateFoodFactoryRequestValidator : CustomValidator<CreateFoodFactoryRequest>
{
    public CreateFoodFactoryRequestValidator(IReadRepository<FoodFactory> repository, IStringLocalizer<CreateFoodFactoryRequestValidator> localizer) =>
        RuleFor(p => p.Name).NotEmpty();
}

public class CreateFoodFactoryRequestHandler : IRequestHandler<CreateFoodFactoryRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<FoodFactory> _repository;

    public CreateFoodFactoryRequestHandler(IRepositoryWithEvents<FoodFactory> repository) => _repository = repository;

    public async Task<Result<Guid>> Handle(CreateFoodFactoryRequest request, CancellationToken cancellationToken)
    {
        var item = new FoodFactory(request.Name,request.Address,request.BusinessArea,request.CertificationNumber,request.Image,request.Images,request.Description,request.OwnerName,request.Email,request.Phone,request.TaxCode,request.Latitude,request.Longitude,request.Files,request.DateOfIssue,request.ExpirationDate);
        await _repository.AddAsync(item, cancellationToken);
        return Result<Guid>.Success(item.Id);
    }
}