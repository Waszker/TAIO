﻿namespace TAIO.PSO
{
    /// <summary>
    /// Class representing particle in PSO algorithm.
    /// </summary>
    class Particle
    {
        private double _pbest;
        private Velocity _velocity;
        private Position _position;

        /// <summary>
        /// Returns the distance to provided particle.
        /// </summary>
        /// <param name="particle"></param>
        /// <returns></returns>
        public double DistanceTo(Particle particle)
        {
            throw new System.NotImplementedException("This method will be implemented by Paweł Kużmicz ^_^");
        }
    }
}
