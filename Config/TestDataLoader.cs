
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SafelyShare.Tests.Config;

public sealed class HomePageTestData
{
    [JsonPropertyName("urlPath")]
    public string UrlPath { get; set; } = "/";

    [JsonPropertyName("expectedEnglishText")]
    public string ExpectedEnglishText { get; set; } = "";
}

public static class TestDataLoader
{
    private sealed class HomePageJsonRoot
    {
        [JsonPropertyName("homepage")]
        public HomePageTestData? Homepage { get; set; }
    }

    public static HomePageTestData LoadHomePage()
    {
        string path = Path.Combine(
            AppContext.BaseDirectory,
            "TestData",
            "homepage.json");

        string json = File.ReadAllText(path);

        var data = JsonSerializer.Deserialize<HomePageJsonRoot>(json);

        return data?.Homepage
            ?? throw new InvalidDataException(
                "Homepage test data is missing.");
    }
}
