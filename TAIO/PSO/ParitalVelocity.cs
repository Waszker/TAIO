using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAIO.PSO
{
    /// <summary>
    /// Class representing velocity at the plane corresponding to one alphabet symbol.
    /// </summary>
    class PartialVelocity
    {
        // Velocities for every state on symbol's plane
        private int[] velocities;

        /// <summary>
        /// Creates partial velocity for one plane
        /// </summary>
        /// <param name="numberOfAutomatonStates"></param>
        public PartialVelocity(int numberOfAutomatonStates)
        {
            velocities = new int[numberOfAutomatonStates];
        }
    }
}
