﻿using Finbuckle.MultiTenant.EntityFrameworkCore;
using TD.CitizenAPI.Domain.Catalog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TD.CitizenAPI.Infrastructure.Persistence.Configuration;


#region Other
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
#endregion Traffic