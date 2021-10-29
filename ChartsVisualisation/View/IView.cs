using System;
using System.Collections.Generic;
using System.Text;

namespace ChartsVisualisation.View
{
    interface IView
    {
        void SetGraphs(List<List<double>> averages, List<double> distances, List<string> species, List<string> specs);
        string DisplayPath { set; }
        void DisplayError(string errorText);
    }
}
