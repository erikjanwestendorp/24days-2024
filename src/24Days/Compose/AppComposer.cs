using Our.Umbraco.Community.StorageProviders.GoogleCloud.DependencyInjection;
using Umbraco.Cms.Core.Composing;

namespace _24Days.Compose;

public class AppComposer : IComposer
{
    public void Compose(IUmbracoBuilder builder)
    {
        builder.AddGoogleCloudMediaFileSystem();
    }
}
