﻿namespace TD.CitizenAPI.Application.Catalog.Schools;

public class DeleteSchoolRequest : IRequest<Result<Guid>>
{
    public Guid Id { get; set; }

    public DeleteSchoolRequest(Guid id) => Id = id;
}

public class DeleteAgriculturalEngineeringCategoryRequestHandler : IRequestHandler<DeleteSchoolRequest, Result<Guid>>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<AgriculturalEngineeringCategory> _AgriculturalEngineeringCategoryRepo;
    private readonly IStringLocalizer<DeleteAgriculturalEngineeringCategoryRequestHandler> _localizer;

    public DeleteAgriculturalEngineeringCategoryRequestHandler(IRepositoryWithEvents<AgriculturalEngineeringCategory> AgriculturalEngineeringCategoryRepo, IStringLocalizer<DeleteAgriculturalEngineeringCategoryRequestHandler> localizer) =>
        (_AgriculturalEngineeringCategoryRepo, _localizer) = (AgriculturalEngineeringCategoryRepo, localizer);

    public async Task<Result<Guid>> Handle(DeleteSchoolRequest request, CancellationToken cancellationToken)
    {


        var item = await _AgriculturalEngineeringCategoryRepo.GetByIdAsync(request.Id, cancellationToken);

        _ = item ?? throw new NotFoundException(_localizer["AgriculturalEngineeringCategory.notfound"]);

        await _AgriculturalEngineeringCategoryRepo.DeleteAsync(item, cancellationToken);

        return Result<Guid>.Success(request.Id);
    }
}