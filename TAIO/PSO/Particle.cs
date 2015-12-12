using System;
using System.Linq;

namespace TAIO.PSO
{
    /// <summary>
    /// Class representing particle in PSO algorithm.
    /// </summary>
    public class Particle
    {
        /// <summary>
        /// Personal best position of particle found during PSO algorthm run.
        /// </summary>
        public Position PersonalBestPosition { get; private set; }

        /// <summary>
        /// Number of iterations since particle has changed it position.
        /// </summary>
        public int timeSinceBestChanged = 0;

        /// <summary>
        /// Particle position in search space.
        /// </summary>
        public Position Position { get; set; }
        private Velocity _velocity;

        /// <summary>
        /// Creates particle for PSO algorithm that will traverse automata space.
        /// </summary>
        /// <param name="symbolCount"></param>
        /// <param name="stateCount"></param>
        /// <param name="seed"></param>
        public Particle(int symbolCount, int stateCount, int seed = 0)
        {
            Position = new Position(symbolCount, stateCount, seed);
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
            // Construct words
            bool[] currentParticleWord = CompressAutomatonRepresentation(Position.OnePositions);
            bool[] anotherParticleWord = CompressAutomatonRepresentation(particle.Position.OnePositions);

            return currentParticleWord.Where((t, i) => t != anotherParticleWord[i]).Count();
        }

        /// <summary>
        /// Compress automaton representation from two dimensional to one dimensional array.
        /// 
        /// **************
        /// 0 1 0
        /// 1 0 0 -> 1 0 2 
        /// 0 0 1
        /// **************
        /// 
        /// </summary>
        /// <returns>Compressed automaton respresentation</returns>
        private bool[] CompressAutomatonRepresentation(int[,] onePositions)
        {
            // Dimentions size
            int alphabetLength = onePositions.GetLength(0);
            int statesNumber = onePositions.GetLength(1);

            // Result word
            bool[] word = new bool[(int) (alphabetLength * Math.Pow(statesNumber, 2))];

            // onePositions.GetLength(0) = number of alphabet symbols
            for (int i = 0; i < onePositions.GetLength(0); i++)
            {
                for (int j = 0; j < onePositions.GetLength(1); j++)
                {
                    int position = (int) (i*Math.Pow(statesNumber, 2) + statesNumber*j + onePositions[i, j]);
                    word[position] = true;
                }
            }

            return word;
        }

        /// <summary>
        /// Moves particle to another position according to PSO guidelines.
        /// </summary>
        /// <param name="globalBestPosition"></param>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <param name="localBestPosition"></param>
        public void MoveParticle(Position globalBestPosition, int c1, int c2, Position localBestPosition = null)
        {
            UpdateVelocity(globalBestPosition, c1, c2, localBestPosition);
            Position.UpdatePosition(_velocity);
            timeSinceBestChanged++;
            if (Position.CompareTo(PersonalBestPosition) < 0) { PersonalBestPosition = Position; timeSinceBestChanged = 0; }
        }
        
        private void UpdateVelocity(Position globalBestPosition, int c1, int c2, Position localBestPosition = null)
        {
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
