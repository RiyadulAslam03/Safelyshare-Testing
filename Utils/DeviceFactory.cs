
using Microsoft.Playwright;

namespace SafelyShare.Tests.Utils;

public static class DeviceFactory
{
    public static BrowserNewContextOptions GetDeviceOptions(
        IPlaywright playwright, string deviceName)
    {
        if (deviceName != "iPhone 13" &&
            deviceName != "Pixel 5")
        {
            throw new ArgumentException(
                $"Unsupported device: {deviceName}");
        }

        return playwright.Devices[deviceName];
    }
}
