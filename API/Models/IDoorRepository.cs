using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Models
{
    public interface IDoorRepository
    {
        Task<IEnumerable<Door>> GetDoors();

        Task<Door> GetDoorById(Guid id);

        void RemoveDoor(Guid id);

        Task<Door> AddDoor(Door door);

        Task<Door> EditDoor(Door door);
    }
}