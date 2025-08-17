using CrudJsonConsole.Model;
using System.Text.Json;

namespace CrudJsonConsole.Utils
{
    public static class JsonStorage
    {
        private static JsonSerializerOptions jsonOpts = new JsonSerializerOptions { WriteIndented = true };

        public static List<Pessoa> Carregar(string caminhoJson)
        {
            List<Pessoa> lista = new List<Pessoa>();

            try
            {
                if (File.Exists(caminhoJson))
                {
                    string json = File.ReadAllText(caminhoJson);
                    lista = JsonSerializer.Deserialize<List<Pessoa>>(json);

                    if (lista != null) 
                        return lista;
                }

                return lista;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return lista;
            }
        }

        public static void Salvar(string caminhoJson, List<Pessoa> pessoas)
        {
            try
            {
                string json = JsonSerializer.Serialize(pessoas, jsonOpts);
                File.WriteAllText(caminhoJson, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
