using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System;
using Xunit;
using Domain.Models;
using Moq;
using Domain.Services;
using Domain.Interfaces;
using FluentAssertions;
using Domain.Factories;
using Domain.Values;

namespace Domain.Tests.Services
{
    public class VehicleServiceTests
    {
        private Mock<IVehicleRepository> mockRepo;

        public VehicleServiceTests()
        {
            this.mockRepo = new Mock<IVehicleRepository>();

            mockRepo.Setup(repo => repo.Get(VehicleFactory.CreateChassisId("car_series", 4))).ReturnsAsync(CreateFixture("CAR"));
            mockRepo.Setup(repo => repo.Get(VehicleFactory.CreateChassisId("bus_series", 42))).ReturnsAsync(CreateFixture("BUS"));
            mockRepo.Setup(repo => repo.Get(VehicleFactory.CreateChassisId("truck_series", 1))).ReturnsAsync(CreateFixture("TRUCK"));
            mockRepo.Setup(repo => repo.List()).Returns(new List<Vehicle> {
                    CreateFixture("TRUCK"),
                    CreateFixture("CAR"),
                    CreateFixture("BUS")
                });
        }

        public static Vehicle CreateFixture(string type)
        {
            switch (type)
            {
                case "NEW_CAR":
                    return VehicleFactory.CreateVehicle(
                        VehicleFactory.CreateChassisId("new_car_series", 4),
                        VehicleTypes.CAR,
                        "RED"
                    );
                case "NEW_TRUCK":
                    return VehicleFactory.CreateVehicle(
                        VehicleFactory.CreateChassisId("new_truck_series", 1),
                        VehicleTypes.TRUCK,
                        "BLUE"
                    );
                case "NEW_BUS":
                    return VehicleFactory.CreateVehicle(
                        VehicleFactory.CreateChassisId("new_bus_series", 42),
                        VehicleTypes.BUS,
                        "GREEN"
                    );
                case "CAR":
                    return VehicleFactory.CreateVehicle(
                        VehicleFactory.CreateChassisId("car_series", 4),
                        VehicleTypes.CAR,
                        "RED"
                    );
                case "TRUCK":
                    return VehicleFactory.CreateVehicle(
                        VehicleFactory.CreateChassisId("truck_series", 1),
                        VehicleTypes.TRUCK,
                        "BLUE"
                    );
                case "BUS":
                    return VehicleFactory.CreateVehicle(
                        VehicleFactory.CreateChassisId("bus_series", 42),
                        VehicleTypes.BUS,
                        "GREEN"
                    );
            }

            return null;
        }

        [Theory]
        [InlineData("NEW_BUS")]
        [InlineData("NEW_CAR")]
        [InlineData("NEW_TRUCK")]
        public async void Create_Should_Create_Vehicle_When_It_Doesnt_Exist(string type)
        {
            var service = new VehicleService(mockRepo.Object);

            var fixture = CreateFixture(type);

            await service.Add(fixture);

            mockRepo.Verify(repo => repo.Create(fixture));
        }

        [Theory]
        [InlineData("BUS")]
        [InlineData("CAR")]
        [InlineData("TRUCK")]
        public async void Create_Should_Throw_When_Chassis_Already_Exists(string type)
        {
            var service = new VehicleService(mockRepo.Object);

            var fixture = CreateFixture(type);

            await Assert.ThrowsAsync<Exception>(async () => await service.Add(fixture));
        }

        [Theory]
        [InlineData("BUS")]
        [InlineData("CAR")]
        [InlineData("TRUCK")]
        public async void Get_Should_Return_Vehicle(string type)
        {
            var service = new VehicleService(mockRepo.Object);

            var fixture = CreateFixture(type);

            var result = await service.Get(fixture.ChassisId);

            fixture.Should().BeEquivalentTo(result);
        }

        [Fact]
        public async void Get_Should_Not_Return_Vehicle()
        {
            var service = new VehicleService(mockRepo.Object);

            var result = await service.Get(new ChassisId("not", 3));

            Assert.Null(result);
        }

        [Theory]
        [InlineData("BUS")]
        [InlineData("CAR")]
        [InlineData("TRUCK")]
        public async void EditColor_Should_Change_Vehicle_Color_When_Found(string type)
        {
            var service = new VehicleService(mockRepo.Object);

            var fixture = CreateFixture(type);

            await service.EditColor(fixture.ChassisId, "Mangenta");

            mockRepo.Verify(repo => repo.Update(It.IsAny<Vehicle>()));
        }

        [Fact]
        public async void EditColor_Should_Throw_When_Chassis_Not_Found()
        {
            var service = new VehicleService(mockRepo.Object);

            await Assert.ThrowsAsync<Exception>(async () => await service.EditColor(
                new ChassisId("not_found", 40),
                "Mangenta"
            ));
        }

        [Theory]
        [InlineData("BUS")]
        [InlineData("CAR")]
        [InlineData("TRUCK")]
        public async void Delete_Should_Remove_Vehicle_When_Found(string type)
        {
            var service = new VehicleService(mockRepo.Object);

            var fixture = CreateFixture(type);

            await service.Delete(fixture.ChassisId);

            mockRepo.Verify(repo => repo.Delete(It.IsAny<Vehicle>()));
        }

        [Fact]
        public async void Delete_Should_Throw_When_Chassis_Not_Found()
        {
            var service = new VehicleService(mockRepo.Object);

            await Assert.ThrowsAsync<Exception>(async () => await service.Delete(new ChassisId("not_found", 40)));
        }

        [Fact]
        public void List_Should_Return_Vehicles()
        {
            var service = new VehicleService(mockRepo.Object);

            var result = service.List();

            result.Should().HaveCount(3);
        }
    }
}