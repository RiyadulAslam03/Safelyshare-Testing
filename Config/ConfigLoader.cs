
using System;
using System.IO;
using System.Text.Json;

namespace SafelyShare.Tests.Config;

public static class ConfigLoader
{
    public static TestSettings Load()
    {
        string path = Path.Combine(
            AppContext.BaseDirectory,
            "appsettings.json");

        string json = File.ReadAllText(path);

        using JsonDocument document = JsonDocument.Parse(json);

        string settingsJson = document.RootElement
            .GetProperty("TestSettings")
            .GetRawText();

        return JsonSerializer.Deserialize<TestSettings>(settingsJson)
            ?? throw new InvalidOperationException(
                "Could not load TestSettings.");
    }
}
