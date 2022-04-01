namespace TD.CitizenAPI.Application.Catalog.EnterpriseForumComments;

public partial class CreateEnterpriseForumCommentRequest : IRequest<Result<Guid>>
{
    public string? UserName { get; set; }
    public string? Content { get; set; }

    public Guid? EnterpriseForumTopicId { get; set; }
}
public class CreateEnterpriseForumCommentRequestHandler : IRequestHandler<CreateEnterpriseForumCommentRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<EnterpriseForumComment> _repository;

    public CreateEnterpriseForumCommentRequestHandler(IRepositoryWithEvents<EnterpriseForumComment> repository) => _repository = repository;

    public async Task<Result<Guid>> Handle(CreateEnterpriseForumCommentRequest request, CancellationToken cancellationToken)
    {
        var item = new EnterpriseForumComment(request.UserName, request.Content,request.EnterpriseForumTopicId);
        await _repository.AddAsync(item, cancellationToken);
        return Result<Guid>.Success(item.Id);
    }
}