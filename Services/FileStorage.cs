using System.Text.Json;

namespace ProjetoCalendario.Services
{
    /// <summary>
    /// Serviço para carregar e guardar dados em ficheiros JSON.
    /// Funciona como uma "base de dados" simples baseada em ficheiros.
    /// </summary>
    public class FileStorage
    {
        /// <summary>
        /// Carrega uma lista de objetos do ficheiro JSON especificado.
        /// </summary>
        /// <typeparam name="T">Tipo dos objetos a carregar.</typeparam>
        /// <param name="file">Nome do ficheiro JSON.</param>
        /// <returns>Lista de objetos do tipo T. Se o ficheiro não existir, devolve um alista vazia.</returns>
        public static List<T> Load<T>(string file)
        {
            //Se o ficheiro não existir, devolve uma lista vazia.
            if (!File.Exists(file))
                return new List<T>();

            //Lê o conteúdo JSON do ficheiro.
            var json = File.ReadAllText(file);
            //Desserializa o JSON numa lista de objetos do tipo T, se a desserialização falhar, devolve uma lista vazia.
            return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
        }

        /// <summary>
        /// Guarda uma lista de objetos no ficheiro JSON especificado.
        /// </summary>
        /// <typeparam name="T">Tipo dos objetos a guardar.</typeparam>
        /// <param name="file">Nome do ficheiro JSON.</param>
        /// <param name="data">Lista de objetos a guardar.</param>
        public static void Save<T>(string file, List<T> data)
        {
            //Converte a lista de objetos para JSON formatado.
            var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            //Escreve o JSON no ficheiro, sobrescrevendo o conteúdo existente.
            File.WriteAllText(file, json);
        }
    }
}
