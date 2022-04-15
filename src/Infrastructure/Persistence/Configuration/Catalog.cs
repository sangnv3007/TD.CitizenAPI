using Finbuckle.MultiTenant.EntityFrameworkCore;
using TD.CitizenAPI.Domain.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TD.CitizenAPI.Infrastructure.Persistence.Configuration;

#region Other

public class AttachmentConfig : IEntityTypeConfiguration<Attachment>
{
    public void Configure(EntityTypeBuilder<Attachment> builder)
    {
        builder.IsMultiTenant();
        builder.Property(b => b.Name).HasMaxLength(256);
        builder.Property(b => b.Type).HasMaxLength(256);
        builder.Property(b => b.Url).HasMaxLength(512);
    }
}

public class EKYCAttachmentConfig : IEntityTypeConfiguration<EKYCAttachment>
{
    public void Configure(EntityTypeBuilder<EKYCAttachment> builder)
    {
        builder.IsMultiTenant();
        builder.Property(b => b.FileName).HasMaxLength(512);
        builder.Property(b => b.FileType).HasMaxLength(256);
        builder.Property(b => b.Url).HasMaxLength(512);
    }
}


public class CategoryConfig : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.IsMultiTenant();
        builder.Property(b => b.Name).HasMaxLength(256);
        builder.Property(b => b.Code).HasMaxLength(256);
        builder.Property(b => b.Icon).HasMaxLength(256);
        builder.Property(b => b.Image).HasMaxLength(1024);
        builder.Property(b => b.CoverImage).HasMaxLength(1024);
        builder.Property(b => b.Description).HasMaxLength(1024);
    }
}

public class FeedbackConfig : IEntityTypeConfiguration<Feedback>
{
    public void Configure(EntityTypeBuilder<Feedback> builder)
    {
        builder.IsMultiTenant();
        builder.Property(b => b.UserName).HasMaxLength(256);
        builder.Property(b => b.Description).HasMaxLength(1024);
        builder.Property(b => b.Content).HasMaxLength(1024);
    }
}
public class NotificationConfig : IEntityTypeConfiguration<Notification>
{
    public void Configure(EntityTypeBuilder<Notification> builder)
    {
        builder.IsMultiTenant();
        builder.Property(b => b.UserName).HasMaxLength(256);
        builder.Property(b => b.Body).HasMaxLength(2048);
        builder.Property(b => b.Title).HasMaxLength(1024);
        builder.Property(b => b.Data).HasMaxLength(1024);
        builder.Property(b => b.AppType).HasMaxLength(256);
        builder.Property(b => b.Code).HasMaxLength(256);
        builder.Property(b => b.AreaCode).HasMaxLength(256);
    }
}
public class HomepageInforConfig : IEntityTypeConfiguration<HomePageInfor>
{
    public void Configure(EntityTypeBuilder<HomePageInfor> builder)
    {
        builder.IsMultiTenant();
        builder.Property(b => b.ImagePad).HasMaxLength(256);
        builder.Property(b => b.Image).HasMaxLength(256);
        builder.Property(b => b.Url).HasMaxLength(512);
        builder.Property(b => b.Title).HasMaxLength(256);
    }
}
#endregion Other

#region Place
public class PlaceTypeConfig : IEntityTypeConfiguration<PlaceType>
{
    public void Configure(EntityTypeBuilder<PlaceType> builder)
    {
        builder.IsMultiTenant();
        builder.Property(b => b.Name).HasMaxLength(256);
        builder.Property(b => b.Code).HasMaxLength(256);
        builder.Property(b => b.Icon).HasMaxLength(256);
        builder.Property(b => b.Image).HasMaxLength(1024);
        builder.Property(b => b.CoverImage).HasMaxLength(1024);
        builder.Property(b => b.Description).HasMaxLength(1024);
    }
}

public class AreaConfig : IEntityTypeConfiguration<Area>
{
    public void Configure(EntityTypeBuilder<Area> builder)
    {
        builder.IsMultiTenant();
        builder.Property(b => b.Name).HasMaxLength(256);
        builder.Property(b => b.Code).HasMaxLength(256);
        builder.Property(b => b.ParentCode).HasMaxLength(256);
        builder.Property(b => b.Slug).HasMaxLength(256);
        builder.Property(b => b.Path).HasMaxLength(256);
        builder.Property(b => b.PathWithType).HasMaxLength(256);
        builder.Property(b => b.NameWithType).HasMaxLength(256);
        builder.Property(b => b.Description).HasMaxLength(1024);
    }
}

