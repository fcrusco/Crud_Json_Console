using System.Text;

namespace CrudJsonConsole.Tests
{
    /// <summary>
    /// Redireciona Console.In/Out para testes de fluxo do Menu.
    /// </summary>
    internal sealed class ConsoleTestHelper : IDisposable
    {
        private readonly TextWriter _origOut;
        private readonly TextReader _origIn;
        private readonly StringWriter _outWriter;
        private readonly StringBuilder _buffer;

        public ConsoleTestHelper(string inputScript)
        {
            _origOut = Console.Out;
            _origIn = Console.In;

            _buffer = new StringBuilder();
            _outWriter = new StringWriter(_buffer);

            Console.SetOut(_outWriter);
            Console.SetIn(new StringReader(inputScript));
        }

        public string GetOutput() => _buffer.ToString();

        public void Dispose()
        {
            _outWriter.Flush();
            Console.SetOut(_origOut);
            Console.SetIn(_origIn);
            _outWriter.Dispose();
        }

        public static string Lines(params string[] lines) =>
            string.Join(Environment.NewLine, lines) + Environment.NewLine;
    }
}
