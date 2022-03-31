namespace TD.CitizenAPI.Application.Catalog.AlertInformations;

public partial class CreateAlertInformationRequest : IRequest<Result<Guid>>
{
    public string Title { get; set; } = default!;
    public string? Content { get; set; }
    public string? Description { get; set; }
    public bool? Active { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? FinishDate { get; set; }
    public int? Level { get; set; }
    public string? Image { get; set; }
    public string? File { get; set; }
    public Guid? AlertCategoryId { get; set; }
    public Guid? AlertOrganizationId { get; set; }
}



public class CreateAlertInformationRequestHandler : IRequestHandler<CreateAlertInformationRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<AlertInformation> _repository;

    public CreateAlertInformationRequestHandler(IRepositoryWithEvents<AlertInformation> repository) => _repository = repository;

    public async Task<Result<Guid>> Handle(CreateAlertInformationRequest request, CancellationToken cancellationToken)
    {
        var item = new AlertInformation(request.Title, request.Content, request.Description, request.Active, request.StartDate, request.FinishDate, request.Level, request.Image, request.File, request.AlertCategoryId, request.AlertOrganizationId);
        await _repository.AddAsync(item, cancellationToken);
        return Result<Guid>.Success(item.Id);
    }
}