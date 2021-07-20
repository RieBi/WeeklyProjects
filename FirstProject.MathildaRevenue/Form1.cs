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
        public Form1()
        {
            InitializeComponent();
            this.Load += (n, m) => Start();
        }
        public void Start()
        {
            MainForm = this;
            InitializeEvents();
            this.Activate();

            // Try to open data file till the data is in correct format
            while (!OpenDataFile()) { };
            var ch = CreateChart(FillChartTotalMoney, Data.TotalMoney);
            ChartPanel.Controls.Add(ch);
        }
        public Chart CreateChart(Control fill, List<int> list)
        {
            Chart chart = new Chart()
            {
                Location = fill.Location,
                Size = fill.Size,
                BackColor = fill.BackColor
            };
            var ser = chart.Series.Add("Series");
            var area = chart.ChartAreas.Add("ChartArea");
            ser.ChartType = SeriesChartType.Column;
            ser.ChartArea = area.Name;
            area.AxisX.Title = "My lovely axis";

            // Filling the chart
            for (int i = 0; i < 365; i++)
            {
                ser.Points.Add(new DataPoint(i + 1, list[i]));
            }
            return chart;
        }
        public void InitializeEvents()
        {
            FormClosing += (o, e) => Data.UnLoad();
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
    }
}
