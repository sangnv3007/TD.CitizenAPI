namespace TD.CitizenAPI.Application.Catalog.Feedbacks;

public partial class CreateFeedbackRequest : IRequest<Result<Guid>>
{
    public string UserName { get; set; } = default!;
    public int Rate { get; set; }
    public string? Description { get; set; }
    public string? Content { get; set; }

    public class CreateHomePageInforRequestValidator : CustomValidator<CreateFeedbackRequest>
{
    public CreateHomePageInforRequestValidator(IReadRepository<HomePageInfor> repository, IStringLocalizer<CreateHomePageInforRequestValidator> localizer) =>
        RuleFor(p => p.UserName).NotEmpty();
}

    public class CreateFeedbackRequestHandler : IRequestHandler<CreateFeedbackRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Feedback> _repository;

    public CreateFeedbackRequestHandler(IRepositoryWithEvents<Feedback> repository) => _repository = repository;

    public async Task<Result<Guid>> Handle(CreateFeedbackRequest request, CancellationToken cancellationToken)
    {
        var item = new Feedback(request.UserName,request.Rate, request.Description, request.Content, 0);
        await _repository.AddAsync(item, cancellationToken);
        return Result<Guid>.Success(item.Id);
    }
}