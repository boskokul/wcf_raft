using Client.ServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    using System;

    namespace MyClientApplication
    {
        class Program
        {
            static void Main(string[] args)
            {
                CalculatorServiceClient client = new CalculatorServiceClient();

                try
                {
                    Console.Write("Enter the first number: ");
                    int number1 = int.Parse(Console.ReadLine());

                    Console.Write("Enter the second number: ");
                    int number2 = int.Parse(Console.ReadLine());

                    int result = client.GetMultiply(number1, number2);
                    Console.WriteLine($"Result of multiplication {number1} and {number2}: {result}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                finally
                {
                    client.Close();
                }
            }
        }
    }

}
