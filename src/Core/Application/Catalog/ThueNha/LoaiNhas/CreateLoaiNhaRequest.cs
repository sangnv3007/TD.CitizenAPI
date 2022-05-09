namespace TD.CitizenAPI.Application.Catalog.LoaiNhas;

public partial class CreateLoaiNhaRequest : IRequest<Result<Guid>>
{
    public string Name { get; set; } = default!;
    public string? Code { get; set; }
   
    public string? Description { get; set; }
}

public class CreateLoaiNhaRequestValidator : CustomValidator<CreateLoaiNhaRequest>
{
    public CreateLoaiNhaRequestValidator(IReadRepository<LoaiNha> repository, IStringLocalizer<CreateLoaiNhaRequestValidator> localizer) =>
        RuleFor(p => p.Name).NotEmpty();
}

public class CreateLoaiNhaRequestHandler : IRequestHandler<CreateLoaiNhaRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<LoaiNha> _repository;

    public CreateLoaiNhaRequestHandler(IRepositoryWithEvents<LoaiNha> repository) => _repository = repository;

    public async Task<Result<Guid>> Handle(CreateLoaiNhaRequest request, CancellationToken cancellationToken)
    {
        var item = new LoaiNha(request.Name, request.Code,request.Description);
        await _repository.AddAsync(item, cancellationToken);
        return Result<Guid>.Success(item.Id);
    }
}