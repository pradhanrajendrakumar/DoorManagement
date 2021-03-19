using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace API.Models
{
    public class SeedContext
    {
        public static async Task SeedAsync(DoorManagementDbContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!await context.Doors.AnyAsync())
                {
                    await context.Doors.AddRangeAsync(new List<Door>()
                    {
                        new Door(){Id=Guid.NewGuid(),Label = "Maintenance facilities",IsOpen = false,IsLocked = false},
                        new Door(){Id=Guid.NewGuid(),Label = "Warehouse Door",IsOpen = false,IsLocked = true},
                        new Door(){Id = Guid.NewGuid(),Label = "Corridors",IsOpen = true,IsLocked = false},
                        new Door(){Id = Guid.NewGuid(),Label = "Terrace Door",IsOpen = true,IsLocked = false},
                        new Door(){Id = Guid.NewGuid(),Label = "Washing Area",IsOpen = true,IsLocked = false},
                        new Door(){Id = Guid.NewGuid(),Label = "Emergency Door",IsOpen = true,IsLocked = false}
                    });

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception exception)
            {
                var log = loggerFactory.CreateLogger<SeedContext>();
                log.LogError(exception.Message);
                throw;
            }
        }
    }
}
