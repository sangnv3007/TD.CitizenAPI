namespace TD.CitizenAPI.Application.Catalog.EnterpriseForumComments;

public class DeleteEnterpriseForumCommentRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }

    public DeleteEnterpriseForumCommentRequest(Guid id) => Id = id;
}

public class DeleteEnterpriseForumCommentRequestHandler : IRequestHandler<DeleteEnterpriseForumCommentRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<EnterpriseForumComment> _repository;
    private readonly IStringLocalizer<DeleteEnterpriseForumCommentRequestHandler> _localizer;

    public DeleteEnterpriseForumCommentRequestHandler(IRepositoryWithEvents<EnterpriseForumComment> repository, IStringLocalizer<DeleteEnterpriseForumCommentRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(DeleteEnterpriseForumCommentRequest request, CancellationToken cancellationToken)
    {


        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(_localizer["EnterpriseForumComment.notfound"]);

        await _repository.DeleteAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}