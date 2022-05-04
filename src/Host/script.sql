BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Catalog].[AgriculturalEngineerings]') AND [c].[name] = N'Code');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Catalog].[AgriculturalEngineerings] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Catalog].[AgriculturalEngineerings] ALTER COLUMN [Code] nvarchar(256) NULL;
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Catalog].[AgriculturalEngineeringCategories]') AND [c].[name] = N'Code');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Catalog].[AgriculturalEngineeringCategories] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Catalog].[AgriculturalEngineeringCategories] ALTER COLUMN [Code] nvarchar(256) NULL;
GO

CREATE TABLE [Catalog].[Diseases] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(512) NOT NULL,
    [Code] nvarchar(256) NULL,
    [Image] nvarchar(1024) NULL,
    [Images] nvarchar(2048) NULL,
    [Description] nvarchar(1024) NULL,
    [Content] nvarchar(max) NULL,
    [TenantId] nvarchar(64) NOT NULL,
    [CreatedBy] nvarchar(max) NULL,
    [CreatedOn] datetime2 NULL,
    [LastModifiedBy] nvarchar(max) NULL,
    [LastModifiedOn] datetime2 NULL,
    [DeletedOn] datetime2 NULL,
    [DeletedBy] nvarchar(max) NULL,
    CONSTRAINT [PK_Diseases] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220408133047_Update_26_Medical', N'6.0.2');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Catalog].[Diseases]') AND [c].[name] = N'Name');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Catalog].[Diseases] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [Catalog].[Diseases] ALTER COLUMN [Name] nvarchar(1024) NOT NULL;
GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Catalog].[Diseases]') AND [c].[name] = N'Images');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Catalog].[Diseases] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [Catalog].[Diseases] ALTER COLUMN [Images] nvarchar(max) NULL;
GO

DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Catalog].[Diseases]') AND [c].[name] = N'Image');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Catalog].[Diseases] DROP CONSTRAINT [' + @var4 + '];');
ALTER TABLE [Catalog].[Diseases] ALTER COLUMN [Image] nvarchar(max) NULL;
GO

DECLARE @var5 sysname;
SELECT @var5 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Catalog].[Diseases]') AND [c].[name] = N'Description');
IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [Catalog].[Diseases] DROP CONSTRAINT [' + @var5 + '];');
ALTER TABLE [Catalog].[Diseases] ALTER COLUMN [Description] nvarchar(max) NULL;
GO

