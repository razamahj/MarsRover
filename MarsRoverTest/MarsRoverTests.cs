using MarsRovers;
using MarsRovers.Interfaces;
using Moq;
using System.Runtime.CompilerServices;

namespace MarsRoverTest
{
    public class Tests
    {
        [Test]
        public void MarsRover_MoveSouth_ShouldUpdatePosition()
        {
            // Arrange
            var movementMock = new Mock<IMovement>();
            var turnMock = new Mock<ITurn>();
            var positionReporterMock = new Mock<IPositionReporter>();

            var rover = new MarsRover(movementMock.Object, turnMock.Object, positionReporterMock.Object);

            //Act
            rover.Move(50);

            //Assert
            movementMock.Verify(m => m.Move(ref It.Ref<int>.IsAny, ref It.Ref<int>.IsAny, It.IsAny<string>(), It.IsAny<int>()), Times.Once);
            positionReporterMock.Verify(p => p.ReportPosition(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void MarsRover_MoveNorth_ShouldUpdatePosition()
        {
            // Arrange
            var movementMock = new Mock<IMovement>();
            var turnMock = new Mock<ITurn>();
            var positionReporterMock = new Mock<IPositionReporter>();

            var rover = new MarsRover(movementMock.Object, turnMock.Object, positionReporterMock.Object);

            //Act
            rover.TurnLeft();
            rover.TurnLeft();
            rover.Move(30);

            //Assert
            movementMock.Verify(m => m.Move(ref It.Ref<int>.IsAny, ref It.Ref<int>.IsAny, It.IsAny<string>(), It.IsAny<int>()), Times.Once);

            positionReporterMock.Verify(p => p.ReportPosition(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()), Times.AtLeastOnce);

            positionReporterMock.VerifyNoOtherCalls();
        }


        [Test]
        public void MarsRover_MoveEast_ShouldUpdatePosition()
        {
            // Arrange
            var movementMock = new Mock<IMovement>();
            var turnMock = new Mock<ITurn>();
            var positionReporterMock = new Mock<IPositionReporter>();

            var rover = new MarsRover(movementMock.Object, turnMock.Object, positionReporterMock.Object);

            //Act
            rover.TurnLeft();
            rover.Move(20);

            //Assert
            movementMock.Verify(m => m.Move(ref It.Ref<int>.IsAny, ref It.Ref<int>.IsAny, It.IsAny<string>(), It.IsAny<int>()), Times.Once);

            positionReporterMock.Verify(p => p.ReportPosition(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()), Times.Exactly(2));

            positionReporterMock.VerifyNoOtherCalls();
        }


        [Test]
        public void MarsRover_MoveWest_ShouldUpdatePosition()
        {
            // Arrange
            var movementMock = new Mock<IMovement>();
            var turnMock = new Mock<ITurn>();
            var positionReporterMock = new Mock<IPositionReporter>();

            var rover = new MarsRover(movementMock.Object, turnMock.Object, positionReporterMock.Object);

            //Act
            rover.TurnRight();
            rover.Move(20);

            //Assert
            movementMock.Verify(m => m.Move(ref It.Ref<int>.IsAny, ref It.Ref<int>.IsAny, It.IsAny<string>(), It.IsAny<int>()), Times.Once);

            positionReporterMock.Verify(p => p.ReportPosition(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()), Times.Exactly(2));

            positionReporterMock.VerifyNoOtherCalls();
        }

        [Test]
        public void MarsRover_TurnLeft_ShouldChangeDirection()
        {
            // Arrange
            var movementMock = new Mock<IMovement>();
            var turnMock = new Mock<ITurn>();
            var positionReporterMock = new Mock<IPositionReporter>();

            var rover = new MarsRover(movementMock.Object, turnMock.Object, positionReporterMock.Object);

            //Act
            rover.TurnLeft();

            //Assert
            turnMock.Verify(t => t.Turn(It.IsAny<string>(), "Left"), Times.Once);
            positionReporterMock.Verify(p => p.ReportPosition(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()), Times.Once);
        }


        [Test]
        public void MarsRover_TurnRight_ShouldChangeDirection()
        {
            // Arrange
            var movementMock = new Mock<IMovement>();
            var turnMock = new Mock<ITurn>();
            var positionReporterMock = new Mock<IPositionReporter>();

            var rover = new MarsRover(movementMock.Object, turnMock.Object, positionReporterMock.Object);

            //Act
            rover.TurnRight();

            //Assert
            turnMock.Verify(t => t.Turn(It.IsAny<string>(), "Right"), Times.Once);
            positionReporterMock.Verify(p => p.ReportPosition(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void MoveBeyondBoundary_ShouldStayAtBoundary()
        {
            // Arrange
            var movementMock = new Mock<IMovement>();
            movementMock.Setup(m => m.Move(ref It.Ref<int>.IsAny, ref It.Ref<int>.IsAny, It.IsAny<string>(), It.IsAny<int>()))
                .Callback((ref int x, ref int y, string direction, int distance) =>
                {

                    y = Math.Max(1, Math.Min(100, y + distance));


                });
            var turnMock = new Mock<ITurn>();
            var positionReporterMock = new Mock<IPositionReporter>();

            var rover = new MarsRover(movementMock.Object, turnMock.Object, positionReporterMock.Object);

            //Act
            rover.Move(200);

            //Assert
            movementMock.Verify(m => m.Move(ref It.Ref<int>.IsAny, ref It.Ref<int>.IsAny, It.IsAny<string>(), It.IsAny<int>()), Times.Once);
            positionReporterMock.Verify(p => p.ReportPosition(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()), Times.Once);
        }
    }
}