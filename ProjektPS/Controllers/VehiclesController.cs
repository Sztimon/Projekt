using AutoMapper;
using DataModels.Models;
using DataModels.Presistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjektPS.Controllers.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektPS.Controllers
{
    [Route("/api/vehicles")]
    public class VehiclesController : Controller
    {
        private readonly IMapper mapper;
        private readonly ProjektPSDbContext context;

        public VehiclesController(IMapper mapper, ProjektPSDbContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody] VehicleResource vehicleResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var model = await context.Models.FindAsync(vehicleResource.CarModelId);
            if (model == null)
            {
                ModelState.AddModelError("ModelId", "Invalid model id");
                return BadRequest(ModelState);
            }
            
            var vehicle = mapper.Map<VehicleResource, Vehicle>(vehicleResource);
            vehicle.LastUpdate = DateTime.Now;

            context.Vehicles.Add(vehicle);
            await context.SaveChangesAsync();

            var result = mapper.Map<Vehicle, VehicleResource>(vehicle);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle(int id, [FromBody] VehicleResource vehicleResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var vehicle = await context.Vehicles.Include(v => v.Features).SingleOrDefaultAsync(v => v.Id == id);

            if (vehicle == null)
                return NotFound();

            mapper.Map<VehicleResource, Vehicle>(vehicleResource, vehicle);
            vehicle.LastUpdate = DateTime.Now;

            await context.SaveChangesAsync();

            var result = mapper.Map<Vehicle, VehicleResource>(vehicle);
            return Ok(result);
        }

        [HttpPut("{id}/counter")]
        public async Task<IActionResult> UpdateCounter(int id)
        {
            var vehicle = await context.Vehicles.Include(v => v.Features).SingleOrDefaultAsync(v => v.Id == id);

            if (vehicle == null)
                return NotFound();

            vehicle.Counter = vehicle.Counter + 1;

            await context.SaveChangesAsync();

            return Ok(vehicle.Counter);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id, [FromBody] VehicleResource vehicleResource)
        {
            var vehicle = await context.Vehicles.FindAsync(id);

            if (vehicle == null)
                return NotFound();

            context.Remove(vehicle);
            await context.SaveChangesAsync();

            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle(int id)
        {
            var vehicle = await context.Vehicles.Include(v => v.Features).SingleOrDefaultAsync(v => v.Id == id);

            if (vehicle == null)
                return NotFound();

            var vehicleResource = mapper.Map<Vehicle, VehicleResource>(vehicle);

            return Ok(vehicleResource);
        }

        [HttpGet]
        public async Task<IEnumerable<VehicleShow>> GetVehicles()
        {
            var vehicles = await context.Vehicles
                .Include(p => p.CarModel)
                .Include(p => p.Features)
                    .ThenInclude(o => o.Feature)
                .ToListAsync();

                var results = vehicles.Select(x => new Vehicle
                {
                    Id = x.Id,
                    CarModel = x.CarModel,
                    IsRegistered = x.IsRegistered,
                    ContactName = x.ContactName,
                    ContactPhone = x.ContactPhone,
                    ContactEmail = x.ContactEmail,
                    Features = x.Features,
                    Image = x.Image,
                    Description = x.Description,
                    LastUpdate = x.LastUpdate,   
                    Counter = x.Counter,
                });
            var a = results.ToList();
            var list = new List<VehicleShow>();
            foreach (var b in a)
            {
                var result = mapper.Map<Vehicle, VehicleShow>(b);
                list.Add(result);
            }
           
            return list;
        }

        [HttpPut("location/{location}")]
        public async Task<IActionResult> Location(string location)
        {
            var currentLocation = await context.Locations.SingleOrDefaultAsync(l => l.Name == location);

            if (currentLocation == null)
            {
                currentLocation = new Location()
                {
                    Name = location,
                    Counter = 1
                };
                context.Locations.Add(currentLocation);
            }
            else {
                currentLocation.Counter = currentLocation.Counter + 1;
            }
            await context.SaveChangesAsync();

            return Ok(currentLocation);
        }

        [HttpGet ("locations")]
        public async Task<IEnumerable<Location>> GetLocations()
        {
            var locations = await context.Locations.ToListAsync();

            return locations;
        }
    }
}