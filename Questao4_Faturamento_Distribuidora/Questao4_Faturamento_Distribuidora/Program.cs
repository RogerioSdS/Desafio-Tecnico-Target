namespace Questao4_Faturamento_Distribuidora
{
    internal class Program
    {
        static void Main()
        {
            var faturamentoPorEstado = new Dictionary<string, double>
        {
            { "SP", 67836.43 },
            { "RJ", 36678.66 },
            { "MG", 29229.88 },
            { "ES", 27165.48 },
            { "Outros", 19849.53 }
        };

            double totalFaturamento = faturamentoPorEstado.Values.Sum();

            Console.WriteLine("Percentual de representação de cada estado no faturamento total:");

            var percentuais = faturamentoPorEstado
                .Select(estado => new
                {
                    Estado = estado.Key,
                    Percentual = (estado.Value / totalFaturamento) * 100
                });

            foreach (var estado in percentuais)
            {
                Console.WriteLine($"{estado.Estado}: {estado.Percentual:F2}%");
            }
        }
    }
}