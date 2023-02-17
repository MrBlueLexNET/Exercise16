using Exercise16.Client.Services;
using Exercise16.Shared.Entities;
using System.Reflection.Metadata.Ecma335;

namespace Exercise16.Client.Models
{
    public class MockDataService : IMockDataService
    {
        private static List<Device>? devices = default!;
        private static List<Location> locations = default!;
        private readonly HttpClient httpClient;

        public static List<Device>? Devices
        {
            get
            {
                //we will use these in initialization of Devices
                locations ??= InitializeMockLocations();
                devices ??= InitializeMockDevices();

                return devices;
            }
        }

        public MockDataService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Device>> GetAsync()
        {

            return new List<Device>();
        }

        private static List<Device> InitializeMockDevices()
        {
            //throw new NotImplementedException();
            return new List<Device>()
            {
                new Device{DeviceId = "4dacb4ebe7404bc38819a2aea0bccc0c", Name = "IRB 760", LocationId = 1, Online = true },
                new Device{DeviceId = "5dacb4ebe7404bc38819a2aea0bccc0c", Name = "IRB 1010", LocationId = 1, Online = false },
                new Device{DeviceId = "6dacb4ebe7404bc38819a2aea0bccc0c",Name = "IRB 1010", LocationId = 2, Online = true },
                new Device{DeviceId = "7dacb4ebe7404bc38819a2aea0bccc0c",Name = "IRB 8700", LocationId = 2, Online = false },
                new Device{DeviceId = "8dacb4ebe7404bc38819a2aea0bccc0c",Name = "IRB 1010", LocationId = 3, Online = true },
                new Device{DeviceId = "9dacb4ebe7404bc38819a2aea0bccc0c",Name = "IRB 8700", LocationId = 4, Online = true }
            };
        }

        private static List<Location> InitializeMockLocations()
        {
            return new List<Location>()
            {
                new Location{LocationId = 1, Address = "Brown-Boveri-Strasse 5" , PostalCode = "8050", CityTown = "Zürich" , Country ="Schweiz"},
                new Location{LocationId = 2, Address = "Kopparbergsvägen 2" , PostalCode = "722 13", CityTown = "Västerås" , Country ="Sweden"},
                new Location{LocationId = 3, Address = "7 Bd d'Osny" , PostalCode = "95800", CityTown = "Cergy" , Country ="France"},
                new Location{LocationId = 4, Address = "1909 Oxford St E" , PostalCode = "ON N5V 4L9", CityTown = "London" , Country ="Canada"}
            };
        }

        public Task<Device> GetAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
