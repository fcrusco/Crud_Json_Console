using CrudJsonConsole.Model;
using CrudJsonConsole.Utils;
using NUnit.Framework;
using System.Text.Json;

namespace CrudJsonConsole.Tests
{
    [TestFixture]
    public class JsonStorageTests
    {
        private string _tempDir = null!;
        private string _jsonPath = null!;

        [SetUp]
        public void Setup()
        {
            _tempDir = Path.Combine(Path.GetTempPath(), "CrudJsonConsoleTests", Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(_tempDir);
            _jsonPath = Path.Combine(_tempDir, "pessoas.json");
        }

        [TearDown]
        public void TearDown()
        {
            try { if (Directory.Exists(_tempDir)) Directory.Delete(_tempDir, true); } catch { }
        }

        [Test]
        public void Carregar_ArquivoNaoExiste_RetornaListaVazia()
        {
            var pessoas = JsonStorage.Carregar(_jsonPath);
            Assert.IsNotNull(pessoas);
            Assert.IsEmpty(pessoas);
        }

        [Test]
        public void SalvarDepoisCarregar_MantemConteudo()
        {
            var lista = new List<Pessoa>
        {
            new Pessoa { Id = 1, Nome = "Ana", Sobrenome = "Silva" },
            new Pessoa { Id = 2, Nome = "Bruno", Sobrenome = "Souza" }
        };

            JsonStorage.Salvar(_jsonPath, lista);
            Assert.That(File.Exists(_jsonPath), Is.True);

            var lidas = JsonStorage.Carregar(_jsonPath);
            Assert.That(lidas.Count, Is.EqualTo(2));
            Assert.That(lidas[0].Nome, Is.EqualTo("Ana"));
            Assert.That(lidas[1].Sobrenome, Is.EqualTo("Souza"));
        }

        [Test]
        public void Salvar_GeraJsonValidoEIdentado()
        {
            var lista = new List<Pessoa> { new Pessoa { Id = 1, Nome = "Ana", Sobrenome = "Silva" } };
            JsonStorage.Salvar(_jsonPath, lista);

            var texto = File.ReadAllText(_jsonPath);
            Assert.That(texto.Contains(Environment.NewLine), Is.True);
            var parsed = JsonSerializer.Deserialize<List<Pessoa>>(texto);
            Assert.That(parsed, Is.Not.Null);
            Assert.That(parsed!.Count, Is.EqualTo(1));
        }
    }
}
