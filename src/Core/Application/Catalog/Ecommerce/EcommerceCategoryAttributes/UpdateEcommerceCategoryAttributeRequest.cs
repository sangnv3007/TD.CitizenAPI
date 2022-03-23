namespace TD.CitizenAPI.Application.Catalog.EcommerceCategoryAttributes;

public class UpdateEcommerceCategoryAttributeRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
    public Guid? EcommerceCategoryId { get; set; }
    public Guid? AttributeId { get; set; }
    public int Position { get; set; } = 0;



    public class UpdateEcommerceCategoryAttributeRequestHandler : IRequestHandler<UpdateEcommerceCategoryAttributeRequest, Result<Guid>>
    {
        // Add Domain Events automatically by using IRepositoryWithEvents
        private readonly IRepositoryWithEvents<EcommerceCategoryAttribute> _repository;
        private readonly IStringLocalizer<UpdateEcommerceCategoryAttributeRequestHandler> _localizer;

        public UpdateEcommerceCategoryAttributeRequestHandler(IRepositoryWithEvents<EcommerceCategoryAttribute> repository, IStringLocalizer<UpdateEcommerceCategoryAttributeRequestHandler> localizer) =>
            (_repository, _localizer) = (repository, localizer);

        public async Task<Result<Guid>> Handle(UpdateEcommerceCategoryAttributeRequest request, CancellationToken cancellationToken)
        {
            var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

            _ = item ?? throw new NotFoundException(string.Format(_localizer["EcommerceCategoryAttribute.notfound"], request.Id));

            item.Update(request.EcommerceCategoryId, request.AttributeId, request.Position);

            await _repository.UpdateAsync(item, cancellationToken);

            return Result<Guid>.Success(request.Id);
        }
    }
}