using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLeetCode
{
    public enum AlgorithmType
    {
        BackTracking
    }

    public interface IExecutable
    {
        AlgorithmType Type { get; }
        string Name { get; }
        string Description { get; }
        void Execute();
    }
}
