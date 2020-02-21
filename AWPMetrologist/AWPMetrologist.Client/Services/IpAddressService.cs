using AWPMetrologist.Client.Helpers;
using System;
using System.Net;
using System.Threading.Tasks;
using Windows.Storage;

namespace AWPMetrologist.Client.Services
{
    public static class IpAddressService
    {

        public static async Task InitializeAsync()
        {
            Ip = await LoadIpFromSettingsAsync();
            Port = await LoadPortFromSettingsAsync();
        }

        public static async Task SetIpPortAsync(string ip, string port)
        {
            Ip = ip;
            Port = port;

            await SaveIpInSettingsAsync(Ip);
            await SavePortInSettingsAsync(Port);

            OnIpChanged(null, Ip);
            OnPortChanged(null, Port);
        }

        public static async Task SetIpAsync(string ip)
        {
            Ip = ip;

            await SaveIpInSettingsAsync(Ip);

            OnIpChanged(null, Ip);
        }

        public static async Task SetPortAsync(string port)
        {
            Port = port;

            await SavePortInSettingsAsync(Port);

            OnPortChanged(null, Ip);
        }

        private static async Task<string> LoadIpFromSettingsAsync()
        {
            string cacheIp = IPAddress.Loopback.ToString();
            string ip = await ApplicationData.Current.LocalSettings.ReadAsync<string>(SettingsKeyIp);

            if (!string.IsNullOrEmpty(ip))
            {
                cacheIp = ip;
            }

            return cacheIp;
        }

        private static async Task<string> LoadPortFromSettingsAsync()
        {
            string cachePort = "64455";
            string port = await ApplicationData.Current.LocalSettings.ReadAsync<string>(SettingsKeyPort);

            if (!string.IsNullOrEmpty(port))
            {
                cachePort = port;
            }

            return port;
        }

        private static async Task SaveIpInSettingsAsync(string ip)
        {
            await ApplicationData.Current.LocalSettings.SaveAsync(SettingsKeyIp, ip);
        }

        private static async Task SavePortInSettingsAsync(string port)
        {
            await ApplicationData.Current.LocalSettings.SaveAsync(SettingsKeyPort, port);
        }

        public static string Ip { get; set; } = IPAddress.Loopback.ToString();
        public static string Port { get; set; } = 64455.ToString();

        public static event EventHandler<string> OnIpChanged = (sender, args) => { };
        public static event EventHandler<string> OnPortChanged = (sender, args) => { };

        private const string SettingsKeyIp = "CurrentIp";
        private const string SettingsKeyPort = "CurrentPort";
    }
}
