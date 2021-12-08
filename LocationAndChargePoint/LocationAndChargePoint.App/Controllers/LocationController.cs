using AutoMapper;
using LACP.Models;
using LACP.Models.ViewModels;
using LocationAndChargePoint.App.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocationAndChargePoint.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _service;
        private readonly IMapper _mapper;
        public LocationController(ILocationService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetLocation(string id)
        {
            try
            {
                Location loc = await _service.GetLocation(id);
                LocationViewModel locVM = _mapper.Map<LocationViewModel>(loc);
                locVM.ChargePoints.AddRange(_mapper.Map<List<ChargePointViewModel>>(loc.ChargePoints).ToList());
                return Ok(locVM);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
        [HttpPost]
        public async Task<IActionResult> PostLocation(LocationRequest model)
        {
            try
            {
                await _service.CreateLocation(model);
                return Ok(model);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        [HttpPatch]
        [Route("{id}")]
        public async Task<IActionResult> PatchLocation(string id, PatchLocationRequest model)
        {
            try
            {
                if (id == model.LocationId)
                {
                    await _service.EditLocation(model);
                    return Ok();
                }
                else
                    return BadRequest();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> PutChargePoints(string id, ChargePointRequestViewModel model)
        {
            try
            {
                if (id == model.LocationId)
                {
                    await _service.InsertChargePoints(model);
                    return Ok();
                }
                else
                    return BadRequest();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
