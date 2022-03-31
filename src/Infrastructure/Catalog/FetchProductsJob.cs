using Hangfire;
using Hangfire.Console.Extensions;
using Hangfire.Console.Progress;
using Hangfire.Server;
using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using TD.CitizenAPI.Application.Catalog.EcommerceCategories;
using TD.CitizenAPI.Application.Catalog.Products;
using TD.CitizenAPI.Application.Common.Interfaces;
using TD.CitizenAPI.Application.Common.Persistence;
using TD.CitizenAPI.Domain.Catalog;
using TD.CitizenAPI.Shared.Notifications;

namespace TD.CitizenAPI.Infrastructure.Catalog;

public class FetchProductsJob : IProductsGeneratorJob
{
    private readonly ILogger<FetchProductsJob> _logger;
    private readonly ISender _mediator;
    private readonly IReadRepository<Product> _repository;
    private readonly IReadRepository<EcommerceCategory> _repositoryEcommerceCategory;
    private readonly IProgressBarFactory _progressBar;
    private readonly PerformingContext _performingContext;
    private readonly INotificationSender _notifications;
    private readonly ICurrentUser _currentUser;
    private readonly IProgressBar _progress;

    public FetchProductsJob(
        ILogger<FetchProductsJob> logger,
        ISender mediator,
        IReadRepository<Product> repository,
        IReadRepository<EcommerceCategory> repositoryEcommerceCategory,
        IProgressBarFactory progressBar,
        PerformingContext performingContext,
        INotificationSender notifications,
        ICurrentUser currentUser)
    {
        _logger = logger;
        _mediator = mediator;
        _repository = repository;
        _repositoryEcommerceCategory = repositoryEcommerceCategory;
        _progressBar = progressBar;
        _performingContext = performingContext;
        _notifications = notifications;
        _currentUser = currentUser;
        _progress = _progressBar.Create();
    }

    private async Task NotifyAsync(string message, int progress, CancellationToken cancellationToken)
    {
        _progress.SetValue(progress);
        await _notifications.SendToUserAsync(
            new JobNotification()
            {
                JobId = _performingContext.BackgroundJob.Id,
                Message = message,
                Progress = progress
            },
            _currentUser.GetUserId().ToString(),
            cancellationToken);
    }

    [Queue("notdefault")]
    public async Task GenerateAsync(string category, int page, int limit, string sortOption, CancellationToken cancellationToken)
    {
        await NotifyAsync("FetchProductAsync processing has started", 0, cancellationToken);
        await Handle(category, page, limit, sortOption, cancellationToken);
        await NotifyAsync("FetchProductAsync successfully completed", 0, cancellationToken);
    }


    public async Task Handle(string category, int page, int limit, string sortOption, CancellationToken cancellationToken)
    {
        var client = new RestClient();
        var request_ = new RestRequest("https://tiki.vn/api/personalish/v1/blocks/listings?limit=" + limit + "&category=" + category + "&page=" + page + "&sort=" + sortOption);
        var cancellationTokenSource = new CancellationTokenSource();

        var restResponse = await client.ExecuteAsync(request_, cancellationTokenSource.Token);
        string? content = restResponse.Content;

        DataContent dataContent = JsonConvert.DeserializeObject<DataContent>(content);

        foreach (var item in dataContent.data)
        {
            var request = new RestRequest("https://tiki.vn/api/v2/products/"+item.id);
            var response = await client.ExecuteAsync(request, cancellationTokenSource.Token);
            string? contentProduct = response.Content;

            DataProduct dataProduct = JsonConvert.DeserializeObject<DataProduct>(contentProduct);

            string images = "";
            string image_ = "";

            foreach (var image in dataProduct.images)
            {
                if (string.IsNullOrEmpty(image_))
                {
                    image_ = image.base_url;
                }
                images += image.base_url + "##";
            }

            ICollection<string> lstCategories = new List<string>();
            foreach (var category_ in dataProduct.breadcrumbs)
            {
                lstCategories.Add(category_.category_id.ToString());
            }

            try
            {
                await _mediator.Send(
                     new CreateFetchedProductRequest
                     {
                         Name = dataProduct.name,
                         Code = dataProduct.id.ToString(),
                         SKU = dataProduct.sku,
                         Description = dataProduct.description,
                         ShortDescription = dataProduct.short_description,
                         ThumbnailUrl = dataProduct.thumbnail_url,
                         Images = images,
                         Image = image_,
                         Category = dataProduct.categories.id.ToString(),
                         Categories = lstCategories,
                         Price = (int)dataProduct.price,
                         ListPrice = (int)dataProduct.list_price,
                         Quantity = 99
                     },
                     cancellationToken);
            }
            catch (Exception)
            {

            }

        }


        /* dynamic blogPosts = JObject.Parse(content);
         dynamic result = blogPosts.data;*/

        /*foreach (dynamic album in result)
        {
            try
            {
                var category = await _mediator.Send(
                     new CreateEcommerceCategoryRequest
                     {
                         ParentId = parentCategoryId,
                         Slug = album.url_key,
                         Name = album.name,
                         Description = album.description,
                         MetaTitle = album.meta_title,
                         MetaDescription = album.meta_description,
                         Image = album.file_path,
                         Icon = album.id,
                         IncludeInMenu = true,

                     },
                     cancellationToken);

                string? tmp2 = album.id;
                var tmp = Int32.Parse(tmp2);

                //var tmp = typeof(category.Data);

                await Handle(tmp, token, category.Data, cancellationToken);

            }
            catch (Exception)
            {

            }

        }*/
    }

    public class Paging
    {
        public int current_page { get; set; }
        public int from { get; set; }
        public int last_page { get; set; }
        public int per_page { get; set; }
        public int to { get; set; }
        public int total { get; set; }
    }
    public class Datum
    {
        public int id { get; set; }
        public string sku { get; set; }
    }
        public class DataContent
    {
        public List<Datum> data { get; set; }
        public Paging paging { get; set; }
    }


    public class Image
    {
        public string base_url { get; set; }
        public bool is_gallery { get; set; }
        public object label { get; set; }
        public string large_url { get; set; }
        public string medium_url { get; set; }
        public object position { get; set; }
        public string small_url { get; set; }
        public string thumbnail_url { get; set; }
    }

    public class Categories
    {
        public int id { get; set; }
        public string name { get; set; }
        public bool is_leaf { get; set; }
    }

    public class Breadcrumb
    {
        public string url { get; set; }
        public string name { get; set; }
        public int category_id { get; set; }
    }

    public class DataProduct
    {
        public int id { get; set; }
        public string sku { get; set; }
        public string name { get; set; }
        public string url_key { get; set; }
        public string url_path { get; set; }
        public string type { get; set; }
        public string short_description { get; set; }
        public int? price { get; set; }
        public int? list_price { get; set; }
        public int? original_price { get; set; }
        public string thumbnail_url { get; set; }
        public string productset_group_name { get; set; }
        public string meta_title { get; set; }
        public string meta_description { get; set; }
        public string meta_keywords { get; set; }
        public string description { get; set; }
        public List<Image>? images { get; set; }
        public Categories? categories { get; set; }
        public List<Breadcrumb>? breadcrumbs { get; set; }
    }

}

