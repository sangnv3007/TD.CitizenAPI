
using Attribute = TD.CitizenAPI.Domain.Catalog.Attribute;

namespace TD.CitizenAPI.Application.Catalog.AttributeValues;

public class DeleteAttributeValueRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }

    public DeleteAttributeValueRequest(Guid id) => Id = id;
}

public class DeleteAttributeValueRequestHandler : IRequestHandler<DeleteAttributeValueRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<AttributeValue> _repository;
    private readonly IStringLocalizer<DeleteAttributeValueRequestHandler> _localizer;

    public DeleteAttributeValueRequestHandler(IRepositoryWithEvents<AttributeValue> repository, IStringLocalizer<DeleteAttributeValueRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(DeleteAttributeValueRequest request, CancellationToken cancellationToken)
    {
        
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(_localizer["AttributeValue.notfound"]);

        await _repository.DeleteAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}