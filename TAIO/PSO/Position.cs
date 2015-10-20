namespace TAIO.PSO
{
    /// <summary>
    /// Represents position of particle inside the system.
    /// </summary>
    class Position
    {
        /// <summary>
        /// For each symbol we store information about its array function in form of a vector where we put number of next state.
        /// E.g. [a] -> [2][1][0]  :: for symbol 'a' while being in state q0 we move to state q2
        /// </summary>
        private int[,] _onePositions;

        public Position(int numberOfAutomatonSymbols, int numberOfAutomatonStates)
        {
            _onePositions = new int[numberOfAutomatonSymbols, numberOfAutomatonStates];
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
        }
    }
}
