
namespace SafelyShare.Tests.Config;

public class TestSettings
{
    public string BaseUrl { get; set; } = "https://safelyshare.se/";
    public string Browser { get; set; } = "chromium";
    public bool Headless { get; set; } = true;
    public int DefaultTimeoutMs { get; set; } = 30000;
}
