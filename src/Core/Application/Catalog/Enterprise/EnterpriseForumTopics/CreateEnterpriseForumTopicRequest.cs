namespace TD.CitizenAPI.Application.Catalog.EnterpriseForumTopics;

public partial class CreateEnterpriseForumTopicRequest : IRequest<Result<Guid>>
{
    public string? UserName { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public string? Image { get; set; }

    public Guid? EnterpriseForumCategoryId { get; set; }
}
public class CreateEnterpriseForumTopicRequestHandler : IRequestHandler<CreateEnterpriseForumTopicRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<EnterpriseForumTopic> _repository;

    public CreateEnterpriseForumTopicRequestHandler(IRepositoryWithEvents<EnterpriseForumTopic> repository) => _repository = repository;

    public async Task<Result<Guid>> Handle(CreateEnterpriseForumTopicRequest request, CancellationToken cancellationToken)
    {
        var item = new EnterpriseForumTopic(request.UserName, request.Title,request.Content,request.Image,request.EnterpriseForumCategoryId);
        await _repository.AddAsync(item, cancellationToken);
        return Result<Guid>.Success(item.Id);
    }
}