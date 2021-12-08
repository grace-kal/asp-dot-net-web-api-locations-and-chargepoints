﻿using LACP.Models;
using LACP.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocationAndChargePoint.App.Services.Interfaces
{
    public interface ILocationService
    {
        //post location
        //the model LocationRequest is mapped to Location in the controller
        Task CreateLocation(LocationRequest model);
        //patch location
        //the model PatchLocationRequest is mapped to Location in the controller
        Task EditLocation(PatchLocationRequest model);
        //put charge points in the location
        Task InsertChargePoints(ChargePointRequestViewModel model);
        //get location
        Task<Location> GetLocation(string id);
    }
}
