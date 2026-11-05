
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace SafelyShare.Tests.Config;

public static class ConfigLoader
{

    public static TestSettings Load()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false)
            .AddEnvironmentVariables()
            .Build();

        var settings = configuration
            .GetSection("TestSettings")
            .Get<TestSettings>()
            ?? throw new InvalidOperationException(
                "Could not load TestSettings.");

        var overrideUrl = Environment.GetEnvironmentVariable("TEST_BASEURL");

        if (!string.IsNullOrWhiteSpace(overrideUrl))
        {
            settings.BaseUrl = overrideUrl;
        }

        return settings;
    }

}
