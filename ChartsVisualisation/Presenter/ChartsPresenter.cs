using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ChartsVisualisation.View;
using LinearAlgebra;

namespace ChartsVisualisation.Presenter
{
    class ChartsPresenter
    {
        private readonly IView view;
        private readonly IFileParser parser = new CSVFileParser();
        private readonly MetricsCalculation calculatorMetric = new MetricsCalculation();
        private string filename;

        private List<List<double>> ConvertAvgData(List<MathVector> mathVectors)
        {
            List<List<double>> avgsMatrix = new List<List<double>>();     
            foreach(MathVector vec in mathVectors)
            {
                List<double> temp = new List<double>();
                for (int i = 0; i < vec.Dimensions; i++)
                {
                    temp.Add(vec[i]);
                }
                avgsMatrix.Add(temp);
            }
            return avgsMatrix;
        }

        public ChartsPresenter(IView view)
        {
            this.view = view;
        }

        public string Path { set => filename = value; get => filename; }

        public void LoadFileName()
        {
            view.DisplayPath = filename;
        }

        public void ProcessFile()
        {
            Console.WriteLine(filename);

            try
            {
                parser.ReadFile(filename);
                List<MathVector> avgsVectors = calculatorMetric.CalculateAverage(parser.GroupedVectors);
                List<List<double>> avgsDoubles = ConvertAvgData(avgsVectors);
                List<double> distanceDouble = calculatorMetric.CalculateDistance(avgsVectors);

                view.SetGraphs(avgsDoubles, distanceDouble, parser.IrisSpecies, parser.IrisSpecs);
          

            }
            catch (FileFormatException)
            {
                view.DisplayError("Некорректное содержимое файла");
            }
            catch (FileNotFoundException)
            {
                view.DisplayError("Пустой путь к файлу");
            }
            catch (FileLoadException)
            {
                view.DisplayError("Превышена допустимая размерность файла");
            }

        }
    }
}
