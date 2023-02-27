using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure;
using Azure.Data.Tables;
using Exercise17.Func.Helpers;

namespace Exercise17.Func.Entities
{
    public class DeviceTableEntity : BaseTableEntity
    {
        public string Name { get; set; } = string.Empty;
        public bool Online { get; set; }
    }

    public class BaseTableEntity : ITableEntity
    {
        public string PartitionKey { get; set; } = TableNames.PartionKey;
        public string RowKey { get; set; } = string.Empty;
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }
    }
}
