using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ChartsVisualisation.Presenter;
using ChartsVisualisation.View;

namespace ChartsVisualisation
{
    public partial class Form1 : Form, IView
    {
        ChartsPresenter presenter;
        public Form1()
        {
            InitializeComponent();
            presenter = new ChartsPresenter(this);
        }

        private void OverviewButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV files (*.csv)|*.csv";
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;

            presenter.Path = openFileDialog.FileName;
            presenter.LoadFileName();
        }

        private void LaunchButton_Click(object sender, EventArgs e)
        {
            presenter.ProcessFile();           
        }


        public string DisplayPath { set => filePath.Text = value; }
        public void DisplayError(string errorText)
        {
            MessageBox.Show(errorText);
        }

        public void SetGraphs(List<List<double>> averages, List<double> distances, List<string> species, List<string> specs)
        {
            try
            {
                chart1.Series[specs[0]].Points.Clear();
                chart2.Series[specs[1]].Points.Clear();
                chart3.Series[specs[2]].Points.Clear();
                chart4.Series[specs[3]].Points.Clear();
                chartPie.Series["Distance"].Points.Clear();
            }
            catch (ArgumentException)
            { }

            try
            {
                chart1.Series.Add(specs[0]);
                chart2.Series.Add(specs[1]);
                chart3.Series.Add(specs[2]);
                chart4.Series.Add(specs[3]);
            }
            catch (ArgumentException)
            { }

            chart1.Series[specs[0]].IsValueShownAsLabel = true;
            chart2.Series[specs[1]].IsValueShownAsLabel = true;
            chart3.Series[specs[2]].IsValueShownAsLabel = true;
            chart4.Series[specs[3]].IsValueShownAsLabel = true;

            chartPie.Series["Distance"].IsValueShownAsLabel = true;

            for (int i = 0; i < 3; i++)
            {
                chart1.Series[specs[0]].Points.AddXY(species[i], averages[i][0]);
                chart2.Series[specs[1]].Points.AddXY(species[i], averages[i][1]);
                chart3.Series[specs[2]].Points.AddXY(species[i], averages[i][2]);
                chart4.Series[specs[3]].Points.AddXY(species[i], averages[i][3]);
            }

            chartPie.Series["Distance"].Points.AddXY($"{species[0]} - {species[1]}", distances[0]);
            chartPie.Series["Distance"].Points.AddXY($"{species[0]} - {species[2]}", distances[1]);
            chartPie.Series["Distance"].Points.AddXY($"{species[1]} - {species[3]}", distances[2]);
        }
    }
}
