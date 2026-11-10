
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace SafelyShare.Tests.Config;

public static class ConfigLoader
{
    private static readonly Lazy<TestSettings> _settings = new(() => LoadSettings());
    public static TestSettings Load() => _settings.Value;
    private static TestSettings LoadSettings()
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



        if (!Uri.TryCreate(settings.BaseUrl, UriKind.Absolute, out var url) ||
            (url.Scheme != Uri.UriSchemeHttp && url.Scheme != Uri.UriSchemeHttps))
        {
            throw new InvalidOperationException("BaseUrl must be a valid HTTP or HTTPS URL.");
        }

        if (settings.DefaultTimeoutMs <= 0)
        {
            throw new InvalidOperationException("DefaultTimeoutMs must be greater than zero.");
        }

        return settings;

        
    }

}
