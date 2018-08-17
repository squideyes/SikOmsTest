using Microsoft.WindowsAzure.Storage.Table;

namespace SikOmsTest
{
    public class MyDataEntity : TableEntity
    {
        public MyDataEntity(string country, string userId)
        {
            PartitionKey = country;
            RowKey = userId.Replace("-", "");
        }

        public string Email { get; set; }
        public string Phone { get; set; }

        public string Country => PartitionKey;
        public string UserId => RowKey;
    }
}
