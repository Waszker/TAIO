﻿using System;
using System.Linq;

namespace TAIO.PSO
{
    /// <summary>
    /// Class representing particle in PSO algorithm.
    /// </summary>
    public class Particle
    {
        public Position PersonalBestPosition { get; private set; }
        private Velocity _velocity;
        public Position Position { get; set; }

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
            // Construct words
            bool[] currentParticleWord = ConstructWord(Position.OnePositions);
            bool[] anotherParticleWord = ConstructWord(particle.Position.OnePositions);

            return currentParticleWord.Where((t, i) => t != anotherParticleWord[i]).Count();
        }

        private bool[] ConstructWord(int[,] onePositions)
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
