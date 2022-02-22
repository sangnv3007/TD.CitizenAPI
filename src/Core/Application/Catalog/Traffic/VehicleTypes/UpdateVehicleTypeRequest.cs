namespace TD.CitizenAPI.Application.Catalog.VehicleTypes;

public class UpdateVehicleTypeRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Code { get; set; }
    public string? Icon { get; set; }
    public int? SeatCount { get; set; }
    public string? Description { get; set; }
}

public class UpdateVehicleTypeRequestValidator : CustomValidator<UpdateVehicleTypeRequest>
{
    public UpdateVehicleTypeRequestValidator(IRepository<VehicleType> repository, IStringLocalizer<UpdateVehicleTypeRequestValidator> localizer) =>
        RuleFor(p => p.Name)
            .NotEmpty();
}

public class UpdateVehicleTypeRequestHandler : IRequestHandler<UpdateVehicleTypeRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<VehicleType> _repository;
    private readonly IStringLocalizer<UpdateVehicleTypeRequestHandler> _localizer;

    public UpdateVehicleTypeRequestHandler(IRepositoryWithEvents<VehicleType> repository, IStringLocalizer<UpdateVehicleTypeRequestHandler> localizer) =>
        (_repository, _localizer) = (repository, localizer);

    public async Task<Result<Guid>> Handle(UpdateVehicleTypeRequest request, CancellationToken cancellationToken)
    {
        var item = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(string.Format(_localizer["marketcategory.notfound"], request.Id));

        item.Update(request.Name, request.Code, request.Icon, request.SeatCount, request.Description);

        await _repository.UpdateAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}