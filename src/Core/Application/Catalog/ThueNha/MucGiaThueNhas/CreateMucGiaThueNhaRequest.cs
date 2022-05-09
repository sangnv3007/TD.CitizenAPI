namespace TD.CitizenAPI.Application.Catalog.MucGiaThueNhas;

public partial class CreateMucGiaThueNhaRequest : IRequest<Result<Guid>>
{
    public string Name { get; set; } = default!;
    public string? Code { get; set; }
   
    public string? Description { get; set; }
}

public class CreateMucGiaThueNhaRequestValidator : CustomValidator<CreateMucGiaThueNhaRequest>
{
    public CreateMucGiaThueNhaRequestValidator(IReadRepository<MucGiaThueNha> repository, IStringLocalizer<CreateMucGiaThueNhaRequestValidator> localizer) =>
        RuleFor(p => p.Name).NotEmpty();
}

public class CreateMucGiaThueNhaRequestHandler : IRequestHandler<CreateMucGiaThueNhaRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<MucGiaThueNha> _repository;

    public CreateMucGiaThueNhaRequestHandler(IRepositoryWithEvents<MucGiaThueNha> repository) => _repository = repository;

    public async Task<Result<Guid>> Handle(CreateMucGiaThueNhaRequest request, CancellationToken cancellationToken)
    {
        var item = new MucGiaThueNha(request.Name, request.Code,request.Description);
        await _repository.AddAsync(item, cancellationToken);
        return Result<Guid>.Success(item.Id);
    }
}