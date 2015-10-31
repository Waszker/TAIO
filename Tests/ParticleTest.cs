using Microsoft.VisualStudio.TestTools.UnitTesting;
using TAIO.PSO;

namespace Tests
{
    [TestClass]
    public class ParticleTest
    {
        [TestMethod]
        public void ParticelDistanceToMethodTest()
        {
            // Arrange
            Particle firstParticle = new Particle(3, 2) {Position = {OnePositions = new[,] {{1, 0}, {1, 0}, {0, 1}}}};
            Particle secondParticle = new Particle(3, 2) {Position = {OnePositions = new[,] {{0, 1}, {1, 0}, {0, 1}}}};

            // Act
            double distance = firstParticle.DistanceTo(secondParticle);

            // Assert
            Assert.AreEqual(4, distance);
        }
    }
}
