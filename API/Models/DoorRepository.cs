using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace API.Models
{
    public class DoorRepository : IDoorRepository
    {
        private readonly DoorManagementDbContext _context;

        public DoorRepository(DoorManagementDbContext context)
        {
            _context = context;
        }
        public async Task<Door> AddDoor(Door door)
        {
            var newEntity = await _context.Doors.AddAsync(door);
            await _context.SaveChangesAsync();
            return newEntity.Entity;
        }

        public async Task<Door> EditDoor(Door door)
        {
            var existingDoor = _context.Doors.FirstOrDefault(x => x.Id == door.Id);
            if (existingDoor != null)
            {
                existingDoor.Label = door.Label;
                existingDoor.IsLocked = door.IsLocked;
                existingDoor.IsOpen = door.IsOpen;
                await _context.SaveChangesAsync();
                return existingDoor;
            }

            return null;
        }

        public async Task<Door> GetDoorById(Guid id)
        {
            return await _context.Doors.FindAsync(id);
        }

        public async Task<IEnumerable<Door>> GetDoors()
        {
            return await _context.Doors.ToListAsync();
        }

        public void RemoveDoor(Guid id)
        {
            var existingDoor = _context.Doors.FirstOrDefault(x => x.Id == id);
            if (existingDoor == null)
            {
                return;
            }

            _context.Doors.Remove(existingDoor);
            _context.SaveChanges();
        }
    }
}