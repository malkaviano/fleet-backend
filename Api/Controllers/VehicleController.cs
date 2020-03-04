using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Api.Dtos;
using Domain.Interfaces;
using Domain.Models;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Api.Helpers;
using Domain.Factories;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService service;
        private readonly IMapper mapper;
        private readonly ILogger logger;

        public VehicleController(
            IVehicleService service,
            IMapper mapper,
            ILogger<VehicleController> logger
        )
        {
            this.service = service;
            this.mapper = mapper;
            this.logger = logger;
        }

        [HttpGet("{series}/{number}")]
        public async Task<IActionResult> Get([FromRoute] ChassisIdDto dto)
        {
            try
            {
                var chassisId = mapper.Map<ChassisId>(dto);

                var result = await service.Get(chassisId);

                if (result == null)
                {
                    return new NotFoundResult();
                }

                return new OkObjectResult(result);
            }
            catch (System.Exception ex)
            {
                LogHelper.Error(logger, ex);

                return StatusCode(500, ex.Message);
            }

        }

        [HttpGet]
        public IActionResult List()
        {
            try
            {
                var result = service.List();

                return new OkObjectResult(result);
            }
            catch (System.Exception ex)
            {
                LogHelper.Error(logger, ex);

                return StatusCode(500, ex.Message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] VehiclePost dto)
        {
            var vehicle = VehicleFactory.CreateVehicle(
                VehicleFactory.CreateChassisId(dto.Series, dto.Number),
                dto.Type,
                dto.Color
            );

            try
            {
                await service.Add(vehicle);

                return StatusCode(201);
            }
            catch (System.Exception ex)
            {
                LogHelper.Error(logger, ex);

                return new BadRequestObjectResult(ex.Message);
            }

        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] VehicleEdit dto)
        {
            try
            {
                await service.EditColor(
                    VehicleFactory.CreateChassisId(dto.Series, dto.Number),
                    dto.Color
                );

                return StatusCode(200);
            }
            catch (System.Exception ex)
            {
                LogHelper.Error(logger, ex);

                return new BadRequestObjectResult(ex.Message);
            }
        }

        [HttpDelete("{series}/{number}")]
        public async Task<IActionResult> Delete([FromRoute] ChassisIdDto dto)
        {
            try
            {
                var chassisId = mapper.Map<ChassisId>(dto);

                await service.Delete(chassisId);

                return StatusCode(200);
            }
            catch (System.Exception ex)
            {
                LogHelper.Error(logger, ex);

                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}