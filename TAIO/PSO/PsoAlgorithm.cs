using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAIO.Automata;

namespace TAIO.PSO
{
    /// <summary>
    /// Class needed for PSO algorithm, solving problem of finding best automaton within space of all automatons with certain number of states.
    /// </summary>
    class PsoAlgorithm
    {
        private double _minErrorLevel;
        private int _maxIterationCount;
        private int _maxStateCount;
        private int _alphabetCount;
        private Particle[] _particles;

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
            _particles = new Particle[particlesNumber];
        }

        /// <summary>
        /// Runs PSO algorithm and returns best, found automaton.
        /// </summary>
        public Automaton RunAlgorithm()
        {
            List<Automaton> automatons = new List<Automaton>();

            for (int numberOfStates = 1; numberOfStates <= _maxStateCount; numberOfStates++)
            {
                automatons.Add(GetBestAutomatonFromSpace(numberOfStates));
            }

            return EvaluateBestAutomaton(automatons);
        }

        private void GenerateParticles(int stateCount)
        {
            for (int i = 0; i < _particles.Length; i++)
                _particles[i] = new Particle(_alphabetCount, stateCount, i * (i % 2) + i + i*3);
        }

        private Automaton GetBestAutomatonFromSpace(int numberOfStates)
        {
            Position bestPositionSoFar = null;
            int lowestErrorSoFar = int.MaxValue;
            int c1, c2;
            int iteration = 0, errors = int.MaxValue;
            GenerateParticles(numberOfStates);
            Position globalBest;

            // Possible changes
            c1 = c2 = 2;

            do
            {
                // Update global best
                globalBest = _particles[0].PersonalBestPosition;
                foreach (Particle p in _particles)
                    if (p.PersonalBestPosition.CompareTo(globalBest) < 0)
                        globalBest = p.PersonalBestPosition;

                // Move particles and check errors
                foreach (Particle p in _particles)
                {
                    p.MoveParticle(globalBest, c1, c2);
                    int currentErrors = TargetFunction.GetFunctionValue(p.Position);
                    if (currentErrors < errors) errors = currentErrors;
                    if (errors < lowestErrorSoFar)
                    {
                        Debug.WriteLine("Found better particle! Updating... {0} {1} {2}", numberOfStates, errors, lowestErrorSoFar);
                        lowestErrorSoFar = errors;
                        bestPositionSoFar = Position.DeepClone(p.Position);
                    }
                }

                iteration++;
            } while (iteration < _maxIterationCount);

            return new Automaton(bestPositionSoFar);
        }

        private Automaton EvaluateBestAutomaton(List<Automaton> automatons)
        {
            int bestError = int.MaxValue;
            int bestAutomatonIndex = 0;

            for (int i = 0; i < automatons.Count; i++)
            {
                int automatonError = TargetFunction.GetFunctionValueForAutomaton(automatons[i]);
                if (automatonError < bestError)
                {
                    bestAutomatonIndex = i;
                }
            }

            return automatons[bestAutomatonIndex];
        }
    }
}
