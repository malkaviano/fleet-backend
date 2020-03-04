using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IVehicleService
    {
        Task<Vehicle> Get(ChassisId chassisId);
        IEnumerable<Vehicle> List();
        Task Add(Vehicle vehicle);
        Task EditColor(ChassisId chassisId, string color);
        Task Delete(ChassisId chassisId);
    }
}