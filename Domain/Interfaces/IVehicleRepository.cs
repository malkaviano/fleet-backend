using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IVehicleRepository
    {
        Task<Vehicle> Get(ChassisId chassisId);
        Task Create(Vehicle entity);
        Task Update(Vehicle entity);
        Task Delete(Vehicle entity);
        IEnumerable<Vehicle> List();
    }
}