using System.Collections.ObjectModel;

namespace TD.CitizenAPI.Shared.Authorization;

public static class FSHAction
{
    public const string View = nameof(View);
    public const string Search = nameof(Search);
    public const string Create = nameof(Create);
    public const string Update = nameof(Update);
    public const string Delete = nameof(Delete);
    public const string Export = nameof(Export);
    public const string Generate = nameof(Generate);
    public const string Clean = nameof(Clean);
    public const string UpgradeSubscription = nameof(UpgradeSubscription);
}

public static class FSHResource
{
    public const string Tenants = nameof(Tenants);
    public const string Dashboard = nameof(Dashboard);
    public const string Hangfire = nameof(Hangfire);
    public const string Users = nameof(Users);
    public const string UserRoles = nameof(UserRoles);
    public const string Roles = nameof(Roles);
    public const string RoleClaims = nameof(RoleClaims);
    public const string Products = nameof(Products);
    public const string Brands = nameof(Brands);
    public const string Companies = nameof(Companies);
    public const string Ecommerces = nameof(Ecommerces);
    public const string Hotlines = nameof(Hotlines);
    public const string Markets = nameof(Markets);
    public const string Others = nameof(Others);
    public const string Places = nameof(Places);
    public const string Traffics = nameof(Traffics);
    public const string Travels = nameof(Travels);
}

