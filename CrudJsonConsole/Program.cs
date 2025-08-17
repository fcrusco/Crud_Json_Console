
using CrudJsonConsole.Model;
using CrudJsonConsole.Utils;

// Caminhos
string pastaDados = Path.Combine(AppContext.BaseDirectory, "data");
string caminhoJson = Path.Combine(pastaDados, "pessoas.json");

List<Pessoa> pessoas = new List<Pessoa>();
int proximoId = 1;

// Inicialização
try
{
    Directory.CreateDirectory(pastaDados);
    pessoas = JsonStorage.Carregar(caminhoJson);
    proximoId = DefinirProximoId(pessoas);
    Menu.Loop(pessoas, caminhoJson, ref proximoId);
}
catch (Exception ex)
{
    Console.WriteLine("Erro fatal: " + ex.Message);
}

// ---- funções auxiliares ----
static int DefinirProximoId(List<Pessoa> lista)
{
    try
    {
        if (lista == null || lista.Count == 0) return 1;

        int maior = 1;

        foreach (var p in lista)
            if (p.Id > maior) 
                maior = p.Id;

        return maior + 1;
    }
    catch
    {
        return 1;
    }
}