using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TAIO.Automata;

namespace TAIO.PSO
{
    /// <summary>
    /// Represents position of particle inside the system.
    /// </summary>
    [Serializable]
    class Position : IComparable<Position>
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

        public int CompareTo(Position x)
        {
            return TargetFunctionValue.CompareTo(x.TargetFunctionValue);
        }

        public static T DeepClone<T>(T obj)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);
                ms.Position = 0;

                return (T)formatter.Deserialize(ms);
            }
        }

        private void UpdateTargetFunctionValue()
        {
            TargetFunctionValue = TargetFunction.GetFunctionValue(this);
        }
    }
}
