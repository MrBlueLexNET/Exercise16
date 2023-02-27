using System.Net;
using System.Text.Json;
using Azure.Data.Tables;
using Exercise16.Shared.Entities;
using Exercise17.Func.Entities;
using Exercise17.Func.Extensions;
using Exercise17.Func.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace Exercise17.Func
{
    public class HttpFunction
    {
        private readonly ILogger _logger;

        public HttpFunction(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<HttpFunction>();
        }

        [Function("Get Items")]
        public async Task<HttpResponseData> Get(
          [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "devices")] HttpRequestData req,
          [TableInput(TableNames.TableName, TableNames.PartionKey, Connection = "AzureWebJobsStorage")] IEnumerable<DeviceTableEntity> tableEntities)
        {
            _logger.LogInformation("Get all devices started!");

            var response = req.CreateResponse();
            var items = tableEntities.Select(Mapper.ToDevice);
            await response.WriteAsJsonAsync(items);
            return response;

        }

        [Function("Add Device")]
        public async Task<HttpResponseData> Create(
           [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "devices")] HttpRequestData req)
        // [TableInput("Items", "Todos", Connection = "AzureWebJobsStorage")] TableClient tableClient)
        {
            _logger.LogInformation("Create new device item");

            var tableClient = GetTableClient();
            var response = req.CreateResponse();

            //var stream = await new StreamReader(req.Body).ReadToEndAsync();
            var createdDevice = JsonSerializer.Deserialize<CreateDevice>(req.Body, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            if (createdDevice is null || string.IsNullOrWhiteSpace(createdDevice.Name))
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                return response;
            }

            var device = new Device
            {
                Name = createdDevice.Name
            };

            //ToDo try to remove later!!!
            await tableClient.CreateIfNotExistsAsync();
            await tableClient.AddEntityAsync(device.ToTableEntity());

            //response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            await response.WriteAsJsonAsync(device);
            response.StatusCode = HttpStatusCode.Created;

            return response;
        }

        [Function("Delete Device")]
        public async Task<HttpResponseData> Delete(
            [HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "devices/{id}")] HttpRequestData req,
              // [TableInput(TableNames.TableName, TableNames.PartionKey, "{id}", Connection = "AzureWebJobsStorage")] IEnumerable<ItemTableEntity> tableEntity,
              [FromRoute] string id)
        {
            _logger.LogInformation("Delete device");

            var tableClient = GetTableClient();
            var response = req.CreateResponse();

            //if(createdItem is null || string.IsNullOrWhiteSpace(createdItem.Text))
            //{
            //    response.StatusCode = HttpStatusCode.BadRequest;
            //    return response;
            //}

            var isOk = await tableClient.DeleteEntityAsync(TableNames.PartionKey, id);

            if (isOk.Status == StatusCodes.Status404NotFound)
            {
                response.StatusCode = HttpStatusCode.NotFound;
                return response;
            }

            response.StatusCode = HttpStatusCode.NoContent;
            return response;
        }

        [Function("Edit Device")]
        public async Task<HttpResponseData> Edit(
        [HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "devices/{id}")] HttpRequestData req,
        [FromRoute] string id)
        {
            _logger.LogInformation("Edit device");

            var tableClient = GetTableClient();
            var response = req.CreateResponse();

            var editDevice = await JsonSerializer.DeserializeAsync<Device>(req.Body, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            if (editDevice is null || string.IsNullOrWhiteSpace(editDevice.Name) || editDevice.DeviceId != id)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                return response;
            }

            var found = await tableClient.GetEntityIfExistsAsync<DeviceTableEntity>(TableNames.PartionKey, id);
            if (!found.HasValue)
            {
                response.StatusCode = HttpStatusCode.NotFound;
                return response;
            }

            var reponse = await tableClient.UpdateEntityAsync((DeviceTableEntity?)editDevice.ToTableEntity(), Azure.ETag.All);

            //ToDo check response!

            response.StatusCode = HttpStatusCode.NoContent;
            return response;
        }

        private TableClient GetTableClient()
        {
            var connectionString = Environment.GetEnvironmentVariable("AzureWebJobsStorage");
            return new TableClient(connectionString, TableNames.TableName);
        }


    }
}
