using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TAIO.Automata;

namespace TAIO.PSO
{
    class PsoAlgorithm
    {
        private double _minErrorLevel;
        private int _maxIterationCount;
        private int _maxStateCount;
        private int _alphabetCount;
        private Particle[] _particles;

        public PsoAlgorithm(double minErrorLevel, int maxIterationCount, int maxStateCount, int alphabetCount, int particlesNumber)
        {
            _minErrorLevel = minErrorLevel;
            _maxIterationCount = maxIterationCount;
            _maxStateCount = maxStateCount;
            _alphabetCount = alphabetCount;
            _particles = new Particle[particlesNumber];
        }

        public Automaton RunAlgorithm()
        {
            Position bestPositionSoFar = null;
            int lowestErrorSoFar = int.MaxValue;

            for (int numberOfStates = 1; numberOfStates < _maxStateCount; numberOfStates++)
            {
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
                        if (p.PersonalBestPosition.CompareTo(globalBest) == 1)
                            globalBest = p.PersonalBestPosition;

                    // Move particles and check errors
                    foreach (Particle p in _particles)
                    {
                        p.MoveParticle(globalBest, c1, c2);
                        int currentErrors = TargetFunction.GetFunctionValue(p.Position);
                        if (currentErrors < errors) errors = currentErrors;
                        if(errors < lowestErrorSoFar)
                        {
                            lowestErrorSoFar = errors;
                            bestPositionSoFar = Position.DeepClone(p.Position);
                        }
                    }

                } while (iteration < _maxIterationCount || errors < _minErrorLevel);
            }

            return new Automaton(bestPositionSoFar);
        }

        private void GenerateParticles(int stateCount)
        {
            for (int i = 0; i < _particles.Length; i++)
                _particles[i] = new Particle(_alphabetCount, stateCount);
        }
    }
}
