using MyMountainAscents.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMountainAscents.Data.Services
{
    public interface IDataService
    {
        public Task<List<Mountain>> GetAllMountains();
        public Task<Mountain> AddMountain(Mountain mountain);
        public Task<Mountain> GetMountainByGuid(Guid guid);
        public Task<Ascent> AddAscent(Ascent ascent, Guid mountainGuid);
        public Task<Ascent> DeleteAscent(Guid ascentGuid);
        public Task<Mountain> DeleteMountain(Guid mountainGuid);
    }
}
