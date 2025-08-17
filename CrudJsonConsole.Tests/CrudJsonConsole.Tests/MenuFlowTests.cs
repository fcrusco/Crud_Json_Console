using CrudJsonConsole.Model;
using CrudJsonConsole.Utils;
using NUnit.Framework;

namespace CrudJsonConsole.Tests
{
    [TestFixture]
    public class MenuFlowTests
    {
        private string _tempDir = null!;
        private string _jsonPath = null!;

        [SetUp]
        public void Setup()
        {
            _tempDir = Path.Combine(Path.GetTempPath(), "CrudJsonConsoleMenuTests", Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(_tempDir);
            _jsonPath = Path.Combine(_tempDir, "pessoas.json");
        }

        [TearDown]
        public void TearDown()
        {
            try { if (Directory.Exists(_tempDir)) Directory.Delete(_tempDir, true); } catch { }
        }

        private static List<Pessoa> NovaLista() => new();

        [Test]
        public void Fluxo_Incluir_Listar_Sair()
        {
            var pessoas = NovaLista();
            var nextId = 1;

            var script = ConsoleTestHelper.Lines(
                "2", "Ana", "Silva", "", // incluir
                "1", "",                 // listar
                "0"                      // sair
            );

            using var console = new ConsoleTestHelper(script);
            Menu.Loop(pessoas, _jsonPath, ref nextId);
            var outText = console.GetOutput();

            Assert.That(outText, Does.Contain("Registro incluído com sucesso"));
            Assert.That(outText, Does.Contain("ID  | Nome Completo"));
            var lidas = JsonStorage.Carregar(_jsonPath);
            Assert.That(lidas.Count, Is.EqualTo(1));
            Assert.That(lidas[0].Id, Is.EqualTo(1));
            Assert.That(lidas[0].Nome, Is.EqualTo("Ana"));
            Assert.That(lidas[0].Sobrenome, Is.EqualTo("Silva"));
        }

        [Test]
        public void Fluxo_Editar_Buscar_Excluir()
        {
            var pessoas = NovaLista();
            pessoas.Add(new Pessoa { Id = 1, Nome = "Ana", Sobrenome = "Silva" });
            JsonStorage.Salvar(_jsonPath, pessoas);
            var nextId = 2;

            var script = ConsoleTestHelper.Lines(
                "3", "1", "Ana Maria", "", "",     // editar (mantém sobrenome)
                "5", "Ana", "",                   // buscar
                "4", "1", "s", "",                 // excluir
                "0"
            );

            using var console = new ConsoleTestHelper(script);
            Menu.Loop(pessoas, _jsonPath, ref nextId);
            var outText = console.GetOutput();

            Assert.That(outText, Does.Contain("Registro atualizado com sucesso"));
            Assert.That(outText, Does.Contain("Registro excluído com sucesso"));

            var lidas = JsonStorage.Carregar(_jsonPath);
            Assert.That(lidas, Is.Empty);
        }

        [Test]
        public void Incluir_ComNomeVazio_RejeitaEnaoIncrementaId()
        {
            var pessoas = NovaLista();
            var nextId = 1;

            var script = ConsoleTestHelper.Lines(
                "2", "", "Souza", "", // inclusão inválida
                "0"
            );

            using var console = new ConsoleTestHelper(script);
            Menu.Loop(pessoas, _jsonPath, ref nextId);
            var outText = console.GetOutput();

            Assert.That(outText, Does.Contain("Nome é obrigatório."));
            var lidas = JsonStorage.Carregar(_jsonPath);
            Assert.That(lidas, Is.Empty);
            Assert.That(nextId, Is.EqualTo(1));
        }

        [Test]
        public void MostrarCaminho_ExibeJsonPath()
        {
            var pessoas = NovaLista();
            var nextId = 1;

            var script = ConsoleTestHelper.Lines("6", "", "0");
            using var console = new ConsoleTestHelper(script);
            Menu.Loop(pessoas, _jsonPath, ref nextId);
            var outText = console.GetOutput();

            Assert.That(outText, Does.Contain("JSON: "));
            Assert.That(outText, Does.Contain(_jsonPath));
        }
    }
}
