namespace TD.CitizenAPI.Application.Catalog.EnterpriseForumTopics;

public class GetEnterpriseForumTopicRequest : IRequest<Result<EnterpriseForumTopicDetailsDto>>
{
    public Guid Id { get; set; }

    public GetEnterpriseForumTopicRequest(Guid id) => Id = id;
}

public class EnterpriseForumTopicByIdSpec : Specification<EnterpriseForumTopic, EnterpriseForumTopicDetailsDto>, ISingleResultSpecification
{
    public EnterpriseForumTopicByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id)
        .Include(p => p.EnterpriseForumCategory)
        ;
}

public class GetEnterpriseForumTopicRequestHandler : IRequestHandler<GetEnterpriseForumTopicRequest, Result<EnterpriseForumTopicDetailsDto>>
{
    private readonly IRepository<EnterpriseForumTopic> _repository;
    private readonly IStringLocalizer<GetEnterpriseForumTopicRequestHandler> _localizer;

    public GetEnterpriseForumTopicRequestHandler(IRepository<EnterpriseForumTopic> repository, IStringLocalizer<GetEnterpriseForumTopicRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<Result<EnterpriseForumTopicDetailsDto>> Handle(GetEnterpriseForumTopicRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetBySpecAsync(
            (ISpecification<EnterpriseForumTopic, EnterpriseForumTopicDetailsDto>)new EnterpriseForumTopicByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["EnterpriseForumTopic.notfound"], request.Id));
        return Result<EnterpriseForumTopicDetailsDto>.Success(item);

    }
}