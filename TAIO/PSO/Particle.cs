using System;

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
            // TODO: Refactor this method
            Random r = new Random();
            Position result1 = PersonalBestPosition.Substract(Position);
            Position result2 = globalBestPosition.Substract(Position);
            result1.Multiply(r.NextDouble() * c1);
            result2.Multiply(r.NextDouble() * c2);

            Velocity velocity1 = result1.ConvertToVelocity();
            Velocity velocity2 = result2.ConvertToVelocity();
            velocity1.Add(velocity2);
            _velocity.Add(velocity1);
        }
    }
}