public class PlaceConfig : IEntityTypeConfiguration<Place>
{
    public void Configure(EntityTypeBuilder<Place> builder)
    {
        builder.IsMultiTenant();
        builder.Property(b => b.PlaceName).HasMaxLength(1024);
        builder.Property(b => b.Title).HasMaxLength(1024);
        builder.Property(b => b.AddressDetail).HasMaxLength(1024);
        builder.Property(b => b.Source).HasMaxLength(256);
        builder.Property(b => b.ExtraInfo).HasMaxLength(1024);
        builder.Property(b => b.PhoneContact).HasMaxLength(1024);
        builder.Property(b => b.Website).HasMaxLength(256);
        builder.Property(b => b.Email).HasMaxLength(256);
        builder.Property(x => x.Latitude).HasColumnType("Decimal(8,6)");
        builder.Property(x => x.Longitude).HasColumnType("Decimal(9,6)");
        builder.Property(b => b.Tags).HasMaxLength(256);
        builder.Property(b => b.Status).HasMaxLength(256);
        builder.Property(b => b.Image).HasMaxLength(1024);
    }
}

public class AreaInforConfig : IEntityTypeConfiguration<AreaInfor>
{
    public void Configure(EntityTypeBuilder<AreaInfor> builder)
    {
        builder.IsMultiTenant();
        builder.Property(b => b.AreaCode).HasMaxLength(256);
        builder.Property(b => b.Acreage).HasMaxLength(256);
        builder.Property(b => b.Population).HasMaxLength(256);
        builder.Property(b => b.Image).HasMaxLength(1024);
        builder.Property(b => b.Images).HasMaxLength(2048);
    }
}

public class AreaInforValueConfig : IEntityTypeConfiguration<AreaInforValue>
{
    public void Configure(EntityTypeBuilder<AreaInforValue> builder)
    {
        builder.IsMultiTenant();
        builder.Property(b => b.Key).HasMaxLength(1024);
       
    }
}

#endregion Place

#region Market
public class MarketCategoryConfig : IEntityTypeConfiguration<MarketCategory>
{
    public void Configure(EntityTypeBuilder<MarketCategory> builder)
    {
        builder.IsMultiTenant();
        builder.Property(b => b.Name).HasMaxLength(256);
        builder.Property(b => b.Code).HasMaxLength(256);
        builder.Property(b => b.Image).HasMaxLength(1024);
        builder.Property(b => b.Description).HasMaxLength(1024);
    }
}

public class MarketProductConfig : IEntityTypeConfiguration<MarketProduct>
{
    public void Configure(EntityTypeBuilder<MarketProduct> builder)
    {
        builder.IsMultiTenant();
        builder.Property(b => b.Name).HasMaxLength(256);
        builder.Property(b => b.Code).HasMaxLength(256);
        builder.Property(b => b.Packaging).HasMaxLength(256);
        builder.Property(b => b.Brand).HasMaxLength(256);
        builder.Property(b => b.Unit).HasMaxLength(256);
        builder.Property(b => b.Origin).HasMaxLength(256);
        builder.Property(b => b.DisplayUnit).HasMaxLength(256);
        builder.Property(b => b.DisplayFactor).HasMaxLength(256);
        builder.Property(b => b.Image).HasMaxLength(1024);
    }
}

#endregion Market

#region Hotline
public class HotlineCategoryConfig : IEntityTypeConfiguration<HotlineCategory>
{
    public void Configure(EntityTypeBuilder<HotlineCategory> builder)
    {
        builder.IsMultiTenant();
        builder.Property(b => b.Name).HasMaxLength(256);
        builder.Property(b => b.Code).HasMaxLength(256);
        builder.Property(b => b.Icon).HasMaxLength(256);
        builder.Property(b => b.Image).HasMaxLength(1024);
        builder.Property(b => b.CoverImage).HasMaxLength(1024);
        builder.Property(b => b.Description).HasMaxLength(1024);
    }
}

