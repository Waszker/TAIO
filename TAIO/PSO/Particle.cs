namespace TAIO.PSO
{
    /// <summary>
    /// Class representing particle in PSO algorithm.
    /// </summary>
    class Particle
    {
        private Position _personalBestPosition;
        private Velocity _velocity;
        private Position _position;

        public Particle()
        {
                // TODO: Implement this!
        }

        public Particle(Position position, Velocity velocity)
        {
            _personalBestPosition = position;
            _position = position;
            _velocity = velocity;
        }

        /// <summary>
        /// Returns the distance to provided particle.
        /// </summary>
        /// <param name="particle"></param>
        /// <returns></returns>
        public double DistanceTo(Particle particle)
        {
            throw new System.NotImplementedException("This method will be implemented by Paweł Kużmicz ^_^");
        }

        public void MoveParticle(Position globalBestPosition, int c1, int c2, Position localBestPosition = null)
        {
            // TODO: Implement
            UpdateVelocity(globalBestPosition, c1, c2, localBestPosition);
            _position.UpdatePosition(_velocity);
            if (_position.CompareTo(_personalBestPosition) == 1) _personalBestPosition = _position;
        }

        private void UpdateVelocity(Position globalBestPosition, int c1, int c2, Position localBestPosition = null)
        {
            // TODO: Change that
            _velocity = null;
        }
    }
}
