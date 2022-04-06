namespace TD.CitizenAPI.Application.Catalog.Schools;

public partial class CreateSchoolRequest : IRequest<Result<Guid>>
{
    public string Name { get; set; } = default!;
    public string? Code { get; set; }
    public string? PhoneNumber { get; set; }
    //Hieu truong
    public string? Principal { get; set; }
    //So dien thoai hieu truong
    public string? PrincipalPhone { get; set; }
    public string? Category { get; set; }
    //Loai hinh
    public string? Type { get; set; }
    //Phong giao duc va dao tao
    public string? Department { get; set; }
    //Quy Mo
    public string? Size { get; set; }
    //Chuan quoc gua muc do
    public string? Standard { get; set; }
    public string? Address { get; set; }
    public string? District { get; set; }
    public string? Province { get; set; }
    public string? Ward { get; set; }
    public string? Description { get; set; }

    public string? Image { get; set; }
}

public class CreateSchoolRequestValidator : CustomValidator<CreateSchoolRequest>
{
    public CreateSchoolRequestValidator(IReadRepository<School> repository, IStringLocalizer<CreateSchoolRequestValidator> localizer) =>
        RuleFor(p => p.Name).NotEmpty();
}

public class CreateSchoolRequestHandler : IRequestHandler<CreateSchoolRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<School> _repository;

    public CreateSchoolRequestHandler(IRepositoryWithEvents<School> repository) => _repository = repository;

    public async Task<Result<Guid>> Handle(CreateSchoolRequest request, CancellationToken cancellationToken)
    {
        var item = new School(request.Name,request.Code,request.PhoneNumber,request.Principal,request.PrincipalPhone,request.Category,request.Type,request.Department,request.Size,request.Standard,request.Address,request.District,request.Province, request.Ward, request.Description, request.Image);
        await _repository.AddAsync(item, cancellationToken);
        return Result<Guid>.Success(item.Id);
    }
}