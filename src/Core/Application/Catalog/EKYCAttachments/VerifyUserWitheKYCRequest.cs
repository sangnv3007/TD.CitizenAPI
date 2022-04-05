using Newtonsoft.Json;
using RestSharp;
using TD.CitizenAPI.Application.Identity.Users;

namespace TD.CitizenAPI.Application.Catalog.EKYCAttachments;

public class VerifyUserWitheKYCRequest : IRequest<Result<bool>>
{
    public VerifyUserWitheKYCRequest()
    {
    }
}

public class VerifyUserWitheKYCRequestHandler : IRequestHandler<VerifyUserWitheKYCRequest, Result<bool>>
{
    private readonly IRepository<EKYCAttachment> _repository;
    private readonly ICurrentUser _currentUser;
    private readonly IUserService _userService;

    private readonly IStringLocalizer<VerifyUserWitheKYCRequestHandler> _localizer;

    public VerifyUserWitheKYCRequestHandler(IRepository<EKYCAttachment> repository, ICurrentUser currentUser, IUserService userService, IStringLocalizer<VerifyUserWitheKYCRequestHandler> localizer) => (_repository, _currentUser, _userService, _localizer) = (repository, currentUser, userService, localizer);

    public async Task<Result<bool>> Handle(VerifyUserWitheKYCRequest request, CancellationToken cancellationToken)
    {
        string? userName = _currentUser.GetUserName();
        var user = await _userService.GetAsyncByUserName(userName ??"", cancellationToken);

        if (user == null || user.IsVerified)
        {
            throw new NotFoundException("Khong tim thay thong tin nguoi dung hoac nguoi dung da duoc xa thuc" );
        }


        VerifyUserRequest verifyUserRequest = new VerifyUserRequest();

        var list = await _repository.ListAsync(new EKYCAttachmentSpec(userName), cancellationToken);


        var att_mattruoc = list.Where(p => p.ImageType == "MatTruoc").FirstOrDefault();
        var att_matsau = list.Where(p => p.ImageType == "MatSau").FirstOrDefault();
        var att_chandung = list.Where(p => p.ImageType == "ChanDung").FirstOrDefault();

        if (att_mattruoc != null && att_chandung != null && att_matsau != null)
        {
            {
                var client = new RestClient();
                var requestRestclient = new RestRequest("https://api.fpt.ai/vision/idr/vnm", Method.Post);
                requestRestclient.AddHeader("Content-Type", "multipart/form-data");
                requestRestclient.AddHeader("api-key", "drvgOLj5dTQZNPDza4QoHzi4ftByzmZF");
                requestRestclient.AddFile("image", att_mattruoc.Url);
                var cancellationTokenSource = new CancellationTokenSource();

                var restResponse = await client.ExecuteAsync(requestRestclient, cancellationTokenSource.Token);
                ResCMTMatTruoc resCMTMatTruoc = JsonConvert.DeserializeObject<ResCMTMatTruoc>(restResponse.Content);

                if (resCMTMatTruoc != null && resCMTMatTruoc.data.Count > 0)
                {
                    var datamattruoc = resCMTMatTruoc.data.FirstOrDefault();

                    if (string.IsNullOrWhiteSpace(datamattruoc.id))
                    {
                        throw new NotFoundException("Khong nhan dang duoc mat truoc: " + att_mattruoc.Url);

                    }

                    DateTime DateOfBirth = DateTime.ParseExact(datamattruoc.dob ?? "", "dd/MM/yyyy",
                                       System.Globalization.CultureInfo.InvariantCulture);

                   

                    verifyUserRequest.IdentityNumber = datamattruoc.id;
                    verifyUserRequest.FullName = datamattruoc.name;
                    verifyUserRequest.DateOfBirth = DateOfBirth;
                    verifyUserRequest.PlaceOfOrigin = datamattruoc.home;
                    verifyUserRequest.PlaceOfDestination = datamattruoc.address;

                }
                else
                {
                }
            }

            {
                var client = new RestClient();
                var requestRestclient = new RestRequest("https://api.fpt.ai/vision/idr/vnm", Method.Post);
                requestRestclient.AddHeader("Content-Type", "multipart/form-data");
                requestRestclient.AddHeader("api-key", "drvgOLj5dTQZNPDza4QoHzi4ftByzmZF");
                requestRestclient.AddFile("image", att_matsau.Url);
                var cancellationTokenSource = new CancellationTokenSource();

                var restResponse = await client.ExecuteAsync(requestRestclient, cancellationTokenSource.Token);
                ResCMTMatSau resCMTMatSau = JsonConvert.DeserializeObject<ResCMTMatSau>(restResponse.Content);

                if (resCMTMatSau != null && resCMTMatSau.data.Count > 0)
                {
                    var datamattruoc = resCMTMatSau.data.FirstOrDefault();
                    DateTime issue_date = DateTime.ParseExact(datamattruoc.issue_date ?? "", "dd/MM/yyyy",
                                      System.Globalization.CultureInfo.InvariantCulture);

                    verifyUserRequest.IdentityDate = issue_date;
                   

                }
                else
                {
                    throw new NotFoundException("Khong nhan dang duoc mat sau: " + att_mattruoc.Url);
                }
            }

           var tmp = await _userService.VerifyAsyncByUserName(verifyUserRequest, userName??"");
            return Result<bool>.Success(tmp);

        }


        return Result<bool>.Success(false);

    }

    public class ResSoSanhMat
    {
        public string? code { get; set; }
        public DataSoSanhMat data { get; set; }
        public string? message { get; set; }
    }
    public class DataSoSanhMat
    {
        public bool? isMatch { get; set; }
        public double? similarity { get; set; }
        public bool? isBothImgIDCard { get; set; }
    }

    public class ResCMTMatTruoc
    {
        public int? errorCode { get; set; }
        public string? errorMessage { get; set; }
        public List<DataCMTMatTruoc>? data { get; set; }
    }

    public class ResCMTMatSau
    {
        public int? errorCode { get; set; }
        public string? errorMessage { get; set; }
        public List<DataCMTMatSau>? data { get; set; }
    }

    public class DataCMTMatTruoc
    {
        public string? id { get; set; }
        public string? name { get; set; }
        public string? dob { get; set; }
        public string? sex { get; set; }
        public string? nationality { get; set; }
        public string? home { get; set; }
        public string? address { get; set; }
        public string? doe { get; set; }
        public string? type { get; set; }
    }

    public class DataCMTMatSau
    {
        public string? ethnicity { get; set; }
        public string? religion { get; set; }
        public string? features { get; set; }
        public string? issue_date { get; set; }
        public string? issue_loc { get; set; }

    }

}