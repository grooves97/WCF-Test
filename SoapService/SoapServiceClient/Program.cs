using SoapServiceClient.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoapServiceClient
{
    class Program
    {
        static void Main(string[] args)
        {
            SplitClient splitClient = new SplitClient();
            InfoClient infoClient = new InfoClient();
            AuthClient authClient = new AuthClient();

            Console.WriteLine("ProfileService say hello>>>");
            //Регистрация
            Console.WriteLine("Please sign up");
            authClient.Register(Console.ReadLine(), Console.ReadLine());
            //Авторизация
            Console.WriteLine("Please log in");
            authClient.Login(Console.ReadLine(),Console.ReadLine());

            //Split string
            string splitText = "Hello world!";
            var result = splitClient.Text(splitText);
            foreach (var item in result)
            {
                Console.WriteLine($"{item}");
            }

            //Post info
            var postResult = infoClient.PostInfo(112233445566,Console.ReadLine(), Console.ReadLine(), Console.ReadLine());
            Console.WriteLine($"{postResult}");

            //Get info
            var getResult = infoClient.GetInfo();
            foreach (var item in getResult)
            {
                Console.WriteLine($"{item}");
            }

            Console.WriteLine("\nPress <Enter> to terminate the client.");
            Console.ReadLine();
            authClient.Close();
            infoClient.Close();
            splitClient.Close();
        }
    }
}
