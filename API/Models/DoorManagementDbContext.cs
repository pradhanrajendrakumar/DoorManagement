
using System;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

namespace API.Models
{
    public class DoorManagementDbContext : DbContext
    {
        public DoorManagementDbContext(DbContextOptions<DoorManagementDbContext> options) : base(options)
        {
        }

        public DbSet<Door> Doors { get; set; }

        #region Overrides of DbContext
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Door>().HasData(new List<Door>()
            {
                new Door(){Id=Guid.NewGuid(),Label = "Maintenance facilities",IsOpen = false,IsLocked = false},
                new Door(){Id=Guid.NewGuid(),Label = "Warehouse Door",IsOpen = false,IsLocked = true},
                new Door(){Id = Guid.NewGuid(),Label = "Corridors",IsOpen = true,IsLocked = false},
                new Door(){Id = Guid.NewGuid(),Label = "Terrace Door",IsOpen = true,IsLocked = false},
                new Door(){Id = Guid.NewGuid(),Label = "Washing Area",IsOpen = true,IsLocked = false},
                new Door(){Id = Guid.NewGuid(),Label = "Emergency Door",IsOpen = true,IsLocked = false}
            });
        }

        #endregion
    }
}
