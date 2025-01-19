using System;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Runtime.Intrinsics.Arm;
using Pagamento.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try 
            {
                Console.WriteLine("Enter contract data");

                Console.Write("Number: ");
                string number = Console.ReadLine();
                
                DateTime contractDate = DateTime.Now;
                while (true)
                {
                    try
                    {
                        Console.Write("Date (dd/MM/yyyy): ");
                        string getContractDate = Console.ReadLine().Trim();
                        contractDate = DateTime.ParseExact(getContractDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        break;
                    }
                    catch (FormatException formattingError)// Add um novo catch que capta erro nos outros formatos... ex: yyyy/MM/dd
                    {
                        Console.WriteLine("Erro: The date entered is in an invalid format. \nUse the format dd/MM/yyyy and try again");
                    }
                }

                Console.Write("Contract value: ");
                double contrectValue = double.Parse(Console.ReadLine().Trim(), CultureInfo.InvariantCulture);

                Console.WriteLine("Enter number of installments: ");
                int installmentsNumber = int.Parse(Console.ReadLine().Trim());

                Contracts contract = new Contracts(number, contractDate, contrectValue, installmentsNumber);
                
                Console.WriteLine(contract.ToString());


            }
            catch (Exception e)
            {
                Console.WriteLine("Ocorreu um erro" + e.Message);
            }
            

        }
    }
}