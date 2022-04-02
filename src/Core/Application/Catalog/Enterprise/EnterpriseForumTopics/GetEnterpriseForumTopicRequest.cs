using TD.CitizenAPI.Application.Identity.Users;

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
    private readonly IUserService _userService;

    private readonly IStringLocalizer<GetEnterpriseForumTopicRequestHandler> _localizer;

    public GetEnterpriseForumTopicRequestHandler(IRepository<EnterpriseForumTopic> repository, IUserService userService ,IStringLocalizer<GetEnterpriseForumTopicRequestHandler> localizer) => (_repository, _userService, _localizer) = (repository, userService,localizer);

    public async Task<Result<EnterpriseForumTopicDetailsDto>> Handle(GetEnterpriseForumTopicRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetBySpecAsync(
            (ISpecification<EnterpriseForumTopic, EnterpriseForumTopicDetailsDto>)new EnterpriseForumTopicByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["EnterpriseForumTopic.notfound"], request.Id));
        if (item != null && !string.IsNullOrWhiteSpace(item.UserName))
        {
            var tmp = await _userService.GetAsyncByUserName(item.UserName, cancellationToken);
            item.FullName = tmp.FullName;
            item.ImageUrl = tmp.ImageUrl;
            item.PhoneNumber = tmp.PhoneNumber;
        }
        return Result<EnterpriseForumTopicDetailsDto>.Success(item);

    }
}