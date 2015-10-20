using System;
using System.Collections;
using System.Collections.Generic;

namespace TAIO.PSO
{
    /// <summary>
    /// Represents position of particle inside the system.
    /// </summary>
    class Position : IComparer<Position>
    {
        /// <summary>
        /// For each symbol we store information about its array function in form of a vector where we put number of next state.
        /// E.g. [a] -> [2][1][0]  :: for symbol 'a' while being in state q0 we move to state q2
        /// </summary>
        private int[,] _onePositions;
        public int TargetFunctionValue { get; set; }

        public Position(int numberOfAutomatonSymbols, int numberOfAutomatonStates)
        {
            _onePositions = new int[numberOfAutomatonSymbols, numberOfAutomatonStates];
            UpdateTargetFunctionValue();
        }

        /// <summary>
        /// Updates position based on provided velocity.
        /// </summary>
        /// <param name="velocity"></param>
        public void UpdatePosition(Velocity velocity)
        {
            // Updating position is in fact moving "ones" inside array
            for (int symbol = 0; symbol < velocity.Velocities.Length; symbol++)
                for (int state = 0; state < velocity.Velocities[symbol].PVelocities.Length; state++)
                    _onePositions[symbol, state] = (_onePositions[symbol, state] + velocity.Velocities[symbol].PVelocities[state]) % _onePositions.GetLength(1);

            // Update target function value
            UpdateTargetFunctionValue();
        }

        public int Compare(Position x)
        {
            return TargetFunctionValue.CompareTo(x.TargetFunctionValue);
        }

        private void UpdateTargetFunctionValue()
        {
            // TODO: Implement that
            TargetFunctionValue = 0;
        }
    }
}
