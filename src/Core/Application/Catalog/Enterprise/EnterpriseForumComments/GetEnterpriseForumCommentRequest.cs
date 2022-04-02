using TD.CitizenAPI.Application.Identity.Users;

namespace TD.CitizenAPI.Application.Catalog.EnterpriseForumComments;

public class GetEnterpriseForumCommentRequest : IRequest<Result<EnterpriseForumCommentDetailsDto>>
{
    public Guid Id { get; set; }

    public GetEnterpriseForumCommentRequest(Guid id) => Id = id;
}

public class EnterpriseForumCommentByIdSpec : Specification<EnterpriseForumComment, EnterpriseForumCommentDetailsDto>, ISingleResultSpecification
{
    public EnterpriseForumCommentByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id)
        .Include(p => p.EnterpriseForumTopic)
        ;
}

public class GetEnterpriseForumCommentRequestHandler : IRequestHandler<GetEnterpriseForumCommentRequest, Result<EnterpriseForumCommentDetailsDto>>
{
    private readonly IRepository<EnterpriseForumComment> _repository;
    private readonly IUserService _userService;

    private readonly IStringLocalizer<GetEnterpriseForumCommentRequestHandler> _localizer;

    public GetEnterpriseForumCommentRequestHandler(IRepository<EnterpriseForumComment> repository, IUserService userService, IStringLocalizer<GetEnterpriseForumCommentRequestHandler> localizer) => (_repository, _userService, _localizer) = (repository, userService,localizer);

    public async Task<Result<EnterpriseForumCommentDetailsDto>> Handle(GetEnterpriseForumCommentRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetBySpecAsync(
            (ISpecification<EnterpriseForumComment, EnterpriseForumCommentDetailsDto>)new EnterpriseForumCommentByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["EnterpriseForumComment.notfound"], request.Id));

       
                if (item != null && !string.IsNullOrWhiteSpace(item.UserName))
                {
                    var tmp = await _userService.GetAsyncByUserName(item.UserName, cancellationToken);
                    item.FullName = tmp.FullName;
                    item.ImageUrl = tmp.ImageUrl;
                    item.PhoneNumber = tmp.PhoneNumber;
                }
     

        return Result<EnterpriseForumCommentDetailsDto>.Success(item);

    }
}