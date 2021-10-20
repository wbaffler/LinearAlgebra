using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LinearAlgebra;
using System.Windows.Forms.DataVisualization.Charting;

namespace ChartsVisualisation
{
    public partial class Form1 : Form
    {
        string filename;

        public Form1()
        {
            InitializeComponent();

            //this.chart1.Titles.Add("TEST");
        }

        private void OverviewButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV files (*.csv)|*.csv";
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;

            filename = openFileDialog.FileName;
            filePath.Text = filename;

            
        }

        private void LaunchButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine(filename);
            BuisnessLogic logic = new BuisnessLogic();
            
            try
            {
                logic.ReadFile(filename);

                try
                { 
                    chart1.Series[logic.IrisSpecs[0]].Points.Clear();
                    chart2.Series[logic.IrisSpecs[1]].Points.Clear();
                    chart3.Series[logic.IrisSpecs[2]].Points.Clear();
                    chart4.Series[logic.IrisSpecs[3]].Points.Clear();
                    chartPie.Series["Distance"].Points.Clear();
                }
                catch (ArgumentException)
                { }

                try
                {
                    chart1.Series.Add(logic.IrisSpecs[0]);
                    chart2.Series.Add(logic.IrisSpecs[1]);
                    chart3.Series.Add(logic.IrisSpecs[2]);
                    chart4.Series.Add(logic.IrisSpecs[3]);
                    
                }
                catch (ArgumentException)
                { }

                chart1.Series[logic.IrisSpecs[0]].IsValueShownAsLabel = true;
                chart2.Series[logic.IrisSpecs[1]].IsValueShownAsLabel = true;
                chart3.Series[logic.IrisSpecs[2]].IsValueShownAsLabel = true;
                chart4.Series[logic.IrisSpecs[3]].IsValueShownAsLabel = true;

                chartPie.Series["Distance"].IsValueShownAsLabel = true;

                double[][] avg = new double[12][];
                for (int i = 0; i < 3; i++)
                {
                    avg[i] = new double[4];
                    for (int j = 0; j <4; j++)
                    {
                        avg[i][j] = logic.CalculateAverage(logic.MakeArrVector(i))[j];
                    }
                }

                for (int i = 0; i < 3; i++)
                {
                    chart1.Series[logic.IrisSpecs[0]].Points.AddXY(logic.IrisSpecies[i], avg[i][0]);
                    chart2.Series[logic.IrisSpecs[1]].Points.AddXY(logic.IrisSpecies[i], avg[i][0]);
                    chart3.Series[logic.IrisSpecs[2]].Points.AddXY(logic.IrisSpecies[i], avg[i][0]);
                    chart4.Series[logic.IrisSpecs[3]].Points.AddXY(logic.IrisSpecies[i], avg[i][0]);
                    
                }

                //pie chart
                string a = logic.IrisSpecies[0];
                string b = logic.IrisSpecies[1];
                string c = logic.IrisSpecies[2];
                chartPie.Series["Distance"].Points.AddXY($"{a} - {b}", logic.CalculateDistance(avg)[0]);
                chartPie.Series["Distance"].Points.AddXY($"{a} - {c}", logic.CalculateDistance(avg)[1]);
                chartPie.Series["Distance"].Points.AddXY($"{b} - {c}", logic.CalculateDistance(avg)[2]);
            }
            catch(FileFormatException)
            {
                MessageBox.Show("Некорректное содержимое файла");
            }
            catch(FileNotFoundException)
            {
                MessageBox.Show("Пустой путь к файлу");
            }
            catch(FileLoadException)
            {
                MessageBox.Show("Превышена допустимая размерность файла");
            }

            
        }
    }
}
