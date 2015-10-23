namespace TAIO.PSO
{
    /// <summary>
    /// Class representing particle in PSO algorithm.
    /// </summary>
    class Particle
    {
        public Position PersonalBestPosition { get; private set; }
        private Velocity _velocity;
        public Position Position { get; }

        public Particle(int symbolCount, int stateCount)
        {
            Position = new Position(symbolCount, stateCount);
            PersonalBestPosition = Position;
            _velocity = new Velocity(symbolCount, stateCount);
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
            Position.UpdatePosition(_velocity);
            if (Position.CompareTo(PersonalBestPosition) == 1) PersonalBestPosition = Position;
        }

        private void UpdateVelocity(Position globalBestPosition, int c1, int c2, Position localBestPosition = null)
        {
            // TODO: Change that
            _velocity = null;
        }
    }
}
