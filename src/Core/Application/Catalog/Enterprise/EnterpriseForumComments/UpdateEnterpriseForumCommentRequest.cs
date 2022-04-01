namespace TD.CitizenAPI.Application.Catalog.EnterpriseForumComments;

public class UpdateEnterpriseForumCommentRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
    public string? UserName { get; set; }
    public string? Content { get; set; }

    public Guid? EnterpriseForumTopicId { get; set; }
}



public class UpdateEnterpriseForumCommentRequestHandler : IRequestHandler<UpdateEnterpriseForumCommentRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<EnterpriseForumComment> _repository;
    private readonly IStringLocalizer<UpdateEnterpriseForumCommentRequestHandler> _localizer;

    public UpdateEnterpriseForumCommentRequestHandler(IRepositoryWithEvents<EnterpriseForumComment> repository, IStringLocalizer<UpdateEnterpriseForumCommentRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(UpdateEnterpriseForumCommentRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(string.Format(_localizer["EnterpriseForumComment.notfound"], request.Id));

        item.Update(request.UserName,  request.Content,request.EnterpriseForumTopicId);

        await _repository.UpdateAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}