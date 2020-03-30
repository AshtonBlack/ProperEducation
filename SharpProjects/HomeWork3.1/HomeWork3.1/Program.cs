using System;

namespace HomeWork3._1
{
    class Program
    {
        static void Main(string[] args)
        {            
            int[] wordlength = new int[25];

            for(int i = 0; i<25; i++)
            {
                wordlength[0] = 0;
            }

            ConsoleKeyInfo cki;
            int symbolnumber = 0;
            do
            {
                cki = Console.ReadKey();
                if (((cki.Modifiers & ConsoleModifiers.Control) != 0) && cki.Key.ToString() == "D")
                {
                    if (symbolnumber > 0 && symbolnumber < 26) 
                        wordlength[symbolnumber - 1]++;
                    break;
                }
                else
                {
                    if(cki.GetHashCode() == 851981)
                    {
                        Console.WriteLine();
                    }
                    else if (char.IsLetter(cki.KeyChar))
                    {
                        symbolnumber++;
                    }
                    else
                    {
                        if (symbolnumber > 0 && symbolnumber < 26)
                        {
                            wordlength[symbolnumber - 1]++;
                        }                            
                        symbolnumber = 0;
                    }
                }
            } while (true);

            Console.WriteLine();
            for(int i = 0; i < 25; i++)
            {
                Console.WriteLine("Слов из " + (i + 1) + " букв: " + wordlength[i]);
            }

            Console.ReadKey();
        }
    }
}