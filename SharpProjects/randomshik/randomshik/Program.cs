using System;

namespace randomshik
{
    class Program
    {
        public static int ChooseOne(double[] chances)
        {
            Random r = new Random();
            int x = 0;
            int roll = r.Next(10000);
            double minvalue = 0;
            for (int i = 0; i < chances.Length; i++)
            {                
                if (roll < minvalue + chances[i] * 100)
                {
                    x = i + 1;
                    break;
                }                    
                else minvalue += chances[i] * 100;
            }
            return x;
        }

        public static string rarityLit(int x)
        {
            string lit = "F";
            if (x == 2) lit = "E";
            if (x == 3) lit = "D";
            if (x == 4) lit = "C";
            if (x == 5) lit = "B";
            if (x == 6) lit = "A";
            if (x == 7) lit = "S";
            return lit;
        }

        static void Main(string[] args)
        {
            int[] statistic = new int[7];
            string[] statlit = { "F", "E", "D", "C", "B", "A", "S" };
            int packs = 0;
            do
            {
                double[,] cardChances = {{ 0, 95, 5, 0, 0, 0, 0 },
                                         { 0, 95, 5, 0, 0, 0, 0 },
                                         { 0, 79, 18.5, 2.5, 0, 0, 0 },
                                         { 0, 0, 65, 34.15, 0.5, 0.25, 0.1 },
                                         { 0, 0, 0, 82.85, 14, 2.5, 0.65 }};
                double[] currentCardChances = new double[7];
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 7; j++)
                    {
                        currentCardChances[j] = cardChances[i, j];
                    }
                    int x = ChooseOne(currentCardChances);
                    statistic[(x - 1)]++;
                    Console.WriteLine(rarityLit(x));
                }
                packs++;
                Console.WriteLine("Press any key");
            } while (Console.ReadKey().KeyChar != 'q');
            Console.WriteLine();
            Console.WriteLine(packs + " packs openned");
            for (int i = 0; i < statistic.Length; i++)
            {
                Console.WriteLine(statlit[i] + " " + statistic[i]);
            }            
        }        
    }
}