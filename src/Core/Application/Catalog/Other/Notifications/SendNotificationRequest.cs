namespace TD.CitizenAPI.Application.Catalog.Notifications;

public class SendNotificationRequest : IRequest<string>
{
    public List<string> Topics { get; set; } = default!;
    public string Body { get; set; } = default!;
    public string Title { get; set; } = default!;
    public string? Data { get; set; }
    public string? AppType { get; set; }
    public string? AreaCode { get; set; }
    public string? ImageUrl { get; set; }
    public string? CollapseKey { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public double? Distance { get; set; }
}

public class SendNotificationHandler : IRequestHandler<SendNotificationRequest, string>
{
    private readonly IJobService _jobService;

    public SendNotificationHandler(IJobService jobService) => _jobService = jobService;

    public Task<string> Handle(SendNotificationRequest request, CancellationToken cancellationToken)
    {
        string jobId = _jobService.Enqueue<ISendNotificationJob>(x => x.SendNotificationAsync(request,default));
        return Task.FromResult(jobId);
    }
}