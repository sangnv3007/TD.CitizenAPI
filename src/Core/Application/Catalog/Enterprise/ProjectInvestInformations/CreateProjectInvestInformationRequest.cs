namespace TD.CitizenAPI.Application.Catalog.ProjectInvestInformations;

public partial class CreateProjectInvestInformationRequest : IRequest<Result<Guid>>
{
    public string Title { get; set; } = default!;
    public string? Content { get; set; }
    //Quy mo
    public string? Scale { get; set; }
    //Dia diem
    public string? Location { get; set; }
    //Muc tieu
    public string? Target { get; set; }
    //hien trang
    public string? State { get; set; }
    public string? Image { get; set; }
    public string? Source { get; set; }
    //Hinh thuc lua chon nha dau tu
    public string? InvestmentForm { get; set; }
    //Co quan chu tri
    public string? Investor { get; set; }
    //chuc nang muc dich su dung
    public string? FunctionContent { get; set; }
    //Chi tieu quy hoach
    public string? Plan { get; set; }
    public int? ViewQuantity { get; set; }

    public Guid? ProjectInvestCategoryId { get; set; }
    public Guid? ProjectInvestFormId { get; set; }


}
public class CreateProjectInvestInformationRequestHandler : IRequestHandler<CreateProjectInvestInformationRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<ProjectInvestInformation> _repository;

    public CreateProjectInvestInformationRequestHandler(IRepositoryWithEvents<ProjectInvestInformation> repository) => _repository = repository;

    public async Task<Result<Guid>> Handle(CreateProjectInvestInformationRequest request, CancellationToken cancellationToken)
    {
        var item = new ProjectInvestInformation(request.Title, request.Content, request.Scale, request.Location, request.Target, request.State, request.Image, request.Source, request.InvestmentForm, request.Investor, request.FunctionContent, request.Plan, request.ViewQuantity, request.ProjectInvestCategoryId, request.ProjectInvestFormId);
        await _repository.AddAsync(item, cancellationToken);
        return Result<Guid>.Success(item.Id);
    }
}