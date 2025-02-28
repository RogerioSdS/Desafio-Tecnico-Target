using Newtonsoft.Json;

namespace Questao3_Faturamento_Mensal
{
    internal class Program
    {
        static void Main()
        {
            // Buscando o JSON na raiz do programa
            string caminhoArquivo = Path.Combine(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName, "dados.json");

            if (!File.Exists(caminhoArquivo))
            {
                Console.WriteLine("Arquivo 'faturamento.json' não encontrado.");
                return;
            }

            // Dados de faturamento diário
            string jsonData = File.ReadAllText(caminhoArquivo);
            var faturamento = JsonConvert.DeserializeObject<List<Faturamento>>(jsonData);

            double menorFaturamento = faturamento.Where(f => f.Valor > 0).Min(f => f.Valor);
            double maiorFaturamento = faturamento.Where(f => f.Valor > 0).Max(f => f.Valor);

            double mediaMensal = faturamento.Where(f => f.Valor > 0).Average(f => f.Valor);
            int diasAcimaDaMedia = faturamento.Count(f => f.Valor > mediaMensal);

            Console.WriteLine($"Menor faturamento: R${menorFaturamento:F2}");
            Console.WriteLine($"Maior faturamento: R${maiorFaturamento:F2}");
            Console.WriteLine($"Número de dias acima da média mensal: {diasAcimaDaMedia}");

            // Faturamento total e por estado
            Dictionary<string, double> faturamentoPorEstado = new Dictionary<string, double>
        {
            { "SP", 67836.43 },
            { "RJ", 36678.66 },
            { "MG", 29229.88 },
            { "ES", 27165.48 },
            { "Outros", 19849.53 }
        };

            double totalFaturamento = faturamentoPorEstado.Values.Sum();

            Console.WriteLine("\nPercentual de representação de cada estado no faturamento total:");
            foreach (var estado in faturamentoPorEstado)
            {
                double percentual = (estado.Value / totalFaturamento) * 100;
                Console.WriteLine($"{estado.Key}: {percentual:F2}%");
            }
        }
    }

    public class Faturamento
    {
        public int Dia { get; set; }
        public double Valor { get; set; }
    }
}