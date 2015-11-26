using System;
using System.IO;
using QuickGraph.Graphviz;
using QuickGraph.Graphviz.Dot;

namespace TAIO.Automata
{
    /// <summary>
    /// Help class for managing output graph image
    /// </summary>
    public sealed class FileDotEngine : IDotEngine
    {
        public string Run(GraphvizImageType imageType, string dot, string outputFileName)
        {
            string output = outputFileName;
            File.WriteAllText(output, dot);
            var args = string.Format($"{output} -Tjpg -O");
            System.Diagnostics.Process.Start("TAIO_Execs\\dot.exe", args);
            return output;
        }
    }
}