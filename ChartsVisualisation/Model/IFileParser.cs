using System;
using System.Collections.Generic;
using System.Text;
using LinearAlgebra;

namespace ChartsVisualisation.Model
{
    interface IFileParser
    {
        void ReadFile(string path);
        List<string> IrisSpecs { get; }
        List<List<MathVector>> GroupedVectors { get; }
        public List<string> IrisSpecies { get; }
    }
}
