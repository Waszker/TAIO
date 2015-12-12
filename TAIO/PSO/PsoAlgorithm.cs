using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using TAIO.Automata;

namespace TAIO.PSO
{
    /// <summary>
    /// Class needed for PSO algorithm, solving problem of finding best automaton within space of all automatons with certain number of states.
    /// </summary>
    class PsoAlgorithm
    {
        private double _minErrorLevel;
        private readonly int _maxIterationCount;
        private readonly int _maxStateCount;
        private readonly int _alphabetCount;
        private readonly int _particleNumber;

        /// <summary>
        /// Creates instance using provided information.
        /// </summary>
        /// <param name="minErrorLevel"></param>
        /// <param name="maxIterationCount"></param>
        /// <param name="maxStateCount"></param>
        /// <param name="alphabetCount"></param>
        /// <param name="particlesNumber"></param>
        public PsoAlgorithm(double minErrorLevel, int maxIterationCount, int maxStateCount, int alphabetCount, int particlesNumber)
        {
            _minErrorLevel = minErrorLevel;
            _maxIterationCount = maxIterationCount;
            _maxStateCount = maxStateCount;
            _alphabetCount = alphabetCount;
            _particleNumber = particlesNumber;
        }

        /// <summary>
        /// Runs PSO algorithm and returns best, found automaton.
        /// </summary>
        public System.Tuple<Automaton, double> RunAlgorithm()
        {
            List<Automaton> automatons = new List<Automaton>();
            Thread[] threads = new Thread[_maxStateCount];

            for (int numberOfStates = 3; numberOfStates <= _maxStateCount; numberOfStates++)
            {
                threads[numberOfStates - 1] = new Thread(() => { automatons.Add(GetBestAutomatonFromSpace(numberOfStates)); });
                threads[numberOfStates - 1].Start();
            }

            for (int numberOfStates = 3; numberOfStates <= _maxStateCount; numberOfStates++)
            {
                threads[numberOfStates - 1].Join();
                System.Console.WriteLine("PSO join!");
            }
            System.Console.WriteLine("PSO end!");

            return EvaluateBestAutomaton(automatons);
        }

        private void GenerateParticles(Particle[] particles, int stateCount)
        {
            for (int i = 0; i < particles.Length; i++)
                particles[i] = new Particle(_alphabetCount, stateCount, i * (i % 2) + i + i * 3);
        }

        private Automaton GetBestAutomatonFromSpace(int numberOfStates)
        {
            Position bestPositionSoFar = null;
            int lowestErrorSoFar = int.MaxValue;
            int c1, c2;
            int iteration = 0;
            Particle[] particles = new Particle[_particleNumber];
            GenerateParticles(particles, numberOfStates);
            Position globalBest;

            // Possible changes
            c1 = c2 = 2;
            System.Console.WriteLine("PSO start!");

            do
            {
                // Update global best
                globalBest = particles[0].PersonalBestPosition;
                foreach (Particle p in particles)
                    if (p.PersonalBestPosition.CompareTo(globalBest) < 0)
                        globalBest = p.PersonalBestPosition;

                // Move particles and check errors
                for(int i = 0; i<particles.Length; i++)
                {
                    Particle p = particles[i];
                    p.MoveParticle(globalBest, c1, c2);
                    if (p.timeSinceBestChanged > 3)
                        p = particles[i] = new Particle(_alphabetCount, numberOfStates, i * (i % 2) + i + i * 3);

                    int currentErrors = p.Position.TargetFunctionValue;
                    if (currentErrors < lowestErrorSoFar)
                    {
                        Debug.WriteLine("Found better particle! Updating... {0} {1} {2}", numberOfStates, currentErrors, lowestErrorSoFar);
                        lowestErrorSoFar = currentErrors;
                        bestPositionSoFar = Position.DeepClone(p.Position);
                    }
                }

                iteration++;
                System.Console.WriteLine("Next iteration {0}", iteration);
            } while (iteration < _maxIterationCount);

            return new Automaton(bestPositionSoFar);
        }

        private System.Tuple<Automaton, double> EvaluateBestAutomaton(List<Automaton> automatons)
        {
            int bestError = int.MaxValue;
            int bestAutomatonIndex = 0;
            int[] automatonResult = new int[automatons.Count];
            Thread[] threads = new Thread[automatons.Count];

            for (int i = 0; i < automatons.Count; i++)
            {
                int g = i;
                threads[i] = new Thread(() => automatonResult[g] = TargetFunction.GetFunctionValueForAutomaton(automatons[g]));
                threads[i].Start();
            }

            for (int i = 0; i < automatons.Count; i++)
            {
                threads[i].Join();
            }

            for (int i = 0; i < automatons.Count; i++)
            {
                if (automatonResult[i] < bestError)
                {
                    bestAutomatonIndex = i;
                }
            }

            System.Console.WriteLine("{0} errors in {1} words", automatonResult[bestAutomatonIndex], TargetFunction.GetTestSetCount());
            return new System.Tuple<Automaton, double>(automatons[bestAutomatonIndex], ((double)automatonResult[bestAutomatonIndex]/(double)TargetFunction.GetTestSetCount()));
        }
    }
}
