using MarsRovers;

namespace MarsRoverTest
{
    public class Tests
    {
        [Test]
        public void MarsRover_MoveSouth_ShouldUpdatePosition()
        {
            // Arrange
            var rover = new MarsRover();

            //Act
            rover.Move(50);

            //Assert
            Assert.That(rover.direction, Is.EqualTo("South"));
            Assert.That(rover.y, Is.EqualTo(50));
        }

        [Test]
        public void MarsRover_MoveNorth_ShouldUpdatePosition()
        {
            // Arrange
            var rover = new MarsRover();

            //Act
            rover.TurnLeft();
            rover.TurnLeft();
            rover.Move(30);

            //Assert
            Assert.That(rover.direction, Is.EqualTo("North"));
            Assert.That(rover.y, Is.EqualTo(1));
        }


        [Test]
        public void MarsRover_MoveEast_ShouldUpdatePosition()
        {
            // Arrange
            var rover = new MarsRover();

            //Act
            rover.TurnLeft();
            rover.Move(20);

            //Assert
            Assert.That(rover.direction, Is.EqualTo("East"));
            Assert.That(rover.x, Is.EqualTo(20));
        }


        [Test]
        public void MarsRover_MoveWest_ShouldUpdatePosition()
        {
            // Arrange
            var rover = new MarsRover();

            //Act
            rover.TurnRight();
            rover.Move(20);

            //Assert
            Assert.That(rover.direction, Is.EqualTo("West"));
            Assert.That(rover.x, Is.EqualTo(1));
        }

        [Test]
        public void MarsRover_TurnLeft_ShouldChangeDirection()
        {
            // Arrange
            var rover = new MarsRover();

            //Act
            rover.TurnLeft();

            //Assert
            Assert.That(rover.direction, Is.EqualTo("East"));
        }


        [Test]
        public void MarsRover_TurnRight_ShouldChangeDirection()
        {
            // Arrange
            var rover = new MarsRover();

            //Act
            rover.TurnRight();

            //Assert
            Assert.That(rover.direction, Is.EqualTo("West"));
        }

        [Test]
        public void MoveBeyondBoundary_ShouldStayAtBoundary()
        {
            // Arrange
            var rover = new MarsRover();

            //Act
            rover.TurnRight();
            rover.Move(20);

            //Assert
            Assert.That(rover.y, Is.EqualTo(0));
        }
    }
}