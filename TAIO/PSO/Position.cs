using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TAIO.Automata;

namespace TAIO.PSO
{
    /// <summary>
    /// Represents position of particle inside the system.
    /// </summary>
    [Serializable]
    public class Position : IComparable<Position>
    {
        #region Properties

        /// <summary>
        /// For each symbol we store information about its array function in form of a vector where we put number of next state.
        /// E.g. [a] -> [2][1][0]  :: for symbol 'a' while being in state q0 we move to state q2
        /// </summary>
        public int[,] OnePositions { get; set; }

        public int NumberOfStates { get; set; }
        public int TargetFunctionValue { get; set; }

        #endregion

        public Position(int numberOfAutomatonSymbols, int numberOfAutomatonStates, int seed)
        {
            NumberOfStates = numberOfAutomatonStates;
            OnePositions = new int[numberOfAutomatonSymbols, numberOfAutomatonStates];

            for (int i = 0; i < numberOfAutomatonSymbols; i++)
                for (int j = 0; j < numberOfAutomatonStates; j++)
                    OnePositions[i, j] = (new Random(i * j + i + j + (j % 2) + seed)).Next(numberOfAutomatonStates);

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
                    OnePositions[symbol, state] = Math.Abs(OnePositions[symbol, state] +
                                                   velocity.Velocities[symbol].PVelocities[state])%
                                                  OnePositions.GetLength(1);

            // Update target function value
            UpdateTargetFunctionValue();
        }

        /// <summary>
        /// Compares Position object's function value to other.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public int CompareTo(Position x)
        {
            return TargetFunctionValue.CompareTo(x.TargetFunctionValue);
        }

        /// <summary>
        /// Multiplies all values by certain value. Used in PSO Algorithm.
        /// </summary>
        /// <param name="value"></param>
        public void Multiply(double value)
        {
            for (int i = 0; i < OnePositions.GetLength(0); i++)
                for (int j = 0; j < OnePositions.GetLength(1); j++)
                    OnePositions[i, j] = (int) (OnePositions[i, j]*value);
        }

        /// <summary>
        /// Returns Velocity object constructed from position. This object "looks" the same - vectors are identical.
        /// </summary>
        /// <returns></returns>
        public Velocity ConvertToVelocity()
        {
            Velocity result = new Velocity(OnePositions.GetLength(0), OnePositions.GetLength(1));
            for (int i = 0; i < result.Velocities.Length; i++)
            {
                for (int j = 0; j < OnePositions.GetLength(1); j++)
                {
                    result.Velocities[i].PVelocities[j] = OnePositions[i, j];
                }
            }

            return result;
        }

        /// <summary>
        /// Returns new vector being the result of substraction.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public Position Substract(Position position)
        {
            if (position.OnePositions.GetLength(0) != OnePositions.GetLength(0) ||
                position.OnePositions.GetLength(1) != OnePositions.GetLength(1))
                throw new ArgumentException("Both positions should belong to the space with equal number of dimensions.");

            Position result = new Position(OnePositions.GetLength(0), OnePositions.GetLength(1), 0);
            for (int i = 0; i < OnePositions.GetLength(0); i++)
                for (int j = 0; j < OnePositions.GetLength(1); j++)
                    result.OnePositions[i, j] = OnePositions[i, j] - position.OnePositions[i, j];

            return result;
        }

        /// <summary>
        /// Returns deep clone of provided object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T DeepClone<T>(T obj)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);
                ms.Position = 0;

                return (T) formatter.Deserialize(ms);
            }
        }

        private void UpdateTargetFunctionValue()
        {
            TargetFunctionValue = TargetFunction.GetFunctionValue(this);
        }
    }
}
