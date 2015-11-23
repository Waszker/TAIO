﻿using System;

namespace TAIO.PSO
{
    /// <summary>
    /// Class representing velocity at the plane corresponding to one alphabet symbol.
    /// </summary>
    public class PartialVelocity
    {
        // Velocities for every state on symbol's plane
        public int[] PVelocities { get; set; }

        /// <summary>
        /// Creates partial velocity for one plane.
        /// If the seed parameter is non-negative, the newly created velocity array is filled with pseud-random number generated by this seed.
        /// </summary>
        public PartialVelocity(int numberOfAutomatonStates, int seed = -1)
        {
            PVelocities = new int[numberOfAutomatonStates];

            if (seed > 0)
            {
                Random rand = new Random(seed);
                for (int i = 0; i < PVelocities.Length; i++)
                    PVelocities[i] = rand.Next() % PVelocities.Length;
            }
        }

        /// <summary>
        /// Creates partial velocity for one plane and initializes its values.
        /// </summary>
        public PartialVelocity(int[] partialVelocityValues)
        {
            PVelocities = new int[partialVelocityValues.Length];

            for (int i = 0; i < partialVelocityValues.Length; i++)
                PVelocities[i] = partialVelocityValues[i];
        }

        /// <summary>
        /// Adds one PartialVelocity instance to other.
        /// </summary>
        public void Add(PartialVelocity pVelocity)
        {
            if(PVelocities.Length != pVelocity.PVelocities.Length)
            {
                throw new ArgumentException("Both partial velocity vectors must be equal in length.");
            }

            for (int i = 0; i < PVelocities.Length; i++)
                PVelocities[i] = pVelocity.PVelocities[i];
        }
    }
}
