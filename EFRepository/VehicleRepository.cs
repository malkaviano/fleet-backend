using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Factories;
using Domain.Interfaces;
using Domain.Models;
using EFRepository.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFRepository
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly DataContext context;

        public VehicleRepository(DataContext context)
        {
            this.context = context;
        }

        public async Task<Vehicle> Get(ChassisId chassisId)
        {
            var result = await context.Vehicles.FindAsync(chassisId.Series, chassisId.Number);

            if (result == null) return null;

            context.Entry(result).State = EntityState.Detached;

            return VehicleFactory.CreateVehicle(chassisId, result.Type, result.Color);
        }

        public async Task Create(Vehicle model)
        {
            context.Vehicles.Add(ToEntity(model));

            await Save();
        }

        private async Task Save()
        {
            await context.SaveChangesAsync();
        }

        public async Task Update(Vehicle vehicle)
        {
            context.Vehicles.Update(ToEntity(vehicle));

            await Save();
        }

        public async Task Delete(Vehicle model)
        {
            var entity = ToEntity(model);

            context.Vehicles.Remove(entity);

            await Save();
        }

        public IEnumerable<Vehicle> List()
        {
            return context.Vehicles.AsNoTracking()
                        .ToAsyncEnumerable()
                        .Select(v => VehicleFactory.CreateVehicle(
                            VehicleFactory.CreateChassisId(v.Series, v.Number),
                            v.Type,
                            v.Color
                        )).ToEnumerable();
        }

        private VehicleEntity ToEntity(Vehicle model)
        {
            return new VehicleEntity
            {
                Color = model.Color,
                Passengers = model.Passengers,
                Number = model.ChassisId.Number,
                Series = model.ChassisId.Series,
                Type = model.Type
            };
        }
    }

}