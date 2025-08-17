using CrudJsonConsole.Model;

namespace CrudJsonConsole.Utils
{
    public static class Menu
    {
        public static void Loop(List<Pessoa> pessoas, string caminhoJson, ref int proximoId)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("CRUD JSON");
                Console.WriteLine("----------------------------");
                Console.WriteLine("[1] Listar");
                Console.WriteLine("[2] Incluir");
                Console.WriteLine("[3] Editar");
                Console.WriteLine("[4] Excluir");
                Console.WriteLine("[5] Buscar por nome");
                Console.WriteLine("[6] Ver caminho do JSON");
                Console.WriteLine("[0] Sair");
                Console.WriteLine("----------------------------");
                Console.Write("Escolha: ");

                string op = Console.ReadLine();
                Console.WriteLine();

                if (op == "0") break;

                try
                {
                    if (op == "1") Listar(pessoas);
                    else if (op == "2") Incluir(pessoas, caminhoJson, ref proximoId);
                    else if (op == "3") Editar(pessoas, caminhoJson);
                    else if (op == "4") Excluir(pessoas, caminhoJson);
                    else if (op == "5") BuscarPorNome(pessoas);
                    else if (op == "6") MostrarCaminho(caminhoJson);
                    else Console.WriteLine("Opção inválida.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro: " + ex.Message);
                }

                Console.WriteLine();
                Console.Write("Pressione ENTER para continuar...");
                Console.ReadLine();
            }
        }

        // ---------- Operações ----------
        private static void Listar(List<Pessoa> pessoas)
        {
            if (pessoas.Count == 0)
            {
                Console.WriteLine("Nenhum registro encontrado.");
                return;
            }

            Console.WriteLine("ID  | Nome Completo");
            Console.WriteLine("-------------------------------");
            foreach (Pessoa p in pessoas.OrderBy(p => p.Id))
            {
                string nomeCompleto = (p.Nome ?? "") + " " + (p.Sobrenome ?? "");
                Console.WriteLine(p.Id.ToString().PadLeft(3) + " | " + nomeCompleto.Trim());
            }
        }

        private static void Incluir(List<Pessoa> pessoas, string caminhoJson, ref int proximoId)
        {
            Pessoa p = new Pessoa();

            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Sobrenome: ");
            string sobrenome = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(nome))
            {
                Console.WriteLine("Nome é obrigatório.");
                return;
            }
            if (string.IsNullOrWhiteSpace(sobrenome))
            {
                Console.WriteLine("Sobrenome é obrigatório.");
                return;
            }

            p.Id = proximoId;
            p.Nome = nome.Trim();
            p.Sobrenome = sobrenome.Trim();

            pessoas.Add(p);
            proximoId = proximoId + 1;

            JsonStorage.Salvar(caminhoJson, pessoas);
            Console.WriteLine("Registro incluído com sucesso (ID " + p.Id + ").");
        }

        private static void Editar(List<Pessoa> pessoas, string caminhoJson)
        {
            if (pessoas.Count == 0)
            {
                Console.WriteLine("Nada para editar.");
                return;
            }

            Console.Write("Informe o ID do registro a editar: ");
            string idStr = Console.ReadLine();

            int id;
            if (!int.TryParse(idStr, out id))
            {
                Console.WriteLine("ID inválido.");
                return;
            }

            Pessoa p = pessoas.FirstOrDefault(x => x.Id == id);
            if (p == null)
            {
                Console.WriteLine("Registro não encontrado.");
                return;
            }

            Console.WriteLine("Deixe em branco para manter o valor atual.");
            Console.WriteLine("Atual: Nome = " + p.Nome + ", Sobrenome = " + p.Sobrenome);

            Console.Write("Novo Nome: ");
            string novoNome = Console.ReadLine();
            Console.Write("Novo Sobrenome: ");
            string novoSobrenome = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(novoNome)) p.Nome = novoNome.Trim();
            if (!string.IsNullOrWhiteSpace(novoSobrenome)) p.Sobrenome = novoSobrenome.Trim();

            JsonStorage.Salvar(caminhoJson, pessoas);
            Console.WriteLine("Registro atualizado com sucesso.");
        }

        private static void Excluir(List<Pessoa> pessoas, string caminhoJson)
        {
            if (pessoas.Count == 0)
            {
                Console.WriteLine("Nada para excluir.");
                return;
            }

            Console.Write("Informe o ID do registro a excluir: ");
            string idStr = Console.ReadLine();

            int id;
            if (!int.TryParse(idStr, out id))
            {
                Console.WriteLine("ID inválido.");
                return;
            }

            Pessoa p = pessoas.FirstOrDefault(x => x.Id == id);
            if (p == null)
            {
                Console.WriteLine("Registro não encontrado.");
                return;
            }

            Console.Write("Tem certeza que deseja excluir (s/N)? ");
            string conf = Console.ReadLine();
            if (conf != null && (conf.Equals("s", StringComparison.OrdinalIgnoreCase) || conf.Equals("sim", StringComparison.OrdinalIgnoreCase)))
            {
                pessoas.RemoveAll(x => x.Id == id);
                JsonStorage.Salvar(caminhoJson, pessoas);
                Console.WriteLine("Registro excluído com sucesso.");
            }
            else
            {
                Console.WriteLine("Operação cancelada.");
            }
        }

        private static void BuscarPorNome(List<Pessoa> pessoas)
        {
            Console.Write("Digite parte do nome/sobrenome: ");
            string termo = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(termo))
            {
                Console.WriteLine("Termo vazio.");
                return;
            }

            termo = termo.Trim();
            List<Pessoa> achados = pessoas
                .Where(p => (p.Nome ?? "").Contains(termo, StringComparison.OrdinalIgnoreCase)
                         || (p.Sobrenome ?? "").Contains(termo, StringComparison.OrdinalIgnoreCase))
                .OrderBy(p => p.Id)
                .ToList();

            if (achados.Count == 0)
            {
                Console.WriteLine("Nenhum resultado.");
                return;
            }

            Console.WriteLine("ID  | Nome Completo");
            Console.WriteLine("-------------------------------");
            foreach (var p in achados)
            {
                string nomeCompleto = (p.Nome ?? "") + " " + (p.Sobrenome ?? "");
                Console.WriteLine(p.Id.ToString().PadLeft(3) + " | " + nomeCompleto.Trim());
            }
        }

        private static void MostrarCaminho(string caminhoJson)
        {
            Console.WriteLine("JSON: " + caminhoJson);
        }
    }
}
