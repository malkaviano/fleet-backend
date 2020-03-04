using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Models;

namespace Domain.Services
{
    public class VehicleService : IVehicleService
    {
        private IVehicleRepository repository;

        public VehicleService(IVehicleRepository repository)
        {
            this.repository = repository;
        }

        public async Task Add(Vehicle vehicle)
        {
            var exist = await Get(vehicle.ChassisId);

            if (exist != null)
            {
                throw new Exception("Chassis id already in use");
            }

            await repository.Create(vehicle);
        }

        public async Task Delete(ChassisId chassisId)
        {
            var exist = await Get(chassisId);

            if (exist == null)
            {
                throw new Exception("Chassis id not found");
            }

            await repository.Delete(exist);
        }

        public async Task EditColor(ChassisId chassisId, string color)
        {
            var exist = await Get(chassisId);

            if (exist == null)
            {
                throw new Exception("Chassis id not found");
            }

            exist.Color = color;

            await repository.Update(exist);
        }

        public async Task<Vehicle> Get(ChassisId chassisId)
        {
            return await repository.Get(chassisId);
        }

        public IEnumerable<Vehicle> List()
        {
            return repository.List();
        }
    }
}