using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace BlazorBanner.Services;

public class BannerService : IBannerService
{
    private readonly IHttpClientFactory httpClientFactory;

    public BannerService(IHttpClientFactory httpClientFactory)
    {
        this.httpClientFactory = httpClientFactory;
    }

    public async Task<List<string>> GetBanners()
    {
        using (var httpClient = httpClientFactory.CreateClient())
        {
            var stringJson = await httpClient.GetStringAsync("https://raw.githubusercontent.com/danhpaiva/files-for-classes/refs/heads/main/banner/naruto/banners.json");

            var items = JsonNode.Parse(stringJson).AsObject()["items"];

            return JsonSerializer.Deserialize<List<string>>(items);
        }
    }
}
