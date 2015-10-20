using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAIO.PSO
{
    class PsoAlgorithm
    {
        private double _minErrorLevel;
        private int _maxIterationCount;
        private int _maxStateCount;
        private Particle[] _particles;

        public PsoAlgorithm(double minErrorLevel, int maxIterationCount, int maxStateCount, int particlesNumber)
        {
            _minErrorLevel = minErrorLevel;
            _maxIterationCount = maxIterationCount;
            _maxStateCount = maxStateCount;
            _particles = new Particle[particlesNumber];

            for (int i = 0; i < particlesNumber; i++)
                _particles[i] = new Particle();
        }


    }
}
