﻿using MyMountainAscents.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMountainAscents.UI.Services
{
    public interface IDataService
    {
        public Task<List<Mountain>> GetAllMountains();
        public Task<Mountain> AddMountain(Mountain mountain);
    }
}
