﻿using System;

namespace TAIO.PSO
{
    /// <summary>
    /// Represents velocity in machine space.
    /// </summary>
    public class Velocity
    {
        public PartialVelocity[] Velocities { get; set; }

        public Velocity(int numberOfAutomatonSymbols, int numberOfAutomatonStates)
        {
            Velocities = new PartialVelocity[numberOfAutomatonSymbols];

            for (int i = 0; i < Velocities.Length; i++)
                Velocities[i] = new PartialVelocity(numberOfAutomatonStates);
        }

        public void Add(Velocity velocity)
        {
            if (Velocities.Length != velocity.Velocities.Length)
            {
                throw new ArgumentException("Both velocity vectors must be equal in length.");
            }

            for (int i = 0; i < Velocities.Length; i++)
                Velocities[i].Add(velocity.Velocities[i]);
        }
    }
}