public static class FSHPermissions
{
    private static readonly FSHPermission[] _all = new FSHPermission[]
    {
        new("View Dashboard", FSHAction.View, FSHResource.Dashboard),
        new("View Hangfire", FSHAction.View, FSHResource.Hangfire),
        new("View Users", FSHAction.View, FSHResource.Users),
        new("Search Users", FSHAction.Search, FSHResource.Users),
        new("Create Users", FSHAction.Create, FSHResource.Users),
        new("Update Users", FSHAction.Update, FSHResource.Users),
        new("Delete Users", FSHAction.Delete, FSHResource.Users),
        new("Export Users", FSHAction.Export, FSHResource.Users),
        new("View UserRoles", FSHAction.View, FSHResource.UserRoles),
        new("Update UserRoles", FSHAction.Update, FSHResource.UserRoles),
        new("View Roles", FSHAction.View, FSHResource.Roles),
        new("Create Roles", FSHAction.Create, FSHResource.Roles),
        new("Update Roles", FSHAction.Update, FSHResource.Roles),
        new("Delete Roles", FSHAction.Delete, FSHResource.Roles),
        new("View RoleClaims", FSHAction.View, FSHResource.RoleClaims),
        new("Update RoleClaims", FSHAction.Update, FSHResource.RoleClaims),
        new("View Products", FSHAction.View, FSHResource.Products, IsBasic: true),
        new("Search Products", FSHAction.Search, FSHResource.Products, IsBasic: true),
        new("Create Products", FSHAction.Create, FSHResource.Products),
        new("Update Products", FSHAction.Update, FSHResource.Products),
        new("Delete Products", FSHAction.Delete, FSHResource.Products),
        new("Export Products", FSHAction.Export, FSHResource.Products),
        new("View Brands", FSHAction.View, FSHResource.Brands, IsBasic: true),
        new("Search Brands", FSHAction.Search, FSHResource.Brands, IsBasic: true),
        new("Create Brands", FSHAction.Create, FSHResource.Brands),
        new("Update Brands", FSHAction.Update, FSHResource.Brands),
        new("Delete Brands", FSHAction.Delete, FSHResource.Brands),
        new("Generate Brands", FSHAction.Generate, FSHResource.Brands),
        new("Clean Brands", FSHAction.Clean, FSHResource.Brands),
        new("View Tenants", FSHAction.View, FSHResource.Tenants, IsRoot: true),
        new("Create Tenants", FSHAction.Create, FSHResource.Tenants, IsRoot: true),
        new("Update Tenants", FSHAction.Update, FSHResource.Tenants, IsRoot: true),
        new("Upgrade Tenant Subscription", FSHAction.UpgradeSubscription, FSHResource.Tenants, IsRoot: true),

        new("View Companies", FSHAction.View, FSHResource.Companies, IsBasic: true),
        new("Search Companies", FSHAction.Search, FSHResource.Companies, IsBasic: true),
        new("Create Companies", FSHAction.Create, FSHResource.Companies),
        new("Update Companies", FSHAction.Update, FSHResource.Companies),
        new("Delete Companies", FSHAction.Delete, FSHResource.Companies),

        new("View Ecommerces", FSHAction.View, FSHResource.Ecommerces, IsBasic: true),
        new("Search Ecommerces", FSHAction.Search, FSHResource.Ecommerces, IsBasic: true),
        new("Create Ecommerces", FSHAction.Create, FSHResource.Ecommerces),
        new("Update Ecommerces", FSHAction.Update, FSHResource.Ecommerces),
        new("Delete Ecommerces", FSHAction.Delete, FSHResource.Ecommerces),

        new("View Hotlines", FSHAction.View, FSHResource.Hotlines, IsBasic: true),
        new("Search Hotlines", FSHAction.Search, FSHResource.Hotlines, IsBasic: true),
        new("Create Hotlines", FSHAction.Create, FSHResource.Hotlines),
        new("Update Hotlines", FSHAction.Update, FSHResource.Hotlines),
        new("Delete Hotlines", FSHAction.Delete, FSHResource.Hotlines),

        new("View Markets", FSHAction.View, FSHResource.Markets, IsBasic: true),
        new("Search Markets", FSHAction.Search, FSHResource.Markets, IsBasic: true),
        new("Create Markets", FSHAction.Create, FSHResource.Markets),
        new("Update Markets", FSHAction.Update, FSHResource.Markets),
        new("Delete Markets", FSHAction.Delete, FSHResource.Markets),

        new("View Others", FSHAction.View, FSHResource.Others, IsBasic: true),
        new("Search Others", FSHAction.Search, FSHResource.Others, IsBasic: true),
        new("Create Others", FSHAction.Create, FSHResource.Others),
        new("Update Others", FSHAction.Update, FSHResource.Others),
        new("Delete Others", FSHAction.Delete, FSHResource.Others),

        new("View Places", FSHAction.View, FSHResource.Places, IsBasic: true),
        new("Search Places", FSHAction.Search, FSHResource.Places, IsBasic: true),
        new("Create Places", FSHAction.Create, FSHResource.Places),
        new("Update Places", FSHAction.Update, FSHResource.Places),
        new("Delete Places", FSHAction.Delete, FSHResource.Places),

        new("View Traffics", FSHAction.View, FSHResource.Traffics, IsBasic: true),
        new("Search Traffics", FSHAction.Search, FSHResource.Traffics, IsBasic: true),
        new("Create Traffics", FSHAction.Create, FSHResource.Traffics),
        new("Update Traffics", FSHAction.Update, FSHResource.Traffics),
        new("Delete Traffics", FSHAction.Delete, FSHResource.Traffics),

        new("View Travels", FSHAction.View, FSHResource.Travels, IsBasic: true),
        new("Search Travels", FSHAction.Search, FSHResource.Travels, IsBasic: true),
        new("Create Travels", FSHAction.Create, FSHResource.Travels),
        new("Update Travels", FSHAction.Update, FSHResource.Travels),
        new("Delete Travels", FSHAction.Delete, FSHResource.Travels),
    };

    public static IReadOnlyList<FSHPermission> All { get; } = new ReadOnlyCollection<FSHPermission>(_all);
    public static IReadOnlyList<FSHPermission> Root { get; } = new ReadOnlyCollection<FSHPermission>(_all.Where(p => p.IsRoot).ToArray());
    public static IReadOnlyList<FSHPermission> Admin { get; } = new ReadOnlyCollection<FSHPermission>(_all.Where(p => !p.IsRoot).ToArray());
    public static IReadOnlyList<FSHPermission> Basic { get; } = new ReadOnlyCollection<FSHPermission>(_all.Where(p => p.IsBasic).ToArray());
}

public record FSHPermission(string Description, string Action, string Resource, bool IsBasic = false, bool IsRoot = false)
{
    public string Name => NameFor(Action, Resource);
    public static string NameFor(string action, string resource) => $"Permissions.{resource}.{action}";
}