public class HotlineConfig : IEntityTypeConfiguration<Hotline>
{
    public void Configure(EntityTypeBuilder<Hotline> builder)
    {
        builder.IsMultiTenant();
        builder.Property(b => b.Name).HasMaxLength(256);
        builder.Property(b => b.Code).HasMaxLength(256);
        builder.Property(b => b.Address).HasMaxLength(1024);
        builder.Property(b => b.Detail).HasMaxLength(1024);
        builder.Property(b => b.OtherDetail).HasMaxLength(1024);
        builder.Property(b => b.Phone).HasMaxLength(256);
        builder.Property(b => b.Image).HasMaxLength(256);
        builder.Property(x => x.Latitude).HasColumnType("Decimal(8,6)");
        builder.Property(x => x.Longitude).HasColumnType("Decimal(9,6)");
    }
}

#endregion Hotline

#region Traffic
public class VehicleTypeConfig : IEntityTypeConfiguration<VehicleType>
{
    public void Configure(EntityTypeBuilder<VehicleType> builder)
    {
        builder.IsMultiTenant();
        builder.Property(b => b.Name).HasMaxLength(256);
        builder.Property(b => b.Code).HasMaxLength(256);
        builder.Property(b => b.Icon).HasMaxLength(256);
    }
}

public class CarpoolConfig : IEntityTypeConfiguration<Carpool>
{
    public void Configure(EntityTypeBuilder<Carpool> builder)
    {
        builder.IsMultiTenant();
        builder.Property(b => b.Name).HasMaxLength(256);
        builder.Property(b => b.UserName).HasMaxLength(256);
        builder.Property(b => b.PhoneNumber).HasMaxLength(256);
        builder.Property(b => b.DepartureTimeText).HasMaxLength(256);
        builder.Property(b => b.Role).HasMaxLength(256);
    }
}

public class CarPolicyConfig : IEntityTypeConfiguration<CarPolicy>
{
    public void Configure(EntityTypeBuilder<CarPolicy> builder)
    {
        builder.IsMultiTenant();
        builder.Property(b => b.Name).HasMaxLength(256);
        builder.Property(b => b.Code).HasMaxLength(256);
        builder.Property(b => b.Icon).HasMaxLength(256);
    }
}

public class CarUtilityTypeConfig : IEntityTypeConfiguration<CarUtility>
{
    public void Configure(EntityTypeBuilder<CarUtility> builder)
    {
        builder.IsMultiTenant();
        builder.Property(b => b.Name).HasMaxLength(256);
        builder.Property(b => b.Code).HasMaxLength(256);
        builder.Property(b => b.Icon).HasMaxLength(256);
    }
}

public class CompanyCarPolicyTypeConfig : IEntityTypeConfiguration<CompanyCarPolicy>
{
    public void Configure(EntityTypeBuilder<CompanyCarPolicy> builder)
    {
        builder.IsMultiTenant();
    }
}
public class VehicleConfig : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.IsMultiTenant();
        builder.Property(b => b.Name).HasMaxLength(256);
    }
}
public class TripConfig : IEntityTypeConfiguration<Trip>
{
    public void Configure(EntityTypeBuilder<Trip> builder)
    {
        builder.IsMultiTenant();
        builder.Property(b => b.Name).HasMaxLength(256);
    }
}
public class TripRouteConfig : IEntityTypeConfiguration<TripRoute>
{
    public void Configure(EntityTypeBuilder<TripRoute> builder)
    {
        builder.IsMultiTenant();
        builder.Property(b => b.Type).HasMaxLength(256);
    }
}

public class VehicleCarUtilityConfig : IEntityTypeConfiguration<VehicleCarUtility>
{
    public void Configure(EntityTypeBuilder<VehicleCarUtility> builder)
    {
        builder.IsMultiTenant();
    }
}

#endregion Traffic

