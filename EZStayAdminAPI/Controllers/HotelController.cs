using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using EZStayAdminAPI.Infrastructure;
using EZStayAdminAPI.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EZStayAdminAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private HotelDbContext db;

        public HotelController(HotelDbContext dbContext)
        {
            this.db = dbContext;
        }

        //GET /api/hotels
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [AllowAnonymous]
        public ActionResult<IEnumerable<HotelInfo>> GetHotels()
        {
            return db.Hotels.Include(i=>i.Rooms).ThenInclude(t=>t.Amenities).ToList();
        }

        //GET /api/hotels/Pune
        [HttpGet("{city}", Name = "GetHotelByCity")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [AllowAnonymous]
        public ActionResult<HotelInfo> GetHotelsByCity(string city)
        {
            var item = db.Hotels.Find(city);
            if (item != null)
                return Ok(item);
            else
                return NotFound();
        }

        //POST /api/hotels
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<HotelInfo>> AddHotelAsync(HotelInfo model)
        {
            TryValidateModel(model);
            if (ModelState.IsValid)
            {
                var result = await db.Hotels.AddAsync(model);
                await db.SaveChangesAsync();
                
                return CreatedAtRoute("GetHotelBycity", new { city = result.Entity.City }, result.Entity);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }


    }
}