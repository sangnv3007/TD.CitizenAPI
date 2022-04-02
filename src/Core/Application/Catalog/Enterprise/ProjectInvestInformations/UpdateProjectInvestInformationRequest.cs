namespace TD.CitizenAPI.Application.Catalog.ProjectInvestInformations;

public class UpdateProjectInvestInformationRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
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



public class UpdateProjectInvestInformationRequestHandler : IRequestHandler<UpdateProjectInvestInformationRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<ProjectInvestInformation> _repository;
    private readonly IStringLocalizer<UpdateProjectInvestInformationRequestHandler> _localizer;

    public UpdateProjectInvestInformationRequestHandler(IRepositoryWithEvents<ProjectInvestInformation> repository, IStringLocalizer<UpdateProjectInvestInformationRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(UpdateProjectInvestInformationRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(string.Format(_localizer["ProjectInvestInformation.notfound"], request.Id));

        item.Update(request.Title, request.Content, request.Scale, request.Location, request.Target, request.State, request.Image, request.Source, request.InvestmentForm, request.Investor, request.FunctionContent, request.Plan, request.ViewQuantity, request.ProjectInvestCategoryId, request.ProjectInvestFormId);

        await _repository.UpdateAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}