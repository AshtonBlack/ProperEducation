using System;
using System.IO;

namespace HomeWork3._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path;
            Console.WriteLine("Введите директорию");
            path = Console.ReadLine();
            string[] files = Directory.GetFiles(path);
            /* вывод файлов в директории
            foreach(string file in files)
            {
                Console.WriteLine(file);
            }   
            */
            Console.WriteLine("Введите искомое слово");
            string word = Console.ReadLine();
            foreach (string file in files)
            {
                try
                {
                    using (StreamReader sr = new StreamReader(file))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            for (int i = 0; i < line.Length - word.Length + 1; i++)
                            {
                                bool flag = true;
                                for (int k = 0; k < word.Length; k++)
                                {
                                    if (word[k] != line[k + i])
                                    {
                                        flag = false;
                                        break;
                                    }
                                }
                                if (flag)
                                {
                                    Console.WriteLine(file);
                                    Console.WriteLine(line);
                                }
                            }
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("Нет доступа к файлу");
                }               
            }               
        }
    }
}