#region Company
public class BenefitConfig : IEntityTypeConfiguration<Benefit>
{
    public void Configure(EntityTypeBuilder<Benefit> builder)
    {
        builder.IsMultiTenant();
        builder.Property(b => b.Name).HasMaxLength(256);
        builder.Property(b => b.Code).HasMaxLength(256);
        builder.Property(b => b.Icon).HasMaxLength(256);
        builder.Property(b => b.Description).HasMaxLength(1024);

    }
}
public class DegreeConfig : IEntityTypeConfiguration<Degree>
{
    public void Configure(EntityTypeBuilder<Degree> builder)
    {
        builder.IsMultiTenant();
        builder.Property(b => b.Name).HasMaxLength(256);
        builder.Property(b => b.Code).HasMaxLength(256);
        builder.Property(b => b.Description).HasMaxLength(1024);
    }
}
public class ExperienceConfig : IEntityTypeConfiguration<Experience>
{
    public void Configure(EntityTypeBuilder<Experience> builder)
    {
        builder.IsMultiTenant();
        builder.Property(b => b.Name).HasMaxLength(256);
        builder.Property(b => b.Code).HasMaxLength(256);
        builder.Property(b => b.Description).HasMaxLength(1024);
    }
}
public class IndustryConfig : IEntityTypeConfiguration<Industry>
{
    public void Configure(EntityTypeBuilder<Industry> builder)
    {
        builder.IsMultiTenant();
        builder.Property(b => b.Name).HasMaxLength(256);
        builder.Property(b => b.Code).HasMaxLength(256);
        builder.Property(b => b.Description).HasMaxLength(1024);
    }
}
public class JobAgeConfig : IEntityTypeConfiguration<JobAge>
{
    public void Configure(EntityTypeBuilder<JobAge> builder)
    {
        builder.IsMultiTenant();
        builder.Property(b => b.Name).HasMaxLength(256);
        builder.Property(b => b.Code).HasMaxLength(256);
        builder.Property(b => b.Description).HasMaxLength(1024);
    }
}
public class JobNameConfig : IEntityTypeConfiguration<JobName>
{
    public void Configure(EntityTypeBuilder<JobName> builder)
    {
        builder.IsMultiTenant();
        builder.Property(b => b.Name).HasMaxLength(256);
        builder.Property(b => b.Code).HasMaxLength(256);
        builder.Property(b => b.Description).HasMaxLength(1024);
    }
}
public class JobPositionConfig : IEntityTypeConfiguration<JobPosition>
{
    public void Configure(EntityTypeBuilder<JobPosition> builder)
    {
        builder.IsMultiTenant();
        builder.Property(b => b.Name).HasMaxLength(256);
        builder.Property(b => b.Code).HasMaxLength(256);
        builder.Property(b => b.Description).HasMaxLength(1024);
    }
}
public class JobTypeConfig : IEntityTypeConfiguration<JobType>
{
    public void Configure(EntityTypeBuilder<JobType> builder)
    {
        builder.IsMultiTenant();
        builder.Property(b => b.Name).HasMaxLength(256);
        builder.Property(b => b.Code).HasMaxLength(256);
        builder.Property(b => b.Description).HasMaxLength(1024);
    }
}
public class SalaryConfig : IEntityTypeConfiguration<Salary>
{
    public void Configure(EntityTypeBuilder<Salary> builder)
    {
        builder.IsMultiTenant();
        builder.Property(b => b.Name).HasMaxLength(256);
        builder.Property(b => b.Code).HasMaxLength(256);
        builder.Property(b => b.Description).HasMaxLength(1024);
    }
}
public class CompanyConfig : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.IsMultiTenant();
        builder.Property(b => b.Name).HasMaxLength(256);
        builder.Property(b => b.UserName).HasMaxLength(256);
        builder.Property(b => b.InternationalName).HasMaxLength(1024);
        builder.Property(b => b.ShortName).HasMaxLength(1024);
        builder.Property(b => b.TaxCode).HasMaxLength(256);
        builder.Property(b => b.Address).HasMaxLength(2048);
        builder.Property(b => b.Representative).HasMaxLength(1024);
        builder.Property(b => b.PhoneNumber).HasMaxLength(256);
        builder.Property(b => b.Website).HasMaxLength(256);
        builder.Property(b => b.Email).HasMaxLength(256);
        builder.Property(b => b.Fax).HasMaxLength(256);
        builder.Property(b => b.ProfileVideo).HasMaxLength(1024);
        builder.Property(b => b.CompanySize).HasMaxLength(256);

    }
}
public class CompanyIndustryConfig : IEntityTypeConfiguration<CompanyIndustry>
{
    public void Configure(EntityTypeBuilder<CompanyIndustry> builder)
    {
        builder.IsMultiTenant();
        builder.HasOne(sc => sc.Company).WithMany(s => s.CompanyIndustries).HasForeignKey(sc => sc.CompanyId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(sc => sc.Industry).WithMany(s => s.CompanyIndustries).HasForeignKey(sc => sc.IndustryId).OnDelete(DeleteBehavior.Cascade);
    }
}
public class JobApplicationConfig : IEntityTypeConfiguration<JobApplication>
{
    public void Configure(EntityTypeBuilder<JobApplication> builder)
    {
        builder.IsMultiTenant();
        builder.Property(b => b.Name).HasMaxLength(1024);
        builder.Property(b => b.UserName).HasMaxLength(256);
    }
}
public class JobAppliedConfig : IEntityTypeConfiguration<JobApplied>
{
    public void Configure(EntityTypeBuilder<JobApplied> builder)
    {
        builder.IsMultiTenant();
        builder.Property(b => b.UserName).HasMaxLength(256);
    }
}
public class JobSavedConfig : IEntityTypeConfiguration<JobSaved>
{
    public void Configure(EntityTypeBuilder<JobSaved> builder)
    {
        builder.IsMultiTenant();
        builder.Property(b => b.UserName).HasMaxLength(256);
    }
}
public class RecruitmentConfig : IEntityTypeConfiguration<Recruitment>
{
    public void Configure(EntityTypeBuilder<Recruitment> builder)
    {
        builder.IsMultiTenant();
        builder.Property(b => b.UserName).HasMaxLength(256);
        builder.Property(b => b.Name).HasMaxLength(1024);
        builder.Property(b => b.ContactName).HasMaxLength(256);
        builder.Property(b => b.ContactEmail).HasMaxLength(256);
        builder.Property(b => b.ContactPhone).HasMaxLength(256);
        builder.Property(b => b.ContactAdress).HasMaxLength(2048);
        builder.Property(b => b.Address).HasMaxLength(2048);

    }
}
public class RecruitmentBenefitConfig : IEntityTypeConfiguration<RecruitmentBenefit>
{
    public void Configure(EntityTypeBuilder<RecruitmentBenefit> builder)
    {
        builder.IsMultiTenant();
    }
}
#endregion Company

#region Ecommerce

public class BrandConfig : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.IsMultiTenant();

