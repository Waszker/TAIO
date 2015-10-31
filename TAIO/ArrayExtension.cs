using System;

namespace TAIO
{
    public static class ArrayExtension
    {
        public static int[] SliceDim(this int[,] positions, int num)
        {
            int dimLength = positions.GetLength(0);
            int[] dim = new int[dimLength];

            for (int i = 0; i < dimLength; i++)
                dim[i] = positions[num, i];

            return dim;
        }
    }
}
