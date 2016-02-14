using System;
using System.Linq;
using System.Threading.Tasks;
using RealServiceClientApi;

namespace DemoClient
{
    class Program
    {
        const string realWorldEndpoint = "DefaultBinding_RealWorld";

        static void Main(string[] args)
        {
            var list = new int[100];
            for (int i=0;i<100;i++)
            {
                list[i] = i;
            }


            var tasks  = list.Select(d =>
            {
                return GetHardData(d);
            });

            Task.WaitAll(tasks.ToArray());

            Console.WriteLine("All done.");

            Console.ReadLine();
        }

        static Task<string> GetHardData(int d)
        {
                RealWorldProxy client = new RealWorldProxy(realWorldEndpoint);

            try
            {
                client.Instance.ClientCredentials.UserName.UserName = "test";
                client.Instance.ClientCredentials.UserName.Password = "tttttttt";
                return client.Instance.GetHardDataAsync(d);

            }
            finally
            {
                client.Dispose();
            }          

        }
    }
}
