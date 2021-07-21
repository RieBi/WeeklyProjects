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
        }
        public void InitializeEvents()
        {
            FormClosing += (o, e) => Data.UnLoad();
            ComboBoxChartType.TextChanged += (o, e) => OnComboBoxTextChanged(ComboBoxChartType);
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
        public void OnComboBoxTextChanged(ComboBox box)
        {
            if (!box.Items.Contains(box.Text))
            {
                box.SelectedIndex = 0;
            }
            int index = box.SelectedIndex;
            if (DataChart.Series[0] == Data.DataSeries[index])
            {
                return;
            }

            // Changing chart series
            DataChart.Series[0] = Data.DataSeries[index];
            var area = DataChart.ChartAreas[0];
            area.AxisY.Maximum = DataChart.Series[0].Points.Max((dp) => dp.YValues[0]) * 1.2;

        }
    }
}
