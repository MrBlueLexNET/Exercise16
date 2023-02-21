using Bogus;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using Exercise16.Shared.Entities;

namespace Exercise16.Api.Data
{
    public class SeedData
    {
        private static Faker faker = null!;
        public static async Task InitAsync(Exercise16ApiContext db)
        {
            if (await db.Device.AnyAsync()) return;

            faker = new Faker("sv");

            var devices = GenerateDevices(50);
            await db.AddRangeAsync(devices);


            await db.SaveChangesAsync();

        }

       

        private static IEnumerable<Device> GenerateDevices(int numberOfDevices)
        {
            var devices = new List<Device>();

            for (int i = 0; i < numberOfDevices; i++)
            {
                var fName = faker.Commerce.ProductName();

                var device = new Device
                {
                   
                    Name = fName,
                    Online = true,
                    LocationId = i,
                    Location = new Location
                    {
                        Address = faker.Address.StreetAddress(),
                        CityTown = faker.Address.City(),
                        PostalCode = faker.Address.ZipCode()
                    }
                };

                devices.Add(device);
            }

            return devices;
        }
    }
}
