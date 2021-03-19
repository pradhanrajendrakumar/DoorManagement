using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using DesktopClient.Models;

namespace DesktopClient.Services
{
    public class DoorService : IDoorService
    {
        private const string BASE_ADDRESS = "http://localhost:5000/";

        readonly HttpClient _client;
        public DoorService()
        {
            _client = new HttpClient { BaseAddress = new Uri(BASE_ADDRESS) };
        }

        public async Task<IEnumerable<DoorModel>> GetDoors()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<DoorModel>>
                (await _client.GetStreamAsync($"api/door"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task RemoveDoor(DoorModel door)
        {
            await _client.DeleteAsync($"api/door/{door.Id}");
        }

        public async Task<DoorModel> AddDoor(DoorModel door)
        {
            var content =
                new StringContent(JsonSerializer.Serialize(door), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("api/door", content);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<DoorModel>(await response.Content.ReadAsStreamAsync());
            }

            return null;
        }

        public async Task EditDoor(DoorModel door)
        {
            var content =
                new StringContent(JsonSerializer.Serialize(door), Encoding.UTF8, "application/json");

            await _client.PutAsync("api/door", content);
        }
    }
}