        builder.Property(b => b.Name).HasMaxLength(256);
    }
}

public class EcommerceCategoryConfig : IEntityTypeConfiguration<EcommerceCategory>
{
    public void Configure(EntityTypeBuilder<EcommerceCategory> builder)
    {
        builder.IsMultiTenant();
        builder.Property(b => b.Name).HasMaxLength(1024);
        builder.Property(x => x.Slug).HasMaxLength(1024);
        builder.Property(x => x.MetaTitle).HasMaxLength(1024);
        builder.Property(x => x.Icon).HasMaxLength(1024);
        builder.Property(x => x.Image).HasMaxLength(1024);
        builder.Property(x => x.Tags).HasMaxLength(1024);
        builder.Property(e => e.Tags).HasConversion(v => string.Join(',', v), v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));
    }
}

public class AttributeConfig : IEntityTypeConfiguration<Domain.Catalog.Attribute>
{
    public void Configure(EntityTypeBuilder<Domain.Catalog.Attribute> builder)
    {
        builder.IsMultiTenant();
    }
}

public class AttributeValueConfig : IEntityTypeConfiguration<Domain.Catalog.AttributeValue>
{
    public void Configure(EntityTypeBuilder<Domain.Catalog.AttributeValue> builder)
    {
        builder.IsMultiTenant();
    }
}


public class ProductConfig : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.IsMultiTenant();

        builder.Property(b => b.Name).HasMaxLength(1024);
        builder.Property(x => x.Price).HasDefaultValue(0).HasColumnType("bigint");
        builder.Property(x => x.ListPrice).HasDefaultValue(0).HasColumnType("bigint");
        builder.Property(p => p.ImagePath).HasMaxLength(2048);
        builder.HasOne(s => s.PrimaryEcommerceCategory).WithMany(g => g.PrimaryProducts).HasForeignKey(s => s.PrimaryEcommerceCategoryId);

    }
}

public class ProductReviewConfig : IEntityTypeConfiguration<ProductReview>
{
    public void Configure(EntityTypeBuilder<ProductReview> builder)
    {
        builder.IsMultiTenant();

      
    }
}

public class ProductSavedConfig : IEntityTypeConfiguration<ProductSaved>
{
    public void Configure(EntityTypeBuilder<ProductSaved> builder)
    {
        builder.IsMultiTenant();

      
    }
}


