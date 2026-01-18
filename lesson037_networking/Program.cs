// using UriNamespace;
// DemoUri.RunDemo();
// =========================================

// using DnsNamespace;
// DemoDns.RunDemo();
// =========================================

// using PingNamespace;
// DemoPing.RunDemo();
// =========================================

using System.Net;
using System.Net.Http.Headers;
using System.Text;

class Program
{
    static void ShowHeaders(HttpResponseHeaders headers)
    {
        Console.WriteLine("=-=-=-=-= Cac header =-=-=-=-=");
        foreach (var header in headers)
        {
            Console.WriteLine($"{header.Key,35} : {string.Join(' ', header.Value)}");
        }
    }

    static async Task<string> GetWebContent(string url)
    {
        // Khởi tạo instance http client
        using var httpClient = new HttpClient();

        try
        {
            // Thiết lập các Header cho request nếu cần
            // httpClient.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml+json");

            // Thực hiện truy vấn GET
            HttpResponseMessage response = await httpClient.GetAsync(url);

            // Lấy các header của response trả về
            ShowHeaders(response.Headers);

            string html = await response.Content.ReadAsStringAsync();

            return html;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return "Loi";
        }
    }

    static async Task<byte[]?> DownloadDataBytes(string url)
    {
        // Khởi tạo instance http client
        using var httpClient = new HttpClient();

        try
        {
            // Thiết lập các Header cho request nếu cần
            // httpClient.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml+json");

            // Thực hiện truy vấn GET
            HttpResponseMessage response = await httpClient.GetAsync(url);

            // Lấy các header của response trả về
            ShowHeaders(response.Headers);

            byte[] bytes = await response.Content.ReadAsByteArrayAsync();

            return bytes;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return null;
        }
    }

    static async Task DownloadStream(string url, string filename)
    {
        using HttpClient httpClient = new HttpClient();

        try
        {
            HttpResponseMessage response = await httpClient.GetAsync(url);

            using var stream = await response.Content.ReadAsStreamAsync();

            using var streamWrite = File.OpenWrite(filename);

            int SIZEBUFFER = 1024 * 4;
            byte[] buffer = new byte[SIZEBUFFER];

            bool endread = false;
            do
            {
                int bytesRead = await stream.ReadAsync(buffer, 0, SIZEBUFFER);

                if (bytesRead == 0) endread = true;
                else
                {
                    await streamWrite.WriteAsync(buffer, 0, bytesRead);
                }
            }
            while (!endread);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public class MyHttpClientHandler : HttpClientHandler
    {
        public MyHttpClientHandler(CookieContainer cookie_container)
        {

            CookieContainer = cookie_container;     // Thay thế CookieContainer mặc định
            AllowAutoRedirect = false;                // không cho tự động Redirect
            AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
            UseCookies = true;
        }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
                                                                     CancellationToken cancellationToken)
        {
            Console.WriteLine("Bất đầu kết nối " + request.RequestUri?.ToString());
            // Thực hiện truy vấn đến Server
            var response = await base.SendAsync(request, cancellationToken);
            Console.WriteLine("Hoàn thành tải dữ liệu");
            return response;
        }
    }

    public class ChangeUri : DelegatingHandler
    {
        public ChangeUri(HttpMessageHandler innerHandler) : base(innerHandler) { }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
                                                               CancellationToken cancellationToken)
        {
            var host = request.RequestUri?.Host.ToLower();
            Console.WriteLine($"Check in  ChangeUri - {host}");
            if (host != null && host.Contains("google.com"))
            {
                // Đổi địa chỉ truy cập từ google.com sang github
                request.RequestUri = new Uri("https://github.com/");
            }
            // Chuyển truy vấn cho base (thi hành InnerHandler)
            return base.SendAsync(request, cancellationToken);
        }
    }


    public class DenyAccessFacebook : DelegatingHandler
    {
        public DenyAccessFacebook(HttpMessageHandler innerHandler) : base(innerHandler) { }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
                                                                     CancellationToken cancellationToken)
        {

            var host = request.RequestUri?.Host.ToLower();
            Console.WriteLine($"Check in DenyAccessFacebook - {host}");
            if (host != null && host.Contains("facebook.com"))
            {
                var response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new ByteArrayContent(Encoding.UTF8.GetBytes("Không được truy cập"));
                return await Task.FromResult<HttpResponseMessage>(response);
            }
            // Chuyển truy vấn cho base (thi hành InnerHandler)
            return await base.SendAsync(request, cancellationToken);
        }
    }

    static async Task Main()
    {
        // var url = "https://xuanthulab.net";

        // var html = await GetWebContent(url);

        // Console.WriteLine(html);
        // =====================================

        // var url = "https://raw.githubusercontent.com/xuanthulabnet/jekyll-example/master/images/jekyll-01.png";
        // var bytes = await DownloadDataBytes(url) ?? [];

        // string filename = "pic-1.png";
        // using var stream = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None);
        // stream.Write(bytes, 0, bytes.Length);
        // =====================================

        // var url = "https://raw.githubusercontent.com/xuanthulabnet/jekyll-example/master/images/jekyll-01.png";

        // await DownloadStream(url, "pic-2.png");
        // =====================================

        string url = "https://www.google.com";

        var cookie = new CookieContainer();

        // Tạo chuỗi handler
        var bottomHandler = new MyHttpClientHandler(cookie);
        var changeUriHandler = new ChangeUri(bottomHandler);
        var DenyAccessFacebookHandler = new DenyAccessFacebook(changeUriHandler);

        using var httpClient = new HttpClient(DenyAccessFacebookHandler);

        using var httpRequestMessage = new HttpRequestMessage();
        httpRequestMessage.Method = HttpMethod.Post;
        httpRequestMessage.RequestUri = new Uri(url);
        httpRequestMessage.Headers.Add("User-Agent", "Mozilla/5.0");

        var parameters = new List<KeyValuePair<string, string>>
        {
            new KeyValuePair<string, string>("key1", "value1"),
            new KeyValuePair<string, string>("key2", "value2-1"),
            new KeyValuePair<string, string>("key2", "value2-2")
        };

        httpRequestMessage.Content = new FormUrlEncodedContent(parameters);

        using var response = await httpClient.SendAsync(httpRequestMessage);

        cookie.GetCookies(new Uri(url)).ToList().ForEach(c =>
        {
            Console.WriteLine($"{c.Name} : {c.Value}");
        });

        var html = await response.Content.ReadAsStringAsync();
        Console.WriteLine(html);
    }
}