namespace TD.CitizenAPI.Application.Catalog.Feedbacks;

public class SearchFeedbacksRequest : PaginationFilter, IRequest<PaginationResponse<FeedbackDto>>
{
    public string? UserName { get; set; }
}

public class FeedbackBySearchRequestSpec : EntitiesByPaginationFilterSpec<Feedback, FeedbackDto>
{
    public FeedbackBySearchRequestSpec(SearchFeedbacksRequest request)
        : base(request) =>
        Query.OrderBy(c => c.CreatedOn, !request.HasOrderBy())
        .Where(p => p.UserName.Equals(request.UserName), request.UserName is not null);
}

public class SearchFeedbacksRequestHandler : IRequestHandler<SearchFeedbacksRequest, PaginationResponse<FeedbackDto>>
{
    private readonly IReadRepository<Feedback> _repository;

    public SearchFeedbacksRequestHandler(IReadRepository<Feedback> repository) => _repository = repository;

    public async Task<PaginationResponse<FeedbackDto>> Handle(SearchFeedbacksRequest request, CancellationToken cancellationToken)
    {
        var spec = new FeedbackBySearchRequestSpec(request);

        var list = await _repository.ListAsync(spec, cancellationToken);
        int count = await _repository.CountAsync(spec, cancellationToken);

        return new PaginationResponse<FeedbackDto>(list, count, request.PageNumber, request.PageSize);
    }
}