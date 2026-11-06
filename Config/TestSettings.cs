
namespace SafelyShare.Tests.Config;

public class TestSettings
{
    public string BaseUrl { get; set; } = string.Empty;
    public string Browser { get; set; } = "chromium";
    public bool Headless { get; set; } = true;
    public int DefaultTimeoutMs { get; set; } = 30000;
}
