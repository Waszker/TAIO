﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAIO.PSO
{
    /// <summary>
    /// Represents velocity in machine space.
    /// </summary>
    class Velocity
    {
        private PartialVelocity[] velocities;

        public Velocity(int numberOfAutomatonSymbols, int numberOfAutomatonStates)
        {
            velocities = new PartialVelocity[numberOfAutomatonSymbols];

            for (int i = 0; i < velocities.Length; i++)
                velocities[i] = new PartialVelocity(numberOfAutomatonStates);
        }
    }
}
