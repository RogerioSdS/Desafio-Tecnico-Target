namespace Questao2_Fibonacci
{
    internal class Program
    {
        static void Main()
        {
            string resposta;
            do
            {
                Console.Write("Digite um número para verificar se pertence à sequência de Fibonacci: ");
                if (int.TryParse(Console.ReadLine(), out int numero))
                {
                    if (CheckFibonacci(numero))
                        Console.WriteLine($"O número {numero} pertence à sequência de Fibonacci. ✅");
                    else
                        Console.WriteLine($"O número {numero} NÃO pertence à sequência de Fibonacci. ❌");
                }
                else
                {
                    Console.WriteLine("Entrada inválida! Digite um número inteiro.");
                }

                // Garantir que a resposta seja apenas 'S' ou 'N'
                do
                {
                    Console.Write("\nDeseja verificar outro número? (S/N): ");
                    resposta = Console.ReadLine().Trim().ToUpper();
                } while (resposta != "S" && resposta != "N");

            } while (resposta == "S");

            Console.WriteLine("Programa encerrado.");
        }

        static bool CheckFibonacci(int num)
        {
            if (num == 0 || num == 1) return true;

            int a = 0, b = 1, proximo = a + b;

            while (proximo <= num)
            {
                if (proximo == num)
                    return true;

                a = b;
                b = proximo;
                proximo = a + b;
            }

            return false;
        }
    }
}
