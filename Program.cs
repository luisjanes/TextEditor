using System.ComponentModel;
using System.Dynamic;

namespace TextEditor
{
    class Program
    {
        private static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine("1 - Abrir um arquivo");
            Console.WriteLine("2 - Criar um novo arquivo");
            Console.WriteLine("3 - Sair");
            short.TryParse(Console.ReadLine(), out short option);

            switch (option)
            {
                case 1:
                    OpenFile();
                    break;
                case 2:
                    EditFile();
                    break;
                case 3:
                    Console.WriteLine("Saindo do programa...");
                    Thread.Sleep(2000);
                    System.Environment.Exit(0);
                    break;
                default: 
                    Console.WriteLine("Nenhuma opção válida, voltando ao menu");
                    Thread.Sleep(2000);
                    Menu();
                    break;
            }
        }

        static void OpenFile()
        {
            Console.WriteLine("Qual o caminho do arquivo?");
            string path = Console.ReadLine();
            //string path = @"C:\dev\teste.txt";
            using (var file = new StreamReader(path))
            {
                string text = file.ReadToEnd();
                Console.WriteLine(text);
            }
        }

        static void EditFile()
        {
            Console.WriteLine("Digite seu texto abaixo(ESC para sair):");
            Console.WriteLine("------------------------");
            string text = "";
            do
            {
                text += Console.ReadLine();
                text += Environment.NewLine;
            } while (Console.ReadKey().Key != ConsoleKey.Escape);

            Save(text);
        }
        static void Save(string text)
        {
            Console.Clear();
            Console.WriteLine("Qual caminho para salvar o arquivo?");
            //string path = @"C:\dev\teste.txt";
            string path = Console.ReadLine();

            using (var file = new StreamWriter(path))
            {
                file.Write(text);
            }

            Console.WriteLine($"Arquivo salvo no caminho {path} com sucesso");
            Thread.Sleep(2000);
            Menu();
        }
    }
}

