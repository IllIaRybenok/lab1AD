using System.Drawing;
using System.Globalization;
using System.Net.Sockets;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms.VisualStyles;
using MathNet.Numerics.Distributions;
using MathNet.Numerics.Integration;
using MathNet.Numerics.Statistics;
using static System.Formats.Asn1.AsnWriter;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace Lab1AD
{
    public partial class Form1 : Form
    {
        double[] data;
        (double, double)[] classes;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        //Пошук файлу, отримання даних, відображення вибірки
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1 = new();
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|DAT files(*.DAT)|*.DAT";
            openFileDialog1.InitialDirectory = "C:\\Users\\Илья\\Desktop\\textFiles";
            openFileDialog1.Title = "Обрати файл";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            Clear();
            string filePath = openFileDialog1.FileName;
            textBox1.Text = filePath;

            try
            {
                string fileContent = File.ReadAllText(filePath);
                data = ConvertFileContentArray(fileContent);
                listBox1.Items.Clear();
                foreach (double value in data)
                {
                    listBox1.Items.Add(value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Під час виконання файла виникла помилка: {ex.Message}");
            }

            if (checkBox1.Checked)
            {
                button2_Click(sender, e);
                button3_Click(sender, e);
                button4_Click(sender, e);
                button5_Click(sender, e);
                button6_Click(sender, e);
                button7_Click(sender, e);
            }

        }

        //Створення таблиці варіаційного ряду
        private void button2_Click(object sender, EventArgs e)
        {
            CreateVariationSeriesTable();
        }

        //Створення таблиці класів
        private void button3_Click(object sender, EventArgs e)
        {
            CreateClassesTable();
        }

        //Зміна кількості класів користувачем
        private void button4_Click(object sender, EventArgs e)
        {
            button3_Click(sender, e);
        }

        //Ідентифікація нормального розподілу через кф. ексцесу та асиметрії
        private void button5_Click(object sender, EventArgs e)
        {
            IdentificationNormalDist();
        }

        //Ідентифікація нормального розподілу через ймовірнісний папір
        private void button6_Click(object sender, EventArgs e)
        {
            IdentificationNormalDistProbPaper();
        }

        //Знаходження аномалій в даних
        private void button7_Click(object sender, EventArgs e)
        {
            SearchOutliers();
        }

        //Видалення аномалій, оновлення даних та інформації про дані
        private void button8_Click(object sender, EventArgs e)
        {
            SearchOutliers(true);
            Update(sender, e);
        }
        
        //Зміна ширина вікна користувачем
        private void button9_Click(object sender, EventArgs e)
        {
            button3_Click(sender, e);
        }

        //Зчитування та інтерпретація даних з файлу у масив
        private double[] ConvertFileContentArray(string content)
        {
            return content
                .Split('\n', ' ')
                .Select(line => Convert.ToDouble(line, CultureInfo.InvariantCulture))
                .ToArray();
        }

        //Створення таблиці варіаційного ряду
        private void CreateVariationSeriesTable()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("№", "№");
            dataGridView1.Columns.Add("Значення варіанти", "Значення варіанти");
            dataGridView1.Columns.Add("Частота", "Частота");
            dataGridView1.Columns.Add("Відносна частота", "Відносна частота");
            dataGridView1.Columns.Add("Значення емпіричної функції розподілу", "Значення емпіричної функції розподілу");

            dataGridView1.Rows.Clear();

            int frequency = 0;
            double relativeFrequency = 0;
            double empiricalFunction = 0;
            double cumulativeFrequency = 0;

            double[] uniqueData = data.Distinct().OrderBy(v => v).ToArray();

            foreach (double value in uniqueData)
            {
                frequency = data.Count(v => v == value);
                relativeFrequency = (double)frequency / data.Length;
                cumulativeFrequency += frequency;
                empiricalFunction = (double)cumulativeFrequency / data.Length;
                dataGridView1.Rows.Add(0, value, frequency, relativeFrequency, empiricalFunction);
            }
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells["№"].Value = i + 1;
            }

            CreateEmpiricalFunc();
            CreateAssessmentsTable();
        }

        //Створення таблиці класів
        private void CreateClassesTable()
        {
            int M;
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                M = (int)(1.0 + 3.32 * Math.Log(data.Length, 10.0));
            }
            else
            {
                M = int.Parse(textBox2.Text);
            }
            double xMin = data.Min();
            double xMax = data.Max();
            double h = (xMax - xMin) / M;
            classes = new (double, double)[M];

            for (int i = 0; i < classes.Length; i++)
            {
                if (i == 0)
                {
                    classes[i].Item1 = xMin;
                    classes[i].Item2 = xMin + h;
                }
                else if (i == classes.Length - 1)
                {
                    classes[i].Item1 = classes[i - 1].Item2;
                    classes[i].Item2 = xMax;
                }
                else
                {
                    classes[i].Item1 = classes[i - 1].Item2;
                    classes[i].Item2 = classes[i].Item1 + h;
                }
            }

            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("№", "№");
            dataGridView1.Columns.Add("Клас", "Клас");
            dataGridView1.Columns.Add("Частота", "Частота");
            dataGridView1.Columns.Add("Відносна частота", "Відносна частота");
            dataGridView1.Columns.Add("Значення емпіричної функції розподілу", "Значення емпіричної функції розподілу");

            int frequency = 0;
            double relativeFrequency = 0;
            double empiricalFunction = 0;
            int num = 1;
            double cumulativeFrequency = 0;
            string interval;
            double maxRelativeFrequency = 0;

            foreach ((double, double) c in classes)
            {
                if (classes.Last() == c)
                {
                    interval = $"[{c.Item1:F2}; {c.Item2:F2}]";
                    frequency = data.Count(v => v >= c.Item1 && v <= c.Item2);
                }
                else
                {
                    interval = $"[{c.Item1:F2}; {c.Item2:F2})";
                    frequency = data.Count(v => v >= c.Item1 && v < c.Item2);
                }
                relativeFrequency = (double)frequency / data.Length;
                cumulativeFrequency += frequency;
                empiricalFunction = (double)cumulativeFrequency / data.Length;
                dataGridView1.Rows.Add(num, interval, frequency, relativeFrequency, empiricalFunction);
                maxRelativeFrequency = Math.Max(maxRelativeFrequency, relativeFrequency);
                num++;
            }
            chart1.Titles.Clear();
            chart1.Titles.Add("Гістограма та ядерна оцінка щільності");
            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Minimum = classes.Min().Item1;
            chart1.ChartAreas[0].AxisX.Maximum = classes.Max().Item2;
            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "F2";
            chart1.ChartAreas[0].AxisY.LabelStyle.Format = "F2";

            chart1.ChartAreas[0].AxisX.LabelStyle.IsEndLabelVisible = true;
            CreateHistogram(h);
            AddKDEFunc(maxRelativeFrequency);
        }

        //Створення гістограми класів
        private void CreateHistogram(double h)
        {
            chart1.Series.Clear();

            Series seriesHistogram = new Series
            {
                ChartType = SeriesChartType.RangeColumn,
                IsValueShownAsLabel = true,
                IsVisibleInLegend = false,
                LabelFormat = "F2"
            };
            chart1.Series.Add(seriesHistogram);

            int frequency = 0;
            double relativeFrequency = 0;

            foreach ((double, double) c in classes)
            {
                if (classes.Last() == c)
                {
                    frequency = data.Count(v => v >= c.Item1 && v <= c.Item2);
                }
                else
                {
                    frequency = data.Count(v => v >= c.Item1 && v < c.Item2);
                }

                relativeFrequency = (double)frequency / data.Length;
                DataPoint dataPoint = new((c.Item1 + c.Item2) / 2.0, relativeFrequency/h);
                seriesHistogram.Points.Add(dataPoint);
            }

            chart1.ChartAreas[0].AxisX.Title = "x";
            chart1.ChartAreas[0].AxisY.Title = "p";

            seriesHistogram["DrawingStyle"] = "Cylinder"; 
            seriesHistogram["PointWidth"] = "1.0";
        }

        //Створення ядерної оцінки та додавання її графіку до гістограми
        private void AddKDEFunc(double maxRelativeFrequency)
        {
            double b;
            int N = data.Length;
            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                double mean = data.Mean();
                double variance = data.Variance();
                double standartDeviation = data.StandardDeviation();
                b = standartDeviation * Math.Pow(N, -1.0 / 5.0);
            }
            else
            {
                b = Convert.ToDouble(textBox4.Text, CultureInfo.InvariantCulture);
            }

            Series seriesKDE = new Series
            {
                ChartType = SeriesChartType.Line,
                Color = Color.Red,
                IsVisibleInLegend = false,
                BorderWidth = 2
            };

            chart1.Series.Add(seriesKDE);

            double[] sortedData = data.OrderBy(x => x).ToArray();

            double x = 0.0;
            double sumK = 0.0;
            double u = 0.0;
            double K = 0.0;
            double KDE = 0.0;
            double[] KDEValues = new double[N];
            double maxKDEValue = 0.0;

            for(int i =0; i<N; ++i)
            {
                x = sortedData[i];
                sumK = 0.0;
                foreach (double xi in data)
                {
                    u = (x - xi) / b;
                    K = 1.0 / Math.Sqrt(2.0 * Math.PI) * Math.Exp(-0.5 * u * u);
                    sumK += K;
                }
                KDE = sumK / (N * b);
                KDEValues[i] = KDE;
                maxKDEValue = Math.Max(maxKDEValue, KDE);
            }

            //double scale = maxRelativeFrequency / maxKDEValue;
            for (int i = 0;i<N; ++i)
            {
                seriesKDE.Points.AddXY(sortedData[i], KDEValues[i]);
            }
        }

        //Створення емпіричної функції та побудова її графіку
        private void CreateEmpiricalFunc()
        {
            chart2.Series.Clear();
            chart2.Titles.Clear();
            chart2.Titles.Add("Емпірична функція розподілу");
            Series seriesEmpiricalFunc = new Series
            {
                ChartType = SeriesChartType.StepLine,
                Color = Color.Green,
                IsVisibleInLegend = false,
                BorderWidth = 2
            };
            chart2.Series.Add(seriesEmpiricalFunc);

            int frequency = 0;
            double relativeFrequency = 0;
            double empiricalFunction = 0;
            double cumulativeFrequency = 0;

            double[] uniqueData = data.Distinct().OrderBy(v => v).ToArray();
            foreach (double value in uniqueData)
            {
                frequency = data.Count(v => v == value);
                relativeFrequency = (double)frequency / data.Length;
                cumulativeFrequency += frequency;
                empiricalFunction = (double)cumulativeFrequency / data.Length;

                DataPoint dataPoint = new(value, empiricalFunction);
                seriesEmpiricalFunc.Points.Add(dataPoint);
            }

            chart2.ChartAreas[0].AxisY.Maximum = 1;
            chart2.ChartAreas[0].AxisX.Maximum = data.Max();
            chart2.ChartAreas[0].AxisX.LabelStyle.Format = "F2";
            chart2.ChartAreas[0].AxisX.Title = "x";
            chart2.ChartAreas[0].AxisY.Title = "F(x)";
        }

        //Створення таблиці оцінок кількісних характеристик
        private void CreateAssessmentsTable()
        {

            dataGridView2.Columns.Clear();
            dataGridView2.Columns.Add("Характеристика", "Характеристика");
            dataGridView2.Columns.Add("Оцінка", "Оцінка");
            dataGridView2.Columns.Add("Середньоквадратичне відхилення оцінки", "Середньоквадратичне відхилення оцінки");
            dataGridView2.Columns.Add("95% довірчий інтервал для характеристики", "95% довірчий інтервал для характеристики");
            dataGridView2.Columns[0].ReadOnly = true;

            dataGridView2.Rows.Add(7);
            dataGridView2.Rows[0].Cells[0].Value = "Середнє арифметичне";
            dataGridView2.Rows[1].Cells[0].Value = "Медіана";
            dataGridView2.Rows[2].Cells[0].Value = "Середньоквадратичне відхилення";
            dataGridView2.Rows[3].Cells[0].Value = "Коефіцієнт асиметрії";
            dataGridView2.Rows[4].Cells[0].Value = "Коефіцієнт ексцесу";
            dataGridView2.Rows[5].Cells[0].Value = "Мінімум";
            dataGridView2.Rows[6].Cells[0].Value = "Максимум";

            double mean = data.Average();
            double median = data.Median();
            double standartDeviation = data.StandardDeviation();
            double skewness = data.Skewness();
            double kurtosis = data.Kurtosis();
            double min = data.Min();
            double max = data.Max();
            int N = data.Length;

            dataGridView2.Rows[0].Cells[1].Value = mean.ToString("F2");
            dataGridView2.Rows[1].Cells[1].Value = data.Contains(median)? median : median.ToString("F2");
            dataGridView2.Rows[2].Cells[1].Value = standartDeviation.ToString("F2");
            dataGridView2.Rows[3].Cells[1].Value = skewness.ToString("F2");
            dataGridView2.Rows[4].Cells[1].Value = kurtosis.ToString("F2");
            dataGridView2.Rows[5].Cells[1].Value = min;
            dataGridView2.Rows[6].Cells[1].Value = max;

            double stdDevOfMean = standartDeviation / Math.Sqrt(N);
            double stdDevOfStdDev = standartDeviation / Math.Sqrt(2 * N);
            double stdDevOfSkewness = Math.Sqrt((6.0 * (N - 2.0)) / ((N + 1.0) * (N + 3.0)));
            double stdDevOfKurtosis = Math.Sqrt((24.0 * N * (N - 2) * (N - 3)) / (Math.Pow((N + 1.0), 2) * (N + 3.0) * (N + 5.0)));

            dataGridView2.Rows[0].Cells[2].Value = stdDevOfMean.ToString("F2");
            dataGridView2.Rows[2].Cells[2].Value = stdDevOfStdDev.ToString("F2");
            dataGridView2.Rows[3].Cells[2].Value = stdDevOfSkewness.ToString("F2");
            dataGridView2.Rows[4].Cells[2].Value = stdDevOfKurtosis.ToString("F2");

            double begin = mean - 1.96 * stdDevOfMean;
            double end = mean + 1.96 * stdDevOfMean;
            string intervalOfMean = $"[{begin:F2};{end:F2}]";

            int j = (int)(N / 2.0 - 1.96 * Math.Sqrt(N) / 2.0);
            int k = (int)(N / 2.0 + 1.0 + 1.96 * Math.Sqrt(N) / 2.0);
            begin = data.OrderBy(x => x).ToArray()[j];
            end = data.OrderBy(x => x).ToArray()[k];
            string intervalOfMedian = $"[{begin:F2};{end:F2}]";

            begin = standartDeviation - 1.96 * stdDevOfStdDev;
            end = standartDeviation + 1.96 * stdDevOfStdDev;
            string intervalOfStd = $"[{begin:F2};{end:F2}]";

            begin = skewness - 1.96 * stdDevOfSkewness;
            end = skewness + 1.96 * stdDevOfSkewness;
            string intervalOfSkewness = $"[{begin:F2};{end:F2}]";

            begin = kurtosis - 1.96 * stdDevOfKurtosis;
            end = kurtosis + 1.96 * stdDevOfKurtosis;
            string intervalOfKurtosis = $"[{begin:F2};{end:F2}]";


            dataGridView2.Rows[0].Cells[3].Value = intervalOfMean;
            dataGridView2.Rows[1].Cells[3].Value = intervalOfMedian;
            dataGridView2.Rows[2].Cells[3].Value = intervalOfStd;
            dataGridView2.Rows[3].Cells[3].Value = intervalOfSkewness;
            dataGridView2.Rows[4].Cells[3].Value = intervalOfKurtosis;

            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.RowHeadersVisible = false;
            dataGridView2.AllowUserToAddRows = false;
        }

        //Ідентифікування нормального розподілу та виведення результату у текст. вигляді
        private void IdentificationNormalDist()
        {
            double skewness = data.Skewness();
            double kurtosis = data.Kurtosis();
            int N = data.Length;
            double stdDevOfSkewness = Math.Sqrt((6.0 * (N - 2.0)) / ((N + 1.0) * (N + 3.0)));
            double stdDevOfKurtosis = Math.Sqrt((24.0 * N * (N - 2) * (N - 3)) / (Math.Pow((N + 1.0), 2) * (N + 3.0) * (N + 5.0)));
            double uA = skewness / stdDevOfSkewness;
            double uE = kurtosis / stdDevOfKurtosis;
            if (Math.Abs(uA) <= 1.96 && Math.Abs(uE) <= 1.96)
            {
                textBox3.Text = "Нормальний розподіл";
                textBox3.ForeColor = Color.Green;
            }
            else
            {
                textBox3.Text = "НЕ нормальний розподіл";
                textBox3.Font = new Font(textBox3.Font, FontStyle.Bold);
                textBox3.ForeColor = Color.Red;
            }
        }

        //Ідентифікування нормального розподілу за ймовірнісним папером (візуально)
        private void IdentificationNormalDistProbPaper()
        {
            chart3.Series.Clear();
            chart3.Titles.Clear();
            chart3.Titles.Add("Ідентифікація нормального розподілу за ймовірнісним папером");

            Series series = new Series
            {
                ChartType = SeriesChartType.Point,
                Color = Color.Blue,
                MarkerStyle = MarkerStyle.Circle,
                IsVisibleInLegend = false,
                BorderWidth = 2
            };
            chart3.Series.Add(series);

            double cumulativeFrequency = 0;

            double[] uniqueData = data.Distinct().OrderBy(v => v).ToArray();

            foreach (double value in uniqueData)
            {
                int frequency = data.Count(v => v == value);
                cumulativeFrequency += frequency;
                double empiricalFunction = cumulativeFrequency / (double)data.Length;
                if (empiricalFunction == 0 || empiricalFunction == 1)
                {
                    continue;
                }
                double z = Normal.InvCDF(0, 1, empiricalFunction);

                DataPoint dataPoint = new(value, z);
                series.Points.Add(dataPoint);
            }

            chart3.ChartAreas[0].AxisX.Title = "x";
            chart3.ChartAreas[0].AxisY.Title = "z";
            chart3.ChartAreas[0].AxisX.LabelStyle.Format = "F2";
            chart3.ChartAreas[0].AxisY.LabelStyle.Format = "F2";

            chart3.ChartAreas[0].RecalculateAxesScale();
        }

        //Знаходження аномалій серед даних
        private void SearchOutliers(bool delete = false)
        {
            chart4.Series.Clear();
            chart4.Titles.Clear();
            chart4.Titles.Add("Пошук аномалій серед даних");
            listBox2.Items.Clear();

            Series seriesOutliers = new Series
            {
                ChartType = SeriesChartType.Point,
                Color = Color.Blue,
                MarkerStyle = MarkerStyle.Circle,
                IsVisibleInLegend = false,
                BorderWidth = 2
            };
            chart4.Series.Add(seriesOutliers);
            double[] sortedData = data.OrderBy(v => v).ToArray();
            int N = sortedData.Length;
            double Q1 = sortedData[(int)(0.25 * (N - 1))];
            double Q3 = sortedData[(int)(0.75 * (N - 1))];
            double k = 2.3;
            double a = Q1 - k * (Q3 - Q1);
            double b = Q3 + k * (Q3 - Q1);
            double[] outliers = data.Where(v => v < a || v > b).ToArray();
            for (int i = 0; i < N; i++)
            {
                seriesOutliers.Points.AddXY(i, data[i]);
            }
            foreach (double outlier in outliers)
            {
                listBox2.Items.Add(outlier);
            }

            Series lowerBoundLine = new Series
            {
                ChartType = SeriesChartType.Line,
                Color = Color.Red,
                BorderDashStyle = ChartDashStyle.Dash,
                BorderWidth = 3,
                IsVisibleInLegend = false
            };

            Series upperBoundLine = new Series
            {
                ChartType = SeriesChartType.Line,
                Color = Color.Red,
                BorderDashStyle = ChartDashStyle.Dash,
                BorderWidth = 3,
                IsVisibleInLegend = false
            };

            for (int i = 0; i < N; i++)
            {
                lowerBoundLine.Points.AddXY(i, a);
                upperBoundLine.Points.AddXY(i, b);
            }

            chart4.Series.Add(lowerBoundLine);
            chart4.Series.Add(upperBoundLine);
            double min = a;
            double max = b;
            if (data.Min() < a)
            {
                min = data.Min();
            }
            if (data.Max() > b)
            {
                max = data.Max();
            }
            chart4.ChartAreas[0].AxisY.Maximum = max;
            chart4.ChartAreas[0].AxisY.Minimum = min;
            chart4.ChartAreas[0].AxisX.LabelStyle.Format = "F2";
            chart4.ChartAreas[0].AxisY.LabelStyle.Format = "F2";

            if (delete)
            {
                if (outliers.Length != 0)
                {
                    data = data.Except(outliers).ToArray();
                }
            }
        }

        //Оновлення всіх компонентів програми, які відповідають за інформацію про дані
        private void Update(object sender, EventArgs e)
        {
            button2_Click(sender, e);
            button3_Click(sender, e);
            button4_Click(sender, e);
            button5_Click(sender, e);
            button6_Click(sender, e);
            button7_Click(sender, e);
        }

        //Очищення інформації про дані у відповідних компонентах програми
        private void Clear()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Clear();
            chart1.Series.Clear();
            chart2.Series.Clear();
            chart3.Series.Clear();
            chart4.Series.Clear();
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }
    }
}
