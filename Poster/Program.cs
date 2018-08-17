using Common;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Poster
{
    class Program
    {
        static async Task Main(string[] args)
        {
            const string CONNSTRING = "UseDevelopmentStorage=true";

            var account = CloudStorageAccount.Parse(CONNSTRING);

            var client = account.CreateCloudQueueClient();

            var queue = client.GetQueueReference("savetomydatas");

            for (int i = 0; i < 100; i++)
            {
                var myData = new MyData()
                {
                    Country = "US",
                    UserId = $"ABC{i:000}",
                    Email = $"dude{i:000}@comcast.com",
                    Phone = i.ToString("0000000000")
                };

                var json = JsonConvert.SerializeObject(myData);

                var message = new CloudQueueMessage(json);

                await queue.AddMessageAsync(message);

                Console.WriteLine($"Posted {myData} to queue.");
            }
        }
    }
}
