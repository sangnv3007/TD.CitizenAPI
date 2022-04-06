namespace TD.CitizenAPI.Application.Catalog.Schools;

public class UpdateSchoolRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
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

public class UpdateSchoolRequestValidator : CustomValidator<UpdateSchoolRequest>
{
    public UpdateSchoolRequestValidator(IRepository<School> repository, IStringLocalizer<UpdateSchoolRequestValidator> localizer) =>
        RuleFor(p => p.Name)
            .NotEmpty();
}

public class UpdateSchoolRequestHandler : IRequestHandler<UpdateSchoolRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<School> _repository;
    private readonly IStringLocalizer<UpdateSchoolRequestHandler> _localizer;

    public UpdateSchoolRequestHandler(IRepositoryWithEvents<School> repository, IStringLocalizer<UpdateSchoolRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(UpdateSchoolRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(string.Format(_localizer["School.notfound"], request.Id));

        item.Update(request.Name, request.Code, request.PhoneNumber, request.Principal, request.PrincipalPhone, request.Category, request.Type, request.Department, request.Size, request.Standard, request.Address, request.District, request.Province, request.Ward, request.Description, request.Image);

        await _repository.UpdateAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}