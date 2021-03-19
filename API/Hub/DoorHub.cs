
using System.Threading.Tasks;

using API.Models;

using Microsoft.AspNetCore.SignalR;

namespace API.Hub
{
    public class DoorHub : Microsoft.AspNetCore.SignalR.Hub
    {
        public async Task SendAddDoor(Door value) => await Clients.All.SendAsync("AddMessageReceived", value);

        public async Task SendDeleteDoor(Door value) => await Clients.All.SendAsync("DeleteMessageReceived", value);

        public async Task SendEditDoor(Door value) => await Clients.All.SendAsync("EditMessageReceived", value);
    }
}
