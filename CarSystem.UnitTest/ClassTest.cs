using CarSystem.BLL;
using CarSystem.Controllers;
using CarSystem.Data;
using CarSystem.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Cryptography.X509Certificates;

namespace CarSystem.UnitTest
{
    public class ClassTest
    {
        [Fact]
        public void CarTest()
        {
            // Assign/Arrange
            int _idCounter = 1;

            List<Car> cars = new();
            Car expected = new("P" + _idCounter++, "BE3422", CarType.Almindelig);
            var car = new Car(expected.Name, expected.LicensePlate, expected.Type);
            cars.Add(new Car(car.Name, car.LicensePlate, car.Type));

            List<AlmindeligSpot> almindelig = new();
            List<HandicapSpot> handicap = new();
            List<BusSpot> bus = new();
            List<OtherSpot> other = new();
            List<StartWash> carWashes = new();
            AlmindeligSpot almindeligSpot = new("P", 150, car);
            HandicapSpot handicapSpot = new("P", 150, car);
            BusSpot busSpot = new("P", 150, car);
            OtherSpot otherSpot = new("P", 150, car);
            StartWash carWash = new("P", 150, car);

            almindelig.Add(new AlmindeligSpot(almindeligSpot.Name, 150, almindeligSpot.CurrentVehicle) { Id = _idCounter++, IsOccupied = true});
            handicap.Add(new HandicapSpot(handicapSpot.Name, 150, handicapSpot.CurrentVehicle) { Id = _idCounter++, IsOccupied = true });
            bus.Add(new BusSpot(busSpot.Name, 150, busSpot.CurrentVehicle) { Id = _idCounter++, IsOccupied = true });
            other.Add(new OtherSpot(otherSpot.Name, 150, otherSpot.CurrentVehicle) { Id = _idCounter++, IsOccupied = true });
            carWashes.Add(new StartWash(carWash.Name, 150, carWash.CurrentVehicle) { Id = _idCounter++, Status = WashStatus.Vasker });

            // Act
            string actual = expected.LicensePlate;
            var actual2 = almindeligSpot;
            var actual3 = handicapSpot;
            var actual4 = busSpot;
            var actual5 = otherSpot;
            var actual6 = carWash;


            // Assert
            Assert.Equal(expected.LicensePlate, actual);
            Assert.Equal(almindeligSpot, actual2);
            Assert.Equal(handicapSpot, actual3);
            Assert.Equal(busSpot, actual4);
            Assert.Equal(otherSpot, actual5);
            Assert.Equal(carWash, actual6);
        }
    }
}