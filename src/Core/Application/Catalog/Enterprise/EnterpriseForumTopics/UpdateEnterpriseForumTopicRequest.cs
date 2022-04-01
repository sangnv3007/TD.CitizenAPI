namespace TD.CitizenAPI.Application.Catalog.EnterpriseForumTopics;

public class UpdateEnterpriseForumTopicRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
    public string? UserName { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public string? Image { get; set; }

    public Guid? EnterpriseForumCategoryId { get; set; }
}



public class UpdateEnterpriseForumTopicRequestHandler : IRequestHandler<UpdateEnterpriseForumTopicRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<EnterpriseForumTopic> _repository;
    private readonly IStringLocalizer<UpdateEnterpriseForumTopicRequestHandler> _localizer;

    public UpdateEnterpriseForumTopicRequestHandler(IRepositoryWithEvents<EnterpriseForumTopic> repository, IStringLocalizer<UpdateEnterpriseForumTopicRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(UpdateEnterpriseForumTopicRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(string.Format(_localizer["EnterpriseForumTopic.notfound"], request.Id));

        item.Update(request.UserName, request.Title, request.Content, request.Image, request.EnterpriseForumCategoryId);

        await _repository.UpdateAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}