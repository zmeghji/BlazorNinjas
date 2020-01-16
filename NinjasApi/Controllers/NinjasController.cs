using ApiModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NinjasApi.DAL;
using NinjasApi.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NinjasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NinjasController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly NinjaContext _ninjaContext;

        public NinjasController(IMapper mapper, NinjaContext ninjaContext)
        {
            _mapper = mapper;
            _ninjaContext = ninjaContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _ninjaContext.Ninjas.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _ninjaContext.Ninjas.FirstOrDefaultAsync(n => n.Id == id));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, NinjaApiModel ninja)
        {
            ninja.Id = id;
            var ninjaToUpdate = await _ninjaContext.Ninjas.SingleAsync(n => n.Id == id);
            _mapper.Map(ninja, ninjaToUpdate);
            _ninjaContext.SaveChanges();
            return Ok(ninjaToUpdate);
        }

        [HttpPost]
        public async Task<IActionResult> Post(NinjaApiModel ninja)
        {
            var ninjaToCreate = _mapper.Map<Ninja>(ninja);
            ninjaToCreate.Id = Guid.NewGuid().ToString();
            _ninjaContext.Ninjas.Add(ninjaToCreate);
            await _ninjaContext.SaveChangesAsync();
            return Created(Url.Action(nameof(Get), new { Id = ninjaToCreate.Id }), ninjaToCreate);
        }
    }
}
