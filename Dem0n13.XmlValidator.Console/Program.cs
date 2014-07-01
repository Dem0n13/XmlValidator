using System;
using System.IO;

namespace Dem0n13.XmlValidator.ConsoleApp
{
    class Program
    {
        static void Main()
        {
            var lexer = new XmlLexer();
            var parser = new XmlParser();
            var validator = new XmlValidator();

            while (true)
            {
                Console.Write("Введите имя файла (по умолч. - normal.xml)");
                var fileName = Console.ReadLine();
                if (string.IsNullOrEmpty(fileName)) fileName = "normal.xml";

                try
                {
                    var text = File.ReadAllText(fileName);
                    var tokens = lexer.Tokenize(text);
                    var tags = parser.Parse(tokens);
                    validator.Validate(tags);
                    Console.WriteLine("Файл корректен");
                }
                catch (Exception exception)
                {
                    Console.WriteLine("Найдены следующие ошибки:");
                    Console.WriteLine(exception.Message);
                }
            }
        }
    }
}
