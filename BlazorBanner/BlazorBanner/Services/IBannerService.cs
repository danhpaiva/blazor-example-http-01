namespace BlazorBanner.Services;

public interface IBannerService
{
    Task<List<string>> GetBanners();
}
