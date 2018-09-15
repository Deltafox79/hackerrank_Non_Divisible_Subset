using System;

namespace Not_Divisible
{
    class Program
    {
        //Non-Divisible Subsets Problem - Solution By DeltaFoX aka Russo Paolo Rito
        static void Main(string[] args)
        {
            
            Console.WriteLine("Enter the string array divided by space example (1 7 2 4) :\n");
            string[] nd = Console.ReadLine().Trim().Split(' ');
            //Se Input è minore di 1 Esco dal Soft
            if (nd.Length <= 1)
                Environment.Exit(0);
            //Converto l'intero array di stringa dato in input in int
            int[] array = Array.ConvertAll(nd, int.Parse);
            Console.WriteLine("\nEnter the unique values of the set :\n");
            //Converto in int il valore unique dato in Input
            int nl = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\n\nFinal Result :\n");
            //passo al metodo nonDivisibleSubset i due valori precedentementi immessi per il calcolo dei numeri non divisibili
            Console.WriteLine(nonDivisibleSubset(nl, array).ToString());
            Console.ReadLine();
        }
        //Metodo per il calcolo int dei valori non divisibili per x
        private static int nonDivisibleSubset(int k, int[] arr)
        {
            //Inizializzo la variabile resto con lungezza uguale al valore uniques
            int[] resto = new int[k];
            int count = 0;
            // calcolo tutti i resti degli elementi dell'array
            for (int i = 0; i < arr.Length; i++)
                resto[arr[i] % k]++;

            // ottengo il conteggio per ogni sezione
            for (int j = 1; j <= (k / 2); j++)
            {
                // un solo resto valido
                if (j == k - j)
                {
                    count++;
                    continue;
                }
                // altrimenti aggiungo il dato resto con il valore più grande
                count += Math.Max(resto[j], resto[k - j]);
            }
            //aggiungo al conteggio solo il valore conn divisori equivalenti primo byte dell'array resto
            if (resto[0] > 0)
                count++;
            //Ritorno il valore del numero dei dividenti validi trovati
            return count;
        }
    }
}
