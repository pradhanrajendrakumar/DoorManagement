using System.Collections.Generic;
using System.Threading.Tasks;

using DesktopClient.Models;

namespace DesktopClient.Services
{
    public interface IDoorService
    {
        Task<IEnumerable<DoorModel>> GetDoors();

        Task RemoveDoor(DoorModel door);

        Task<DoorModel> AddDoor(DoorModel door);

        Task EditDoor(DoorModel door);
    }
}