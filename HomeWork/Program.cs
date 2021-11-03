using System;
using System.IO;
using System.IO.Compression;
namespace HomeWork
{
    class Program
    {
        public static string inputPath = Directory.GetCurrentDirectory() + "\\input.txt";
        /// <summary>
        /// получение входного числа
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        static int GetInputNumber(string path)
        {
            int inputN = 0;
            using(StreamReader streamReader = new StreamReader(path))
            {
                while (!streamReader.EndOfStream)
                {
                    if (!int.TryParse(streamReader.ReadToEnd(), out inputN))
                    {
                        Console.WriteLine($"Внесите корректные данные в файл");
                        Environment.Exit(1);
                    }
                }
            }
            return inputN;
        }
        /// <summary>
        /// Разложение на простые множители
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        static int GetCountMultipliers(int number)
        {
            int count = 0;
            int cycles = number;
            while(number != 1)
            {
                for (int i = 2; i <= number; i++)
                {
                    if (number % i == 0)
                    {
                        number /= i;
                        count++;
                        break;
                    }
                }
            }
            return count;
        }
        static void GetSplitting(int countGroup, int inputN)
        {
            string pathWriter = $"{Directory.GetCurrentDirectory()}\\answer.txt";

            using (StreamWriter sw = new StreamWriter(pathWriter))
            {
                sw.Write($"Группа {1}: {1}");
                int temp = 2;
                while(temp <= countGroup)
                {
                    sw.Write($"\nГруппа {temp}:");
                    int endCycles;
                    if ((int)Math.Pow(2, temp) > inputN)
                        endCycles = inputN + 1;
                    else
                        endCycles = (int)Math.Pow(2, temp);
                    for (int i = (int)Math.Pow(2, temp - 1); i < endCycles; i++)
                        sw.Write($" {i}");
                    temp++;
                }
            }
        }
        static void Archiving(string pathWriterDirectory)
        {
            string compressed = "\\answer.zip";
            using (FileStream ss = new FileStream(pathWriterDirectory + "\\answer.txt", FileMode.OpenOrCreate))
            {
                using (FileStream ts = File.Create($"{pathWriterDirectory}{compressed}"))
                {
                    using (GZipStream cs = new GZipStream(ts, CompressionMode.Compress))
                    {
                        ss.CopyTo(cs);
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            DateTime time = new DateTime();
            time = DateTime.Now;

            int inputN = GetInputNumber(inputPath);
            int countGroup = (int)Math.Ceiling(Math.Log2(Convert.ToDouble(inputN)));
            
            Console.WriteLine($"Нажмите 1 или 2 для выбора соответствующего режима");
            char key = Console.ReadKey(true).KeyChar;

            if (char.ToLower(key) == '1')
            {
                Console.WriteLine($"M = {countGroup}");
            }
            else if (char.ToLower(key) == '2')
            {
                Console.WriteLine($"Выполняются вычисления");
                GetSplitting(countGroup, inputN);

                Console.WriteLine($"Хотите заархивировать нажмите д/н?");
                char keyContinue = Console.ReadKey(true).KeyChar;
                if(char.ToLower(keyContinue) == 'д' || char.ToLower(keyContinue) == 'l')
                {
                    Console.WriteLine($"Архивация...");
                    Archiving(Directory.GetCurrentDirectory());
                }
            }
            else
            {
                Console.WriteLine($"Нажата неверная клавиша");
                System.Environment.Exit(1);
            }
            
            Console.WriteLine($"{(DateTime.Now - time).TotalSeconds} секунд");
        }
    }
}
