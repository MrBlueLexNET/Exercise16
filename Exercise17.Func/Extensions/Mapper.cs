using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exercise16.Shared.Entities;
using Exercise17.Func.Entities;

namespace Exercise17.Func.Extensions
{
    public static class Mapper
    {
        public static DeviceTableEntity ToTableEntity(this Device device)
        {
            return new DeviceTableEntity
            {
                Online = device.Online,
                Name = device.Name,
                RowKey = device.DeviceId
            };
        }

        public static Device ToDevice(this DeviceTableEntity deviceTable)
        {
            return new Device
            {
                DeviceId = deviceTable.RowKey,
                Name = deviceTable.Name,
                Online = deviceTable.Online
            };
        }
    }
}
