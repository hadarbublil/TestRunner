namespace TestRunner
{
    public interface IOutputWriter
    {
        void WriteLine(string line);
    }

    public class ConsoleOutputWriter : IOutputWriter
    {
        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }

    public class FileOutputWriter : IOutputWriter
    {
        private readonly string _filePath;

        public FileOutputWriter(string filePath)
        {
            _filePath = filePath;
            File.WriteAllText(_filePath, string.Empty);
        }

        public void WriteLine(string line)
        {
            using (var writer = new StreamWriter(_filePath, append: true))
            {
                writer.WriteLine(line);
            }
        }
    }
}
