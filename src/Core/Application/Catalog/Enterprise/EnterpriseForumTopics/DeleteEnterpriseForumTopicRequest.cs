namespace TD.CitizenAPI.Application.Catalog.EnterpriseForumTopics;

public class DeleteEnterpriseForumTopicRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }

    public DeleteEnterpriseForumTopicRequest(Guid id) => Id = id;
}

public class DeleteEnterpriseForumTopicRequestHandler : IRequestHandler<DeleteEnterpriseForumTopicRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<EnterpriseForumTopic> _repository;
    private readonly IStringLocalizer<DeleteEnterpriseForumTopicRequestHandler> _localizer;

    public DeleteEnterpriseForumTopicRequestHandler(IRepositoryWithEvents<EnterpriseForumTopic> repository, IStringLocalizer<DeleteEnterpriseForumTopicRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(DeleteEnterpriseForumTopicRequest request, CancellationToken cancellationToken)
    {


        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(_localizer["EnterpriseForumTopic.notfound"]);

        await _repository.DeleteAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}