
using Attribute = TD.CitizenAPI.Domain.Catalog.Attribute;

namespace TD.CitizenAPI.Application.Catalog.Attributes;

public class DeleteAttributeRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }

    public DeleteAttributeRequest(Guid id) => Id = id;
}

public class DeleteAttributeRequestHandler : IRequestHandler<DeleteAttributeRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Attribute> _repository;
    private readonly IStringLocalizer<DeleteAttributeRequestHandler> _localizer;

    public DeleteAttributeRequestHandler(IRepositoryWithEvents<Attribute> repository, IStringLocalizer<DeleteAttributeRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(DeleteAttributeRequest request, CancellationToken cancellationToken)
    {
        
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(_localizer["Attribute.notfound"]);

        await _repository.DeleteAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}