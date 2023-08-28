using CarSystem.Models;

namespace CarSystem.UnitTest
{
    public class ClassTest
    {
        [Fact]
        public void CarTest()
        {
            // Assign/Arrange
            List<Car> cars = new List<Car>();
            Car expected = new ("BE3422", CarType.Almindelig);
            var car = new Car(expected.LicensePlate, expected.Type);
            cars.Add(new Car(car.LicensePlate, car.Type));

            // Act
            string actual = expected.LicensePlate;

            // Assert
            Assert.Equal(expected.LicensePlate, actual);
        }
    }
}