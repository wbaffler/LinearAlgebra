using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using LinearAlgebra;

namespace ChartsVisualisation
{
    class MetricsCalculation
    {
        /// <summary>
        /// Calculate average from data.
        /// </summary>
        /// <param name="mathVectors">Vector</param>
        /// <returns>Array of average specificies</returns>
        public List<MathVector> CalculateAverage(List<List <MathVector>> mathVectors)
        {
            List<MathVector> listOfAverages = new List<MathVector>();
            for (int j = 0; j < mathVectors.Count; j++)
            {
                MathVector tempVector = new MathVector(mathVectors[0][0].Dimensions);
                int count = 0;
                for (int i = 0; i < mathVectors[j].Count; i++)
                {
                    if (mathVectors[j][i] != null)
                    {
                        tempVector = (MathVector)(tempVector + mathVectors[j][i]);
                        count++;
                    }
                }
                tempVector = (MathVector)(tempVector / count);

                for (int i = 0; i < mathVectors[0][0].Dimensions; i++)
                {
                    tempVector[i] = Math.Round(tempVector[i], 2);
                }
                listOfAverages.Add(tempVector);
            }
            
            return listOfAverages;
        }

        /// <summary>
        /// Calculate distance between species
        /// </summary>
        public List<double> CalculateDistance(List<MathVector> avgVectors)
        {

            double[] listOfDistances = new double[3];
            int k = 0;
            for (int i = 0; i < avgVectors.Count - 1; i++)
            {
                for (int j = i+1; j < avgVectors.Count; j++)
                {
                    listOfDistances[k] = Math.Round(avgVectors[i].CalcDistance(avgVectors[j]), 2);
                    k++;
                }
            }
            return listOfDistances.ToList();
        }
    }
}
