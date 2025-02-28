namespace Questao5_Inversor_String
{
    internal class Program
    {
        static void Main()
        {
            Console.Write("Digite uma string para inverter: ");
            string input = Console.ReadLine();

            string invertedString = InverterString(input);

            Console.WriteLine($"A string invertida é: {invertedString}");
        }

        static string InverterString(string str)
        {
            string inverted = "";  

            for (int i = str.Length - 1; i >= 0; i--)
            {
                inverted += str[i];  
            }

            return inverted;
        }
    }
}
