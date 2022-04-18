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

