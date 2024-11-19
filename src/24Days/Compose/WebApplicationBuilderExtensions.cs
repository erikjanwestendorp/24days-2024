using _24Days.Configuration;
using _24Days.Extensions;
using GCP.DotNet.Extensions.SecretManager;

namespace _24Days.Compose;

public static class WebApplicationBuilderExtensions
{
    public static WebApplicationBuilder ConfigureGoogleCloudSecretManagerDefault(this WebApplicationBuilder builder)
    {
        var projectId = builder.Configuration.GetConfiguredInstance<AppSettings.SecretManager>(ProjectConstants.SettingsSections.SecretManager).ProjectId;

        if (string.IsNullOrWhiteSpace(projectId))
        {
            throw new InvalidOperationException("ProjectId is not configured in appsettings.json under 'SecretManager:ProjectId'.");
        }

        builder.Configuration.AddGoogleCloudSecretManager(projectId);

        return builder;
    }
}
