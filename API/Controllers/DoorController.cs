using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using API.Models;

using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoorController : ControllerBase
    {
        private readonly IDoorRepository _doorRepository;


        public DoorController(IDoorRepository doorRepository)
        {
            _doorRepository = doorRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Door>> GetDoors()
        {
            return await _doorRepository.GetDoors();
        }

        [HttpGet("{id}")]
        public async Task<Door> GetById(Guid id)
        {
            return await _doorRepository.GetDoorById(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoor(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }

            var existingDoor = await _doorRepository.GetDoorById(id);

            if (existingDoor == null)
            {
                return NotFound();
            }

            _doorRepository.RemoveDoor(id);

            return NoContent();//Success
        }

        [HttpPost]
        public async Task<IActionResult> AddDoor([FromBody] Door door)
        {
            if (door == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newDoor = await _doorRepository.AddDoor(door);
            return Created("door", newDoor);
        }

        [HttpPut]
        public async Task<IActionResult> EditDoor([FromBody] Door door)
        {
            if (door == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingDoor = await _doorRepository.GetDoorById(door.Id);
            if (existingDoor == null)
            {
                return NotFound();
            }
            var editedDoor = await _doorRepository.EditDoor(door);
            return NoContent();
        }
    }
}
