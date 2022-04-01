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
    private readonly IStringLocalizer<GetEnterpriseForumCommentRequestHandler> _localizer;

    public GetEnterpriseForumCommentRequestHandler(IRepository<EnterpriseForumComment> repository, IStringLocalizer<GetEnterpriseForumCommentRequestHandler> localizer) => (_repository, _localizer) = (repository, localizer);

    public async Task<Result<EnterpriseForumCommentDetailsDto>> Handle(GetEnterpriseForumCommentRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetBySpecAsync(
            (ISpecification<EnterpriseForumComment, EnterpriseForumCommentDetailsDto>)new EnterpriseForumCommentByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(string.Format(_localizer["EnterpriseForumComment.notfound"], request.Id));
        return Result<EnterpriseForumCommentDetailsDto>.Success(item);

    }
}