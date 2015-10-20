namespace TAIO.PSO
{
    /// <summary>
    /// Represents velocity in machine space.
    /// </summary>
    class Velocity
    {
        public PartialVelocity[] Velocities
        { get; }

        public Velocity(int numberOfAutomatonSymbols, int numberOfAutomatonStates)
        {
            Velocities = new PartialVelocity[numberOfAutomatonSymbols];

            for (int i = 0; i < Velocities.Length; i++)
                Velocities[i] = new PartialVelocity(numberOfAutomatonStates);
        }
    }
}
