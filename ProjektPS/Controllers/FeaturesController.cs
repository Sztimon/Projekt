using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataModels.Presistence;
using AutoMapper;
using ProjektPS.Controllers.Resources;
using DataModels.Models;

namespace ProjektPS.Controllers
{
    public class FeaturesController : Controller
    {
        private readonly ProjektPSDbContext context;
        private readonly IMapper mapper;

        public FeaturesController(ProjektPSDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("/api/features")]
        public IEnumerable<FeatureResource> GetFeatures()
        {
            var features = context.Features.ToList();

            return mapper.Map<List<Feature>, List<FeatureResource>>(features);
        }
    }
}