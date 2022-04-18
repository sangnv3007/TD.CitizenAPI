using Hangfire;
using Hangfire.Console.Extensions;
using Hangfire.Console.Progress;
using Hangfire.Server;
using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using RestSharp;
using TD.CitizenAPI.Application.Catalog.Drugs;
using TD.CitizenAPI.Application.Common.Interfaces;
using TD.CitizenAPI.Application.Common.Persistence;
using TD.CitizenAPI.Domain.Catalog;
using TD.CitizenAPI.Shared.Notifications;

namespace TD.CitizenAPI.Infrastructure.Catalog;

public class FetchDrugsJob : IFetchDrugJob
{
    private readonly ILogger<FetchDrugsJob> _logger;
    private readonly ISender _mediator;
    private readonly IReadRepository<Drug> _repository;
    private readonly IProgressBarFactory _progressBar;
    private readonly PerformingContext _performingContext;
    private readonly INotificationSender _notifications;
    private readonly ICurrentUser _currentUser;
    private readonly IProgressBar _progress;

    public FetchDrugsJob(
        ILogger<FetchDrugsJob> logger,
        ISender mediator,
        IReadRepository<Drug> repository,
        IProgressBarFactory progressBar,
        PerformingContext performingContext,
        INotificationSender notifications,
        ICurrentUser currentUser)
    {
        _logger = logger;
        _mediator = mediator;
        _repository = repository;
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
    public async Task FetchDrugAsync(CancellationToken cancellationToken)
    {
        await NotifyAsync("FetchProductAsync processing has started", 0, cancellationToken);
        await Handle(cancellationToken);
        await NotifyAsync("FetchProductAsync successfully completed", 0, cancellationToken);
    }


    public async Task Handle(CancellationToken cancellationToken)
    {
        for (int i = 0; i < 41; i++)
        {
            var client = new RestClient();
            var request_ = new RestRequest("https://drugbank.vn/services/drugbank/api/public/thuoc?page=" + i + "&size=1000");
            var cancellationTokenSource = new CancellationTokenSource();

            var restResponse = await client.ExecuteAsync(request_, cancellationTokenSource.Token);
            string? content = restResponse.Content;
            // List<DataContent>? dataContents = JsonSerializer.Deserialize<List<DataContent>>();
            try
            {
                var tmp = JArray.Parse(content);
                List<DataContent> dataContents = tmp.ToObject<List<DataContent>>();
                foreach (var dataContent in dataContents)
                {


                    await _mediator.Send(
                        new CreateDrugRequest
                        {
                            Code = dataContent.id,
                            TenThuoc = dataContent.tenThuoc,
                            DotPheDuyet = dataContent.dotPheDuyet,
                            SoQuyetDinh = dataContent.soQuyetDinh,
                            PheDuyet = dataContent.pheDuyet,
                            SoDangKy = dataContent.soDangKy,
                            HoatChat = dataContent.hoatChat,
                            PhanLoai = dataContent.phanLoai,
                            NongDo = dataContent.nongDo,
                            TaDuoc = dataContent.taDuoc,
                            BaoChe = dataContent.baoChe,
                            DongGoi = dataContent.dongGoi,
                            TieuChuan = dataContent.tieuChuan,
                            TuoiTho = dataContent.tuoiTho,
                            CongTySx = dataContent.congTySx,
                            CongTySxCode = dataContent.congTySxCode,
                            NuocSx = dataContent.nuocSx,
                            DiaChiSx = dataContent.diaChiSx,
                            CongTyDk = dataContent.congTyDk,
                            NuocDk = dataContent.nuocDk,
                            DiaChiDk = dataContent.diaChiDk,
                            NhomThuoc = dataContent.nhomThuoc,
                            FileName = "https://cdn.drugbank.vn/" + dataContent?.meta?.fileName,
                        },
                        cancellationToken);
                }

            }
            catch (Exception)
            {

            }
        }




    }

    public class Meta
    {
        public string? fileName { get; set; }
    }

    public class DataContent
    {
        public string? id { get; set; }
        public string? tenThuoc { get; set; }
        public string? dotPheDuyet { get; set; }
        public string? soQuyetDinh { get; set; }
        public string? pheDuyet { get; set; }
        public string? soDangKy { get; set; }
        public string? hoatChat { get; set; }
        public string? phanLoai { get; set; }
        public string? nongDo { get; set; }
        public string? taDuoc { get; set; }
        public string? baoChe { get; set; }
        public string? dongGoi { get; set; }
        public string? tieuChuan { get; set; }
        public string? tuoiTho { get; set; }
        public string? congTySx { get; set; }
        public string? congTySxCode { get; set; }
        public string? nuocSx { get; set; }
        public string? diaChiSx { get; set; }
        public string? congTyDk { get; set; }
        public string? nuocDk { get; set; }
        public string? diaChiDk { get; set; }

        public string? nhomThuoc { get; set; }
        public string? isHide { get; set; }
        public string? chuY { get; set; }
        public string? ten { get; set; }
        public Meta? meta { get; set; }
        public int? state { get; set; }
    }
}