public class AttributeBooleanConfiguration : IEntityTypeConfiguration<Domain.Catalog.AttributeBoolean>
{
    public void Configure(EntityTypeBuilder<Domain.Catalog.AttributeBoolean> builder)
    {
        builder.IsMultiTenant();
        builder.Property(x => x.Value).HasDefaultValue(false);
        builder.HasOne(s => s.Product).WithMany(g => g.AttributeBooleans).HasForeignKey(s => s.ProductId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(s => s.Attribute).WithMany(g => g.AttributeBooleans).HasForeignKey(s => s.AttributeId).OnDelete(DeleteBehavior.Cascade);
    }
}

public class AttributeDatetimeConfiguration : IEntityTypeConfiguration<Domain.Catalog.AttributeDatetime>
{
    public void Configure(EntityTypeBuilder<Domain.Catalog.AttributeDatetime> builder)
    {
        builder.IsMultiTenant();
        builder.Property(x => x.Value).HasColumnType("datetime2");
        builder.HasOne(s => s.Product).WithMany(g => g.AttributeDatetimes).HasForeignKey(s => s.ProductId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(s => s.Attribute).WithMany(g => g.AttributeDatetimes).HasForeignKey(s => s.AttributeId).OnDelete(DeleteBehavior.Cascade);
    }
}
public class AttributeDecimalConfiguration : IEntityTypeConfiguration<Domain.Catalog.AttributeDecimal>
{
    public void Configure(EntityTypeBuilder<Domain.Catalog.AttributeDecimal> builder)
    {
        builder.IsMultiTenant();
        builder.HasOne(s => s.Product).WithMany(g => g.AttributeDecimals).HasForeignKey(s => s.ProductId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(s => s.Attribute).WithMany(g => g.AttributeDecimals).HasForeignKey(s => s.AttributeId).OnDelete(DeleteBehavior.Cascade);
    }
}

public class AttributeIntConfiguration : IEntityTypeConfiguration<Domain.Catalog.AttributeInt>
{
    public void Configure(EntityTypeBuilder<Domain.Catalog.AttributeInt> builder)
    {
        builder.IsMultiTenant();
        builder.HasOne(s => s.Product).WithMany(g => g.AttributeInts).HasForeignKey(s => s.ProductId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(s => s.Attribute).WithMany(g => g.AttributeInts).HasForeignKey(s => s.AttributeId).OnDelete(DeleteBehavior.Cascade);
    }
}

public class AttributeTextConfiguration : IEntityTypeConfiguration<Domain.Catalog.AttributeText>
{
    public void Configure(EntityTypeBuilder<Domain.Catalog.AttributeText> builder)
    {
        builder.IsMultiTenant();
        builder.HasOne(s => s.Product).WithMany(g => g.AttributeTexts).HasForeignKey(s => s.ProductId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(s => s.Attribute).WithMany(g => g.AttributeTexts).HasForeignKey(s => s.AttributeId).OnDelete(DeleteBehavior.Cascade);
    }
}

public class AttributeVarcharConfiguration : IEntityTypeConfiguration<Domain.Catalog.AttributeVarchar>
{
    public void Configure(EntityTypeBuilder<Domain.Catalog.AttributeVarchar> builder)
    {
        builder.IsMultiTenant();
        builder.HasOne(s => s.Product).WithMany(g => g.AttributeVarchars).HasForeignKey(s => s.ProductId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(s => s.Attribute).WithMany(g => g.AttributeVarchars).HasForeignKey(s => s.AttributeId).OnDelete(DeleteBehavior.Cascade);
    }
}

public class EcommerceCategoryAttributeConfig : IEntityTypeConfiguration<EcommerceCategoryAttribute>
{
    public void Configure(EntityTypeBuilder<EcommerceCategoryAttribute> builder)
    {
        builder.IsMultiTenant();
        builder.HasOne(s => s.EcommerceCategory).WithMany(g => g.EcommerceCategoryAttributes).HasForeignKey(s => s.EcommerceCategoryId);
        builder.HasOne(s => s.Attribute).WithMany(g => g.EcommerceCategoryAttributes).HasForeignKey(s => s.AttributeId);
    }
}

public class EcommerceCategoryProductConfig : IEntityTypeConfiguration<EcommerceCategoryProduct>
{
    public void Configure(EntityTypeBuilder<EcommerceCategoryProduct> builder)
    {
        builder.IsMultiTenant();
    }
}

#endregion Ecommerce

#region Alert
public class AlertCategoryConfig : IEntityTypeConfiguration<AlertCategory>
{
    public void Configure(EntityTypeBuilder<AlertCategory> builder)
    {
        builder.IsMultiTenant();
        builder.Property(b => b.Name).HasMaxLength(256);
        builder.Property(b => b.Code).HasMaxLength(256);
        builder.Property(b => b.Image).HasMaxLength(1024);
        builder.Property(b => b.Description).HasMaxLength(2048);
    }
}

public class AlertOrganizationConfig : IEntityTypeConfiguration<AlertOrganization>
{
    public void Configure(EntityTypeBuilder<AlertOrganization> builder)
    {
        builder.IsMultiTenant();
        builder.Property(b => b.Name).HasMaxLength(256);
        builder.Property(b => b.Code).HasMaxLength(256);
        builder.Property(b => b.Image).HasMaxLength(1024);
        builder.Property(b => b.Description).HasMaxLength(2048);
    }
}

public class AlertInformationConfig : IEntityTypeConfiguration<AlertInformation>
{
    public void Configure(EntityTypeBuilder<AlertInformation> builder)
    {
        builder.IsMultiTenant();
        builder.Property(b => b.Title).HasMaxLength(512);
        builder.Property(b => b.Image).HasMaxLength(1024);
        builder.Property(b => b.File).HasMaxLength(1024);
    }
}

#endregion Alert

#region Enterprise
public class LawDataConfig : IEntityTypeConfiguration<LawData>
{
    public void Configure(EntityTypeBuilder<LawData> builder)
    {
        builder.IsMultiTenant();
        builder.Property(b => b.Title).HasMaxLength(500);
        builder.Property(b => b.Code).HasMaxLength(256);
        builder.Property(b => b.Image).HasMaxLength(1024);
    }
}

public class EnterpriseForumCategoryConfig : IEntityTypeConfiguration<EnterpriseForumCategory>
{
    public void Configure(EntityTypeBuilder<EnterpriseForumCategory> builder)
    {
        builder.IsMultiTenant();
        builder.Property(b => b.Name).HasMaxLength(500);
        builder.Property(b => b.Code).HasMaxLength(256);
        builder.Property(b => b.Image).HasMaxLength(1024);
    }
}

public class ProjectInvestCategoryConfig : IEntityTypeConfiguration<ProjectInvestCategory>
{
    public void Configure(EntityTypeBuilder<ProjectInvestCategory> builder)
    {
        builder.IsMultiTenant();
        builder.Property(b => b.Name).HasMaxLength(500);
        builder.Property(b => b.Code).HasMaxLength(256);
        builder.Property(b => b.Image).HasMaxLength(1024);
    }
}

public class ProjectInvestFormConfig : IEntityTypeConfiguration<ProjectInvestForm>
{
    public void Configure(EntityTypeBuilder<ProjectInvestForm> builder)
    {
        builder.IsMultiTenant();
        builder.Property(b => b.Name).HasMaxLength(500);
        builder.Property(b => b.Code).HasMaxLength(256);
        builder.Property(b => b.Image).HasMaxLength(1024);
    }
}

public class ProjectInvestInformationConfig : IEntityTypeConfiguration<ProjectInvestInformation>
{
    public void Configure(EntityTypeBuilder<ProjectInvestInformation> builder)
    {
        builder.IsMultiTenant();
        builder.Property(b => b.Title).HasMaxLength(500);
        builder.Property(b => b.Image).HasMaxLength(1024);
    }
}

public class LaborMarketInformationConfig : IEntityTypeConfiguration<LaborMarketInformation>
{
    public void Configure(EntityTypeBuilder<LaborMarketInformation> builder)
    {
        builder.IsMultiTenant();
        builder.Property(b => b.Title).HasMaxLength(500);
        builder.Property(b => b.Image).HasMaxLength(1024);
    }
}

public class EnterpriseForumCommentConfig : IEntityTypeConfiguration<EnterpriseForumComment>
{
    public void Configure(EntityTypeBuilder<EnterpriseForumComment> builder)
    {
        builder.IsMultiTenant();
        builder.Property(b => b.UserName).HasMaxLength(500);
    }
}

public class EnterpriseForumTopicConfig : IEntityTypeConfiguration<EnterpriseForumTopic>
{
    public void Configure(EntityTypeBuilder<EnterpriseForumTopic> builder)
    {
        builder.IsMultiTenant();
        builder.Property(b => b.UserName).HasMaxLength(500);
    }
}

#endregion Enterprise

#region Travel

public class TourGuideConfig : IEntityTypeConfiguration<TourGuide>
{
    public void Configure(EntityTypeBuilder<TourGuide> builder)
    {
        builder.IsMultiTenant();
        builder.Property(b => b.FullName).HasMaxLength(256);
        builder.Property(b => b.CardNumber).HasMaxLength(256);
        builder.Property(b => b.Image).HasMaxLength(1024);
        builder.Property(b => b.CardType).HasMaxLength(256);
        builder.Property(b => b.CardNumber).HasMaxLength(256);
        builder.Property(b => b.ExpirationDate).HasMaxLength(256);
        builder.Property(b => b.Experience).HasMaxLength(256);
        builder.Property(b => b.PlaceOfIssue).HasMaxLength(1024);
    }
}

public class TravelHandbookConfig : IEntityTypeConfiguration<TravelHandbook>
{
    public void Configure(EntityTypeBuilder<TravelHandbook> builder)
    {
        builder.IsMultiTenant();
        builder.Property(b => b.Name).HasMaxLength(1024);
    }
}


#endregion Travel

#region Agriculture

public class AgriculturalEngineeringCategoryConfig : IEntityTypeConfiguration<AgriculturalEngineeringCategory>
{
    public void Configure(EntityTypeBuilder<AgriculturalEngineeringCategory> builder)
    {
        builder.IsMultiTenant();
        builder.Property(b => b.Name).HasMaxLength(512);
        builder.Property(b => b.Description).HasMaxLength(1024);
        builder.Property(b => b.Image).HasMaxLength(1024);
        builder.Property(b => b.Icon).HasMaxLength(256);
        builder.Property(b => b.CoverImage).HasMaxLength(256);
        builder.Property(b => b.Code).HasMaxLength(256);
    }
}

public class AgriculturalEngineeringConfig : IEntityTypeConfiguration<AgriculturalEngineering>
{
    public void Configure(EntityTypeBuilder<AgriculturalEngineering> builder)
    {
        builder.IsMultiTenant();
        builder.Property(b => b.Name).HasMaxLength(512);
        builder.Property(b => b.Description).HasMaxLength(1024);
        builder.Property(b => b.Image).HasMaxLength(1024);
        builder.Property(b => b.Code).HasMaxLength(256);
        builder.Property(b => b.ViewQuantity).HasDefaultValue(0);
    }
}

#endregion Agriculture

#region Education
public class SchoolConfig : IEntityTypeConfiguration<School>
{
    public void Configure(EntityTypeBuilder<School> builder)
    {
        builder.IsMultiTenant();
        builder.Property(b => b.Name).HasMaxLength(512);
        builder.Property(b => b.Description).HasMaxLength(1024);
        builder.Property(b => b.Image).HasMaxLength(1024);
        builder.Property(b => b.Code).HasMaxLength(256);
    }
}

#endregion Education

#region Medical
public class DiseaseConfig : IEntityTypeConfiguration<Disease>
{
    public void Configure(EntityTypeBuilder<Disease> builder)
    {
        builder.IsMultiTenant();
        builder.Property(b => b.Name).HasMaxLength(1024);
    }
}

public class MedicalHotlineConfig : IEntityTypeConfiguration<MedicalHotline>
{
    public void Configure(EntityTypeBuilder<MedicalHotline> builder)
    {
        builder.IsMultiTenant();
        builder.Property(b => b.Name).HasMaxLength(256);
        builder.Property(b => b.Code).HasMaxLength(256);
        builder.Property(b => b.Address).HasMaxLength(1024);
        builder.Property(b => b.Detail).HasMaxLength(1024);
        builder.Property(b => b.OtherDetail).HasMaxLength(1024);
        builder.Property(b => b.Phone).HasMaxLength(256);
        builder.Property(b => b.Image).HasMaxLength(256);
        builder.Property(x => x.Latitude).HasColumnType("Decimal(8,6)");
        builder.Property(x => x.Longitude).HasColumnType("Decimal(9,6)");
    }
}

#endregion Medical


#region Food
public class FoodWarningConfig : IEntityTypeConfiguration<FoodWarning>
{
    public void Configure(EntityTypeBuilder<FoodWarning> builder)
    {
        builder.IsMultiTenant();
        builder.Property(b => b.Name).HasMaxLength(1024);
    }
}

public class FoodFactoryConfig : IEntityTypeConfiguration<FoodFactory>
{
    public void Configure(EntityTypeBuilder<FoodFactory> builder)
    {
        builder.IsMultiTenant();
        builder.Property(b => b.Name).HasMaxLength(1024);
    }
}


#endregion Food