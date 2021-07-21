using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;

namespace FirstProject.MathildaRevenue
{
    static class Data
    {
        public static readonly string TempFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\RieBi\Temp";
        public static string FileFolder { get; set; } = null;

        public static List<int> TotalMoney { get; set; } = null;
        public static List<int> CupcakesBasic { get; set; } = null;
        public static List<int> CupcakesDelux { get; set; } = null;
        public static Series[] DataSeries { get; set; } = new Series[3];


        public static void LoadFromZip(string path)
        {
            // Extract from zip
            if (Directory.Exists(TempFolder)) Directory.Delete(TempFolder, true);
            Directory.CreateDirectory(TempFolder);
            ZipFile.ExtractToDirectory(path, TempFolder);

            // Get file directory
            if (Directory.GetDirectories(TempFolder).Length > 0)
            {
                FileFolder = Directory.GetDirectories(TempFolder)[0];
            }
            else
            {
                throw new IOException("Directory is not found");
            }

            // Proccessing files
            string[] filenames = { "Total.txt", "Basic.txt", "Delux.txt" };
            if (!filenames.All((n) => File.Exists(FileFolder + @"\" + n)))
            {
                throw new IOException("Not all files are found");
            }

            // Filling lists with file data
            try
            {
                TotalMoney = ParseFile(@$"{FileFolder}\Total.txt");
                CupcakesBasic = ParseFile(@$"{FileFolder}\Basic.txt");
                CupcakesDelux = ParseFile(@$"{FileFolder}\Delux.txt");
                TotalMoney.Reverse();
                CupcakesBasic.Reverse();
                CupcakesDelux.Reverse();
            }
            catch (IOException)
            {
                throw new IOException("Files data is in incorrect format");
            }
            Load();
        }
        static void Load()
        {
            InitializeSeries();
        }
        public static void UnLoad()
        {
            if (Directory.Exists(TempFolder)) Directory.Delete(TempFolder, true);
        }
        public static List<int> ParseFile(string path)
        {
            using StreamReader reader = new StreamReader(path);
            var list = new List<int>();
            reader.ReadLine();
            while (!reader.EndOfStream)
            {
                list.Add(int.Parse(reader.ReadLine()));
            }
            return list;
        }
        static void InitializeSeries()
        {
            static Series CreateSeries(List<int> list, int days)
            {
                var series = new Series();
                if (list.Count < days) days = list.Count;
                for (int i = 0; i < days; i++)
                {
                    series.Points.Add(new DataPoint(i + 1, list[i]));
                }
                series.ChartType = SeriesChartType.Line;
                return series;
            }
            const int ChartLengthInDays = 365;
            DataSeries[0] = CreateSeries(TotalMoney, ChartLengthInDays);
            DataSeries[1] = CreateSeries(CupcakesBasic, ChartLengthInDays);
            DataSeries[2] = CreateSeries(CupcakesDelux, ChartLengthInDays);
        }
    }
}
