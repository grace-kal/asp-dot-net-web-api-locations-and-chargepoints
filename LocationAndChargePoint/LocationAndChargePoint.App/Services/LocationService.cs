using AutoMapper;
using LACP.Data;
using LACP.Models;
using LACP.Models.ViewModels;
using LocationAndChargePoint.App.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocationAndChargePoint.App.Services
{
    public class LocationService : ILocationService
    {
        private readonly LacpDbContext _context;
        private readonly IMapper _mapper;
        public LocationService(LacpDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task CreateLocation(LocationRequest model)
        {
            if (!model.Equals(null))
            {
                Location loc = _mapper.Map<Location>(model);
                await _context.Locations.AddAsync(loc);
                await _context.SaveChangesAsync();
            }
        }

        public async Task EditLocation(PatchLocationRequest model)
        {
            if (!model.Equals(null))
            {
                if (await LocationExists(model.LocationId))
                {
                    //update only existing val
                    var loc = _mapper.Map<Location>(model);
                    _context.Attach(loc);
                    _context.Locations.Update(loc);
                    await _context.SaveChangesAsync();
                }

            }
        }

        public async Task<bool> LocationExists(string id)
        {
            return await _context.Locations.AnyAsync(l => l.LocationId == id);
        }

        public async Task<Location> GetLocation(string id)
        {
            return await _context.Locations.FirstOrDefaultAsync(l => l.LocationId == id);
        }

        public async Task InsertChargePoints(ChargePointRequestViewModel model)
        {
            List<ChargePoint> cpsInLocation = await ChargePointsInLocation(model.LocationId);
            ChargePointRequest cpsGiven = _mapper.Map<ChargePointRequest>(model);
            
            foreach (ChargePoint cp in cpsInLocation)
            {
                if (!cpsGiven.ChargePoints.Contains(cp))
                {
                    cp.Status = "Removed";
                    cp.LastUpdated = DateTime.Now;
                    _context.ChargePoints.Update(cp);
                    await _context.SaveChangesAsync();
                }
            }
            foreach (ChargePoint cp in cpsGiven.ChargePoints)
            {
                cp.LocationId = cpsGiven.LocationId;
                await _context.ChargePoints.AddAsync(cp);
                await _context.SaveChangesAsync();
            }
            //foreach (ChargePointViewModel cpvm in model.ChargePoints)
            //{
            //    ChargePoint newCp = _mapper.Map<ChargePoint>(cpvm);
            //    newCp.LocationId = model.LocationId;
            //    await _context.ChargePoints.AddAsync(newCp);
            //    await _context.SaveChangesAsync();
            //}
        }
        public async Task<List<ChargePoint>> ChargePointsInLocation(string id)//id of location
        {
            List<ChargePoint> cpsInLocation = await _context.ChargePoints.Where(cp => cp.LocationId == id).ToListAsync();
            return cpsInLocation;
            
        }
    }
}
