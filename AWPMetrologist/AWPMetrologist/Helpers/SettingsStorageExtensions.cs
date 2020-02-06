using System;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;

namespace AWPMetrologist.Helpers
{
    public static class SettingsStorageExtensions
    {
        public static bool IsRoamingStorageAvailable(this ApplicationData appData)
        {
            return appData.RoamingStorageQuota == 0;
        }

        public static async Task SaveAsync<T>(this StorageFolder folder, string name, T content)
        {
            var file = await folder.CreateFileAsync(GetFileName(name), CreationCollisionOption.ReplaceExisting);
            var fileContent = await Json.StringifyAsync(content);

            await FileIO.WriteTextAsync(file, fileContent);
        }

        public static async Task<T> ReadAsync<T>(this StorageFolder folder, string name)
        {
            if (!File.Exists(Path.Combine(folder.Path, GetFileName(name))))
            {
                return default(T);
            }

            var file = await folder.GetFileAsync($"{name}.json");
            var fileContent = await FileIO.ReadTextAsync(file);

            return await Json.ToObjectAsync<T>(fileContent);
        }

        public static async Task SaveAsync<T>(this ApplicationDataContainer settings, string key, T value)
        {
            settings.Values[key] = await Json.StringifyAsync(value);
        }

        public static async Task<T> ReadAsync<T>(this ApplicationDataContainer settings, string key)
        {
            if (settings.Values.TryGetValue(key, out object obj))
            {
                return await Json.ToObjectAsync<T>((string)obj);
            }

            return default(T);
        }

        private static string GetFileName(string name)
        {
            return string.Concat(name, FILE_EXTENSION);
        }

        private const string FILE_EXTENSION = ".json";
    }
}
