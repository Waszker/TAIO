using Microsoft.VisualStudio.TestTools.UnitTesting;
using TAIO.PSO;
using TAIO.Automata;
using System.Collections.Generic;

namespace Tests
{
    /// <summary>
    /// Particle testing routines.
    /// </summary>
    [TestClass()]
    public class ParticleTests
    {

        [TestMethod()]
        public void DistanceToTest()
        { 
            // Arrange
            Particle firstParticle = new Particle(3, 2) { Position = { OnePositions = new[,] { { 1, 0 }, { 1, 0 }, { 0, 1 } } } };
            Particle secondParticle = new Particle(3, 2) { Position = { OnePositions = new[,] { { 0, 1 }, { 1, 0 }, { 0, 1 } } } };

            // Act
            double distance = firstParticle.DistanceTo(secondParticle);

            // Assert
            Assert.AreEqual(4, distance);
        }

        /// <summary>
        /// Checks particle movement.
        /// </summary>
        [TestMethod()]
        public void MoveParticleTest()
        {
            Position bestPosition = new Position(3, 4, 23) { OnePositions = new[,] { { 1, 1, 3, 1 }, { 2, 1, 3, 2 }, { 2, 1, 2, 2 } } };
            List<string> wordsSet = new List<string>();
            wordsSet.Add("012");
            TargetFunction f = new TargetFunction(new Automaton(bestPosition), wordsSet, wordsSet);
            Particle firstParticle = new Particle(3, 4) { Position = bestPosition };
            firstParticle.MoveParticle(bestPosition, 2, 2);
            Assert.AreEqual(firstParticle.Position.CompareTo(bestPosition), 0);
        }

        /// <summary>
        /// Checks particle movement.
        /// </summary>
        [TestMethod()]
        public void MoveParticleTest2()
        {
            Position bestPosition = new Position(3, 4, 16) { OnePositions = new[,] { { 1, 1, 3, 1 }, { 2, 1, 3, 2 }, { 2, 1, 2, 2 } } };
            Position particlePosition = new Position(3, 4, 89) { OnePositions = new[,] { { 0, 1, 2, 3 }, { 2, 1, 0, 2 }, { 1, 1, 3, 3 } } };
            List<string> wordsSet = new List<string>();
            wordsSet.Add("012");
            TargetFunction f = new TargetFunction(new Automaton(bestPosition), wordsSet, wordsSet);
            Particle firstParticle = new Particle(3, 4) { Position = particlePosition };
            firstParticle.MoveParticle(bestPosition, 0, 0);
            Assert.AreEqual(firstParticle.Position.CompareTo(bestPosition), 1);
        }
    }
}