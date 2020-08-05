using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirportDatabaseFirst.DataBase;

namespace AirportDatabaseFirst
{
    class Program
    {
        /// <summary>
        /// This is just to test the storedprodeces and how ef handles calls to it..        
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Find Route Based on distiation");
                    string userInput = Console.ReadLine();
                while (userInput.Length < 3)
                {
                    Console.WriteLine("Min 3 letters");
                    userInput = Console.ReadLine();
                }
                Console.WriteLine($"Looking for {userInput.Substring(0, 3)}");
                using (var context = new DataBase.AirportEntities())
                {
                    GetAllRoutes_Result result = context.GetAllRoutes(userInput.Substring(0, 3)).FirstOrDefault();
                    if (result != null)
                    {

                        Console.WriteLine($"Destination: {result.Destination}\nOrigin : {result.Origin}\n Distance:{result.Distance} km");
                    }
                    else
                    {
                        Console.WriteLine($"Sorry did not find one try agine or try with one of them {context.Airports.Where(x => x.Name.Contains(userInput.Substring(0, 1))).FirstOrDefault().IATA} ");
                    }
                }
            }
            Console.WriteLine("10 Tryis start over");
            Console.Read();
        }
    }
}
