namespace TD.CitizenAPI.Application.Catalog.DienTichNhas;

public partial class CreateDienTichNhaRequest : IRequest<Result<Guid>>
{
    public string Name { get; set; } = default!;
    public string? Code { get; set; }
   
    public string? Description { get; set; }
}

public class CreateDienTichNhaRequestValidator : CustomValidator<CreateDienTichNhaRequest>
{
    public CreateDienTichNhaRequestValidator(IReadRepository<DienTichNha> repository, IStringLocalizer<CreateDienTichNhaRequestValidator> localizer) =>
        RuleFor(p => p.Name).NotEmpty();
}

public class CreateDienTichNhaRequestHandler : IRequestHandler<CreateDienTichNhaRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<DienTichNha> _repository;

    public CreateDienTichNhaRequestHandler(IRepositoryWithEvents<DienTichNha> repository) => _repository = repository;

    public async Task<Result<Guid>> Handle(CreateDienTichNhaRequest request, CancellationToken cancellationToken)
    {
        var item = new DienTichNha(request.Name, request.Code,request.Description);
        await _repository.AddAsync(item, cancellationToken);
        return Result<Guid>.Success(item.Id);
    }
}