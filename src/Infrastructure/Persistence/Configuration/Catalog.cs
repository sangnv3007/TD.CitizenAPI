using Finbuckle.MultiTenant.EntityFrameworkCore;
using TD.CitizenAPI.Domain.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TD.CitizenAPI.Infrastructure.Persistence.Configuration;

public class BrandConfig : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.IsMultiTenant();

        builder.Property(b => b.Name).HasMaxLength(256);
    }
}

public class ProductConfig : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.IsMultiTenant();

        builder.Property(b => b.Name).HasMaxLength(1024);

        builder.Property(p => p.ImagePath).HasMaxLength(2048);
    }
}

public class AttachmentConfig : IEntityTypeConfiguration<Attachment>
{
    public void Configure(EntityTypeBuilder<Attachment> builder)
    {
        builder.IsMultiTenant();
        builder.Property(b => b.Name).HasMaxLength(256);
        builder.Property(b => b.Type).HasMaxLength(256);
        builder.Property(b => b.Url).HasMaxLength(256);
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