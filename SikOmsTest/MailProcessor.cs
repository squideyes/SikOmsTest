using Common;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;

namespace SikOmsTest
{
    public static class MailProcessor
    {
        [FunctionName("MailProcessor")]
        public static void Run([QueueTrigger("savetomydatas")]MyData myData,
            string country, string userId,
            [Table("MyData", "{country}", "{userId}")]out MyDataEntity entity, ILogger log)
        {
            // validate MyData and then log if error and maybe post an error message

            // Just for testing
            if (DateTime.UtcNow.Ticks % 10 == 0)
                throw new Exception("ooops!");

            entity = new MyDataEntity(country, userId)
            {
                Email = myData.Email,
                Phone = myData.Phone
            };

            log.LogInformation($"Added {country}/{userId} to MyData table.");
        }

        [FunctionName("HandlePoison")]
        public static void HandlePoison([QueueTrigger("savetomydatas-poison")]MyData myData,
            string country, string userId, ILogger log)
        {
            log.LogInformation($"The {myData} record could not be processed.");

            // do something else like send out an alert, etc.
        }
    }
}
