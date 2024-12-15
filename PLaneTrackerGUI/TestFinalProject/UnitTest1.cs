using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Numerics;
using PLaneTrackerGUI;

namespace PLaneTrackerGUI
{
    [TestClass]
    public class UnitTest1 
    {
        [TestMethod]
        public void TestLocationPredictX()
        {
            // Arrange
            Plane plane = new PLaneTrackerGUI.Plane(10, 100, 200, 50, 50);
            plane.AverageX = new int[] { 100, 110, 120, 130 }; // Simulate movement

            int currentX = plane.PositionX;

            // Act
            int[] predictedX = plane.LocationPredictX(plane.AverageX, currentX);

            // Assert
            int expectedStep = 10; // Difference between consecutive AverageX entries
            Assert.AreEqual(currentX + expectedStep, predictedX[0], "Prediction step 1 is incorrect.");
            Assert.AreEqual(currentX + 2 * expectedStep, predictedX[1], "Prediction step 2 is incorrect.");
            Assert.AreEqual(currentX + 3 * expectedStep, predictedX[2], "Prediction step 3 is incorrect.");
        }

        [TestMethod]
        public void TestGoingRight_DetectsCorrectDirection()
        {
            // Arrange
            Plane plane = new Plane(10, 100, 200, 50, 50);
            int[] increasingX = new int[] { 100, 110, 120, 130 }; // Simulate moving to the right
            int[] decreasingX = new int[] { 130, 120, 110, 100 }; // Simulate moving to the left

            // Act
            bool isGoingRight1 = plane.GoingRight(increasingX);
            bool isGoingRight2 = plane.GoingRight(decreasingX);

            // Assert
            Assert.IsTrue(isGoingRight1, "Plane should be detected as going right.");
            Assert.IsFalse(isGoingRight2, "Plane should be detected as going left.");
        }
    }
}