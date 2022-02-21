using Finbuckle.MultiTenant;
using TD.CitizenAPI.Application.Common.Events;
using TD.CitizenAPI.Application.Common.Interfaces;
using TD.CitizenAPI.Domain.Catalog;
using TD.CitizenAPI.Infrastructure.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace TD.CitizenAPI.Infrastructure.Persistence.Context;

public class ApplicationDbContext : BaseDbContext
{
    public ApplicationDbContext(ITenantInfo currentTenant, DbContextOptions options, ICurrentUser currentUser, ISerializerService serializer, IOptions<DatabaseSettings> dbSettings, IEventPublisher events)
        : base(currentTenant, options, currentUser, serializer, dbSettings, events)
    {
    }

    #region Other
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Brand> Brands => Set<Brand>();
    public DbSet<Attachment> Attachments => Set<Attachment>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Notification> Notifications => Set<Notification>();
    public DbSet<Feedback> Feedbacks => Set<Feedback>();
    public DbSet<HomePageInfor> HomePageInfors => Set<HomePageInfor>();

    #endregion Other

    #region Place
    public DbSet<PlaceType> PlaceTypes => Set<PlaceType>();
    public DbSet<Area> Areas => Set<Area>();
    public DbSet<Place> Places => Set<Place>();
    public DbSet<AreaInfor> AreaInfors => Set<AreaInfor>();
    public DbSet<AreaInforValue> AreaInforValues => Set<AreaInforValue>();

    #endregion Place

    #region Market
    public DbSet<MarketCategory> MarketCategories => Set<MarketCategory>();
    public DbSet<MarketProduct> MarketProducts => Set<MarketProduct>();
    #endregion Market

    #region Hotline
    public DbSet<HotlineCategory> HotlineCategories => Set<HotlineCategory>();
    public DbSet<Hotline> Hotlines => Set<Hotline>();
    #endregion Hotline

    #region Traffic
    public DbSet<VehicleType> VehicleTypes => Set<VehicleType>();
    public DbSet<Carpool> Carpools => Set<Carpool>();
    #endregion Traffic

    #region Company
    public DbSet<Benefit> Benefits => Set<Benefit>();
    public DbSet<Degree> Degrees => Set<Degree>();
    public DbSet<Experience> Experiences => Set<Experience>();
    public DbSet<Industry> Industries => Set<Industry>();
    public DbSet<JobAge> JobAges => Set<JobAge>();
    public DbSet<JobName> JobNames => Set<JobName>();
    public DbSet<JobPosition> JobPositions => Set<JobPosition>();
    public DbSet<JobType> JobTypes => Set<JobType>();
    public DbSet<Salary> Salaries => Set<Salary>();
    public DbSet<Recruitment> Recruitments => Set<Recruitment>();
    public DbSet<RecruitmentBenefit> RecruitmentBenefits => Set<RecruitmentBenefit>();
    public DbSet<Company> Companies => Set<Company>();
    public DbSet<CompanyIndustry> CompanyIndustries => Set<CompanyIndustry>();
    public DbSet<JobApplication> JobApplications => Set<JobApplication>();
    public DbSet<JobApplied> JobApplieds => Set<JobApplied>();
    public DbSet<JobSaved> JobSaveds => Set<JobSaved>();
    #endregion Company
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema(SchemaNames.Catalog);
    }
}