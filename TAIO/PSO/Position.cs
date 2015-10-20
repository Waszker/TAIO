using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAIO.PSO
{
    /// <summary>
    /// Represents position of particle inside the system.
    /// </summary>
    class Position
    {
        private int[,] onePositions;

        public Position(int numberOfAutomatonSymbols, int numberOfAutomatonStates)
        {
            onePositions = new int[numberOfAutomatonSymbols, numberOfAutomatonStates];
        }

        /// <summary>
        /// Updates position based on provided velocity.
        /// </summary>
        /// <param name="velocity"></param>
        public void UpdatePosition(Velocity velocity)
        {
            // Updating position is in fact moving "ones" inside array
            for (int symbol = 0; symbol < velocity.velocities.Length; symbol++)
                for (int state = 0; state < velocity.velocities[symbol].velocities.Length; state++)
                    onePositions[symbol, state] = (onePositions[symbol, state] + velocity.velocities[symbol].velocities[state]) % onePositions.GetLength(1);
        }
    }
}
