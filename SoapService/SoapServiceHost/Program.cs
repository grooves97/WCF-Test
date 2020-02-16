using SoapService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace SoapServiceHost
{
    class Program
    {
        static void Main()
        {
            Uri baseAddress = new Uri("http://localhost:8000/SoapService/Service1/");

            ServiceHost selfHost = new ServiceHost(typeof(ProfileService), baseAddress);

            try
            {
                selfHost.AddServiceEndpoint(typeof(ISplit), new WSHttpBinding(), "ProfileService");
                selfHost.AddServiceEndpoint(typeof(IInfo), new WSHttpBinding(), "ProfileService");
                selfHost.AddServiceEndpoint(typeof(IAuth), new WSHttpBinding(), "ProfileService");

                ServiceMetadataBehavior smb = new ServiceMetadataBehavior
                {
                    HttpGetEnabled = true
                };
                selfHost.Description.Behaviors.Add(smb);

                selfHost.Open();
                Console.WriteLine("The service is ready.");

                Console.WriteLine("Press <Enter> to terminate the service.");
                Console.WriteLine();
                Console.ReadLine();
                selfHost.Close();
            }
            catch (CommunicationException ce)
            {
                Console.WriteLine("An exception occurred: {0}", ce.Message);
                selfHost.Abort();
            }
        }
    }
}
