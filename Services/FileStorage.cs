using System.Text.Json;

namespace ProjetoCalendario.Services
{
    public class FileStorage
    {
        public static List<T> Load<T>(string file)
        {
            if (!File.Exists(file))
                return new List<T>();

            var json = File.ReadAllText(file);
            return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
        }

        public static void Save<T>(string file, List<T> data)
        {
            var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(file, json);
        }
    }
}
