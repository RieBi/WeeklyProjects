using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using System.Data.SqlClient;

namespace FirstProject.MathildaRevenue
{
    public partial class Form1 : Form
    {
        public static Form MainForm;
        private Chart DataChart;
        public Form1()
        {
            InitializeComponent();
            this.Load += (n, m) => Start();
        }
        public void Start()
        {
            MainForm = this;
            InitializeEvents();

            // Try to open data file till the data is in correct format
            while (!OpenDataFile()) { };

            InitializeControls();
            FillRevenueLabels();
        }
        public void InitializeEvents()
        {
            FormClosing += (o, e) => Data.UnLoad();
            ComboBoxChartType.TextChanged += (o, e) => OnChartComboBoxTextChanged();
            ComboBoxChartInterval.TextChanged += (o, e) => OnChartComboBoxTextChanged();
        }
        public void InitializeControls()
        {
            // Chart
            DataChart = CreateChart(FillChartTotalMoney, Data.TotalMoney);
            ChartPanel.Controls.Add(DataChart);

            // Combo boxes
            ComboBoxChartType.SelectedIndex = 0;
        }
        public Chart CreateChart(Control fill, List<int> list)
        {
            Chart chart = new Chart()
            {
                Location = fill.Location,
                Size = fill.Size,
                BackColor = fill.BackColor
            };
            chart.Series.Add(Data.DataSeries[0]);
            var area = chart.ChartAreas.Add("ChartArea");
            chart.Series[0].ChartArea = area.Name;
            area.AxisX.Title = "Time (From Now)";
            area.AxisY.Title = "Amount";

            chart.Tag = -1;
            return chart;
        }
        public bool OpenDataFile()
        {
            try
            {
                var openDialog = new OpenFileDialog
                {
                    Title = "Please, open your data file",
                    Filter = "Archive file (*.zip)|*.zip"
                };
                var result = openDialog.ShowDialog();
                Data.LoadFromZip(openDialog.FileName);
                return true;
            }
            catch (Exception exc)
            {
                MessageBox.Show($"An error occured: [{exc.Message}]. Please, try again.", "Error");
                return false;
            }
        }
        public void OnChartComboBoxTextChanged()
        {
            var typeBox = ComboBoxChartType;
            int typeBoxIndex = typeBox.SelectedIndex;
            var intervalBox = ComboBoxChartInterval;
            int intervalBoxIndex = intervalBox.SelectedIndex;
            // Changing index to 0 if text is invalid
            if (!typeBox.Items.Contains(typeBox.Text))
            {
                typeBox.SelectedIndex = 0;
            }
            if (!intervalBox.Items.Contains(intervalBox.Text))
            {
                intervalBox.SelectedIndex = 0;
            }

            // Changing chart series
            if (DataChart.Series[0].Name != Data.DataSeries[typeBoxIndex].Name || (int)DataChart.Tag != intervalBoxIndex)
            {
                var seriesBase = Data.DataSeries[typeBoxIndex];
                DataChart.Tag = intervalBoxIndex;

                // Creating new series
                switch (intervalBoxIndex)
                {
                    // Last 12 months
                    case 0:
                        DataChart.Series[0] = CreateChunkedSeriesFromSeries(seriesBase, 365, 12);
                        break;
                    // Last 52 weeks
                    case 1:
                        DataChart.Series[0] = CreateChunkedSeriesFromSeries(seriesBase, 365, 52);
                        break;
                    // Last 30 days
                    case 2:
                        DataChart.Series[0] = CreateChunkedSeriesFromSeries(seriesBase, 30, 30);
                        break;
                    // Last 7 days
                    case 3:
                        DataChart.Series[0] = CreateChunkedSeriesFromSeries(seriesBase, 7, 7);
                        break;
                }

                var area = DataChart.ChartAreas[0];
                int maximum = (int)(DataChart.Series[0].Points.Max((dp) => dp.YValues[0]) * 1.2);
                int minimum = (int)(DataChart.Series[0].Points.Min((dp) => dp.YValues[0]) / 1.2);
                minimum = RoundInt(minimum);

                area.AxisY.Maximum = maximum;
                area.AxisY.Minimum = minimum;
                area.AxisY.Interval = RoundInt((maximum - minimum) / 10, false);
                area.AxisY.IntervalAutoMode = IntervalAutoMode.FixedCount;

            }
        }
        public void FillRevenueLabels()
        {
            try
            {
                LabelYearlyTotalMoney.Text += Data.TotalMoney.GetRange(0, 365).Sum();
                LabelMontlyTotalMoney.Text += Data.TotalMoney.GetRange(0, 30).Sum();
                LabelWeeklyTotalMoney.Text += Data.TotalMoney.GetRange(0, 7).Sum();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Failed to calculate revenue totals." +
                    " Please make sure your data file's length contains at least 365 records.", "Error");
            }
        }
        public static int RoundInt(int num, bool zero = true)
        {
            int result;
            if (num < 10 && zero)
            {
                result = 0;
            }
            else
            {
                int mult = num.ToString().Length - 1;
                mult = (int)Math.Pow(10, mult);
                result = num / mult * mult;
            }
            return result;
        }
        public static Series CreateChunkedSeriesFromSeries(Series fill, int length, int parts)
        {
            var list = fill.Points.Select((dp) => dp.YValues[0]).ToList();
            if (list.Count < length)
            {
                length = list.Count / parts * parts;
            }
            else if (list.Count > length)
            {
                list = list.GetRange(0, length);
            }

            List<double> values;
            if (length == parts)
            {
                values = list;
            }
            else
            {
                values = (from l in list.Split(parts) select l.Sum()).ToList();
            }

            Series series = new Series(fill.Name)
            {
                ChartType = fill.ChartType
            };
            for (int i = 0; i < values.Count; i++)
            {
                series.Points.Add(new DataPoint(i + 1, values[i]));
            }
            return series;
        }
    }
    public static class Extensions
    {
        public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> list, int parts)
        {
            int i = 0;
            var splits = from item in list
                         group item by i++ % parts into part
                         select part.AsEnumerable();
            return splits;
        }
    }
}
