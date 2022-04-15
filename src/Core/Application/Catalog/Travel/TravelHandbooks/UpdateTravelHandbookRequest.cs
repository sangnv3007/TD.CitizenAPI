namespace TD.CitizenAPI.Application.Catalog.TravelHandbooks;

public class UpdateTravelHandbookRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Content { get; set; }
    public string? Description { get; set; }
    public string? Image { get; set; }
    public string? Source { get; set; }
    public string? Tags { get; set; }
}

public class UpdateTravelHandbookRequestValidator : CustomValidator<UpdateTravelHandbookRequest>
{
    public UpdateTravelHandbookRequestValidator(IRepository<TravelHandbook> repository, IStringLocalizer<UpdateTravelHandbookRequestValidator> localizer) =>
        RuleFor(p => p.Name)
            .NotEmpty();
}

public class UpdateTravelHandbookRequestHandler : IRequestHandler<UpdateTravelHandbookRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<TravelHandbook> _repository;
    private readonly IStringLocalizer<UpdateTravelHandbookRequestHandler> _localizer;

    public UpdateTravelHandbookRequestHandler(IRepositoryWithEvents<TravelHandbook> repository, IStringLocalizer<UpdateTravelHandbookRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(UpdateTravelHandbookRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(string.Format(_localizer["TravelHandbook.notfound"], request.Id));

        item.Update(request.Name, request.Content,request.Description,request.Image,request.Source,request.Tags);

        await _repository.UpdateAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}