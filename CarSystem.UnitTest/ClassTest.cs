using CarSystem.Models;

namespace CarSystem.UnitTest
{
    public class ClassTest
    {
        [Fact]
        public void CarTest()
        {
            // Assign/Arrange
            List<Car> cars = new();
            Car expected = new ("BE3422", CarType.Almindelig);
            var car = new Car(expected.LicensePlate, expected.Type);
            cars.Add(new Car(car.LicensePlate, car.Type));

            List<AlmindeligSpot> almindelig = new();
            AlmindeligSpot almindeligSpot = new("P", 150, car);
            almindelig.Add(new AlmindeligSpot(almindeligSpot.Name, 150, almindeligSpot.CurrentVehicle));

            // Act
            string actual = expected.LicensePlate;
            var actual2 = almindeligSpot;

            // Assert
            Assert.Equal(expected.LicensePlate, actual);
            Assert.Equal(almindeligSpot, actual2);
        }
    }
}