DECLARE @var6 sysname;
SELECT @var6 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Catalog].[Diseases]') AND [c].[name] = N'Code');
IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [Catalog].[Diseases] DROP CONSTRAINT [' + @var6 + '];');
ALTER TABLE [Catalog].[Diseases] ALTER COLUMN [Code] nvarchar(max) NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220408134942_Update_27_Medical', N'6.0.2');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Catalog].[MedicalHotlines] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(256) NOT NULL,
    [Address] nvarchar(1024) NULL,
    [Code] nvarchar(256) NULL,
    [Detail] nvarchar(1024) NULL,
    [OtherDetail] nvarchar(1024) NULL,
    [Phone] nvarchar(256) NULL,
    [Image] nvarchar(256) NULL,
    [Active] bit NULL,
    [Order] int NULL,
    [Latitude] Decimal(8,6) NULL,
    [Longitude] Decimal(9,6) NULL,
    [TenantId] nvarchar(64) NOT NULL,
    [CreatedBy] nvarchar(max) NULL,
    [CreatedOn] datetime2 NULL,
    [LastModifiedBy] nvarchar(max) NULL,
    [LastModifiedOn] datetime2 NULL,
    [DeletedOn] datetime2 NULL,
    [DeletedBy] nvarchar(max) NULL,
    CONSTRAINT [PK_MedicalHotlines] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220412091159_Update_28_Medical', N'6.0.2');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Catalog].[FoodFactories] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(1024) NOT NULL,
    [Address] nvarchar(max) NULL,
    [BusinessArea] nvarchar(max) NULL,
    [CertificationNumber] nvarchar(max) NULL,
    [Image] nvarchar(max) NULL,
    [Images] nvarchar(max) NULL,
    [Description] nvarchar(max) NULL,
    [OwnerName] nvarchar(max) NULL,
    [Email] nvarchar(max) NULL,
    [Phone] nvarchar(max) NULL,
    [TaxCode] nvarchar(max) NULL,
    [Latitude] float NULL,
    [Longitude] float NULL,
    [Files] nvarchar(max) NULL,
    [DateOfIssue] datetime2 NULL,
    [ExpirationDate] datetime2 NULL,
    [TenantId] nvarchar(64) NOT NULL,
    [CreatedBy] nvarchar(max) NULL,
    [CreatedOn] datetime2 NULL,
    [LastModifiedBy] nvarchar(max) NULL,
    [LastModifiedOn] datetime2 NULL,
    [DeletedOn] datetime2 NULL,
    [DeletedBy] nvarchar(max) NULL,
    CONSTRAINT [PK_FoodFactories] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Catalog].[FoodWarnings] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(1024) NOT NULL,
    [Code] nvarchar(max) NULL,
    [Image] nvarchar(max) NULL,
    [Images] nvarchar(max) NULL,
    [Description] nvarchar(max) NULL,
    [Content] nvarchar(max) NULL,
    [TenantId] nvarchar(64) NOT NULL,
    [CreatedBy] nvarchar(max) NULL,
    [CreatedOn] datetime2 NULL,
    [LastModifiedBy] nvarchar(max) NULL,
    [LastModifiedOn] datetime2 NULL,
    [DeletedOn] datetime2 NULL,
    [DeletedBy] nvarchar(max) NULL,
    CONSTRAINT [PK_FoodWarnings] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220413043556_Update_29_Food', N'6.0.2');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Catalog].[TravelHandbooks] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(1024) NULL,
    [Content] nvarchar(max) NULL,
    [Description] nvarchar(max) NULL,
    [ViewQuantity] int NOT NULL,
    [Image] nvarchar(max) NULL,
    [Source] nvarchar(max) NULL,
    [Tags] nvarchar(max) NULL,
    [TenantId] nvarchar(64) NOT NULL,
    [CreatedBy] nvarchar(max) NULL,
    [CreatedOn] datetime2 NULL,
    [LastModifiedBy] nvarchar(max) NULL,
    [LastModifiedOn] datetime2 NULL,
    [DeletedOn] datetime2 NULL,
    [DeletedBy] nvarchar(max) NULL,
    CONSTRAINT [PK_TravelHandbooks] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220415035421_Update_30_Travel', N'6.0.2');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Catalog].[Drugs] (
    [Id] uniqueidentifier NOT NULL,
    [Code] nvarchar(max) NULL,
    [Images] nvarchar(max) NULL,
    [TenThuoc] nvarchar(512) NULL,
    [DotPheDuyet] nvarchar(max) NULL,
    [SoQuyetDinh] nvarchar(max) NULL,
    [PheDuyet] nvarchar(max) NULL,
    [HieuLuc] nvarchar(max) NULL,
    [SoDangKy] nvarchar(max) NULL,
    [HoatChat] nvarchar(max) NULL,
    [PhanLoai] nvarchar(max) NULL,
    [NongDo] nvarchar(max) NULL,
    [TaDuoc] nvarchar(max) NULL,
    [BaoChe] nvarchar(max) NULL,
    [DongGoi] nvarchar(max) NULL,
    [TieuChuan] nvarchar(max) NULL,
    [TuoiTho] nvarchar(max) NULL,
    [CongTySx] nvarchar(max) NULL,
    [CongTySxCode] nvarchar(max) NULL,
    [NuocSx] nvarchar(max) NULL,
    [DiaChiSx] nvarchar(max) NULL,
    [CongTyDk] nvarchar(max) NULL,
    [NuocDk] nvarchar(max) NULL,
    [DiaChiDk] nvarchar(max) NULL,
    [GiaKeKhai] nvarchar(max) NULL,
    [HuongDanSuDung] nvarchar(max) NULL,
    [HuongDanSuDungBn] nvarchar(max) NULL,
    [NhomThuoc] nvarchar(max) NULL,
    [FileName] nvarchar(max) NULL,
    [TenantId] nvarchar(64) NOT NULL,
    [CreatedBy] nvarchar(max) NULL,
    [CreatedOn] datetime2 NULL,
    [LastModifiedBy] nvarchar(max) NULL,
    [LastModifiedOn] datetime2 NULL,
    [DeletedOn] datetime2 NULL,
    [DeletedBy] nvarchar(max) NULL,
    CONSTRAINT [PK_Drugs] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220415174108_Update_31_Medical', N'6.0.2');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Catalog].[SeaGames] (
    [Id] uniqueidentifier NOT NULL,
    [Title] nvarchar(512) NOT NULL,
    [Actor] nvarchar(max) NULL,
    [Content] nvarchar(max) NULL,
    [Date] datetime2 NULL,
    [Image] nvarchar(max) NULL,
    [Source] nvarchar(512) NULL,
    [ViewQuantity] int NULL,
    [TenantId] nvarchar(64) NOT NULL,
    [CreatedBy] nvarchar(max) NULL,
    [CreatedOn] datetime2 NULL,
    [LastModifiedBy] nvarchar(max) NULL,
    [LastModifiedOn] datetime2 NULL,
    [DeletedOn] datetime2 NULL,
    [DeletedBy] nvarchar(max) NULL,
    CONSTRAINT [PK_SeaGames] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220504015926_Update_32_SeaGame', N'6.0.2');
GO

COMMIT;
GO

