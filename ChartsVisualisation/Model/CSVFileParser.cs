using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using LinearAlgebra;
using ChartsVisualisation.Model;

namespace ChartsVisualisation
{

    class CSVFileParser : IFileParser
    {
        private string[][] _dataMatrix;
        private int NumOfSpecies = 3;
        private int NumOfSpecs = 4;
        private string [] _irisSpecies = new string[4];
        private List<MathVector> _vectors = new List<MathVector>();
        private List<List<MathVector>> _groupedVectors = new List<List<MathVector>>();

        /// <summary>
        /// Finds species of iris.
        /// </summary>
        private void DefineSpecies()
        {
            string[] species = new string[_dataMatrix.Length];
            for (int i = 0; i < _dataMatrix.Length; i++)
            {
                species[i] = _dataMatrix[i][4];
            }

            IEnumerable<string> distinctSpecies = species.Distinct();
            int numOfSpecies = -1;
            foreach (string s in distinctSpecies)
            {
                if (numOfSpecies != -1)
                {
                    if (s != "setosa" && s != "versicolor" && s != "virginica")
                        throw new FileFormatException();
                    _irisSpecies[numOfSpecies] = s;
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

        /// <summary>
        /// Checks right structure in file.
        /// </summary>
        private void DefineData()
        {
            int NumInRow = NumOfSpecs + 1;

            for (int i = 0; i < _dataMatrix.Length; i++)
            {
                MathVector temp = new MathVector(NumOfSpecs);
                if (_dataMatrix[i].Length != NumInRow)
                {
                    throw new FileFormatException();
                }
                for (int j = 0; j < NumOfSpecs; j++)
                {                
                    double d;
                    if (double.TryParse(_dataMatrix[i][j], out d) && i != 0)
                    {                        
                        temp[j] = Convert.ToDouble(_dataMatrix[i][j]);
                    }
                    else if (i != 0)
                    {
                        throw new FileFormatException();
                    }
                    
                }
                if (i != 0)
                    _vectors.Add(temp);
            }
        }

        private void GroupVectors()
        {
            int ind = 0;
            for (int i = 0; i < NumOfSpecies; i++)
            {
                List<MathVector> tempGroupVectors = new List<MathVector>();
                while (_dataMatrix[ind+1][4] == _irisSpecies[i] && ind < _dataMatrix.Length-2)
                {
                    tempGroupVectors.Add(_vectors[ind]);
                    ind++;
                }
                _groupedVectors.Add(tempGroupVectors);
            }
            
        }

        /// <summary>
        /// Reads data from file.
        /// </summary>
        /// <param name="path">Path of file</param>
        public void ReadFile(string path)
        {
            if (path == null)
                throw new FileNotFoundException();
            long size = new FileInfo(path).Length;
            Console.WriteLine("file size " + size);
            if (size > 2 * 1024 * 1024)
                throw new FileLoadException();

            string[] _stringsArray = File.ReadAllLines(path);
            _dataMatrix = _stringsArray.Select(x => x.Split(',')).ToArray();

            DefineData();           
            DefineSpecies();
            GroupVectors();
        }

        public List<string> IrisSpecs
        {
            get
            {
                return _dataMatrix[0].ToList();
            }

        }
        public List<List<MathVector>> GroupedVectors
        {
            get
            {
                return _groupedVectors;
            }

        }

        public List<string> IrisSpecies
        {
            get
            {
                return _irisSpecies.ToList();
            }
        }
    }
}
