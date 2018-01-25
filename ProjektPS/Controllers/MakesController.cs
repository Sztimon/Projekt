using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataModels.Models;
using DataModels.Presistence;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using ProjektPS.Controllers.Resources;

namespace ProjektPS.Controllers
{
    public class MakesController : Controller
    {
        private readonly ProjektPSDbContext context;
        private readonly IMapper mapper;

        public MakesController(ProjektPSDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("/api/makes")]
        public async Task<IEnumerable<MakeResource>> GetMakes()
        {
            var makes = await context.Makes.Include(m => m.CarModels).ToListAsync();

            return mapper.Map<List<Make>, List<MakeResource>>(makes);
        }
    }
}