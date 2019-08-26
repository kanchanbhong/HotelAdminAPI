using EZStayAdminAPI.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZStayAdminAPI.Infrastructure
{
    public class HotelDbContext :DbContext
    {

        public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options)
        { }

        public DbSet<HotelInfo> Hotels { get; set; }
        public DbSet<RoomInfo> Rooms { get; set; }
        public DbSet<AmenitiesInfo> Amenities { get; set; }

    }
}
