using System;

namespace AvaliandoExpressoesMatematicas
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World! Informe a expressão matemática:");
            Console.WriteLine($"O resultado é: {new Calculator().Calculate(Console.ReadLine())}");
            Console.ReadKey();
        }
    }
}
