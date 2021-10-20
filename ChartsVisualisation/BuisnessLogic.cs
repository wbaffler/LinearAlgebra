using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using LinearAlgebra;

namespace ChartsVisualisation
{
    class BuisnessLogic
    {
        private string[][] _dataMatrix;
        private void DefineSpecies ()
        {
            //Find species of iris
            string[] species = new string[_dataMatrix.Length];
            for (int i = 0; i < _dataMatrix.Length; i++)
            {
                species[i] = _dataMatrix[i][4];
            }

            IEnumerable<string> distinctSpecies = species.Distinct(); //unique types
            int numOfSpecies = -1;
            foreach (string s in distinctSpecies) //write in massive without 1st line
            {
                if (numOfSpecies != -1)
                {
                    IrisSpecies[numOfSpecies] = s;
                    Console.WriteLine(numOfSpecies + " " + IrisSpecies[numOfSpecies]);
                }
                numOfSpecies++;
                if (numOfSpecies > 3)
                    throw new FileFormatException();
            }
            if (numOfSpecies != 3)
            {
                throw new FileFormatException();
            }
        }

        private void CheckFormatData()
        {
            int NumInRow = NumOfSpecs + 1;

            for (int i = 0; i < _dataMatrix.Length; i++)
            {
                if (_dataMatrix[i].Length != NumInRow)
                {
                    throw new FileFormatException();
                }
                for (int j = 0; j < NumOfSpecs; j++)
                {
                    double d;
                    if (!double.TryParse(_dataMatrix[i][j], out d) && i != 0)
                    {
                        throw new FileFormatException();
                    }
                }
            }
        }

        private MathVector MakeVector(double[] array)
        {
            var vect = new MathVector(array.Length);
            for (int i = 0; i < array.Length; i++)
            {
                vect[i] = array[i];
            }
            return vect;
        }
        private double [] FindVectorValue(string [] dataLine)
        {
            double[] arr = new double[4];
            for (int i = 0; i < NumOfSpecs; i++)
            {
                arr[i] = Convert.ToDouble(dataLine[i]);
            }
            return arr;
        }

        public BuisnessLogic()
        {
            NumOfSpecies = 3;
            NumOfSpecs = 4;
            IrisSpecies = new string[4];
        }
        public void ReadFile(string path)
        {
            if (path == null)
                throw new FileNotFoundException();
            long size = new System.IO.FileInfo(path).Length;
            Console.WriteLine("file size " + size);
            if (size > 2 * 1024 * 1024)
                throw new FileLoadException();

            string [] _stringsArray = File.ReadAllLines(path);
            _dataMatrix = _stringsArray.Select(x => x.Split(',')).ToArray();           

            this.CheckFormatData();          

            this.DefineSpecies();
        }

        public double[] CalculateAverage(MathVector [] mathVectors)
        {
            MathVector tempVector = new MathVector(mathVectors[0].Dimensions);
            int count = 0;
            for (int i = 0; i < mathVectors.Length; i++)
            {
                if (mathVectors[i] != null)
                {
                    tempVector = (MathVector)(tempVector + mathVectors[i]);
                    count++;
                }
            }
            tempVector = (MathVector)(tempVector / count);
            double[] avgArr = new double[mathVectors[0].Dimensions];
            for (int i = 0; i < mathVectors[0].Dimensions; i++)
            {
                avgArr[i] = Math.Round(tempVector[i], 2);
                //Console.WriteLine("avgArr: " + avgArr[i]);
            }
            return avgArr;
        }

        public MathVector[] MakeArrVector(int n)
        {
            var vector = new MathVector[_dataMatrix.Length];
            int count = 0;

            for (int i = 1; i < _dataMatrix.Length; i++)
            {
                if (_dataMatrix[i][NumOfSpecies + 1] == IrisSpecies[n])
                {
                    vector[count] = MakeVector(FindVectorValue(_dataMatrix[i]));
                    count++;
                }
            }

            return vector;
        }

        public double[] CalculateDistance(double [][] arr)
        {
            MathVector avgVector1 = MakeVector(arr[0]);
            MathVector avgVector2 = MakeVector(arr[1]);
            MathVector avgVector3 = MakeVector(arr[2]);

            Console.WriteLine("avgVec: " + avgVector1[0]);
            double[] dist = new double[3];

            dist[0] = Math.Round(avgVector1.CalcDistance(avgVector2), 2);
            dist[1] = Math.Round(avgVector1.CalcDistance(avgVector3), 2);
            dist[2] = Math.Round(avgVector2.CalcDistance(avgVector3), 2);
            Console.WriteLine("dist: " + dist[0]);

            return dist;
        }

        public int NumOfSpecies { get; set; }

        public int NumOfSpecs { get; set; }

        public string [] IrisSpecies { get; }
        public string [] IrisSpecs 
        {
            get
            {
                return _dataMatrix[0];
            }
            
        }
    }
}
