﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_Test.Model;
using WebAPI_Test.Queries;

namespace WebAPI_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        private readonly IoxDbContext _context;
        public VehicleController(IoxDbContext context) => _context = context;

        [HttpGet]
        public IActionResult Get() {
            IList<Vehicle> vehicles = _context.Vehicles.ToList();
            return Ok(vehicles);
        }

        [HttpGet("{vehicleId}")]
        public async Task<IActionResult> GetVehicleList(int vehicleID)
        {
            var query = new GetVehicleListQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
