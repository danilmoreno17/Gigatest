namespace Kameyo.Infrastructure.AzureServices.Settings
{
    public class BlobStorageSettings
    {
        public const string SettingName = "BlobStorageSettings";

        public string ConnectionString { get; set; }
    }
}
