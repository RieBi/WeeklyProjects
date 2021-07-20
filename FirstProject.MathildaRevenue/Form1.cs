using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FirstProject.MathildaRevenue
{
    public partial class Form1 : Form
    {
        public static Form MainForm;

        public Form1()
        {
            InitializeComponent();
            Start();
        }
        public void Start()
        {
            MainForm = this;
            InitializeEvents();

            // Try to open data file till the data is in correct format
            while (!OpenDataFile()) { };
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
