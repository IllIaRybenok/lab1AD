using System.Windows.Forms.DataVisualization.Charting;

namespace Lab1AD
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            OpenFileDialog openFileDialog1;
            ChartArea chartArea1 = new ChartArea();
            Legend legend1 = new Legend();
            Series series1 = new Series();
            ChartArea chartArea2 = new ChartArea();
            Legend legend2 = new Legend();
            Series series2 = new Series();
            ChartArea chartArea3 = new ChartArea();
            Legend legend3 = new Legend();
            Series series3 = new Series();
            ChartArea chartArea4 = new ChartArea();
            Legend legend4 = new Legend();
            Series series4 = new Series();
            button1 = new Button();
            listBox1 = new ListBox();
            dataGridView1 = new DataGridView();
            button2 = new Button();
            button3 = new Button();
            chart1 = new Chart();
            textBox2 = new TextBox();
            button4 = new Button();
            chart2 = new Chart();
            dataGridView2 = new DataGridView();
            button5 = new Button();
            textBox3 = new TextBox();
            button6 = new Button();
            textBox1 = new TextBox();
            chart3 = new Chart();
            chart4 = new Chart();
            button7 = new Button();
            button8 = new Button();
            checkBox1 = new CheckBox();
            textBox4 = new TextBox();
            button9 = new Button();
            listBox2 = new ListBox();
            label1 = new Label();
            openFileDialog1 = new OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart4).BeginInit();
            SuspendLayout();
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // button1
            // 
            button1.Location = new Point(891, 3);
            button1.Name = "button1";
            button1.Size = new Size(492, 27);
            button1.TabIndex = 1;
            button1.Text = "Обрати файл";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(1389, 43);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(84, 904);
            listBox1.TabIndex = 3;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(891, 209);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(492, 738);
            dataGridView1.TabIndex = 4;
            // 
            // button2
            // 
            button2.Location = new Point(891, 62);
            button2.Name = "button2";
            button2.Size = new Size(492, 51);
            button2.TabIndex = 5;
            button2.Text = "Сформувати варіаційний ряд";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(891, 119);
            button3.Name = "button3";
            button3.Size = new Size(492, 51);
            button3.TabIndex = 6;
            button3.Text = "Розбити варіаційний ряд на класи";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chart1.Legends.Add(legend1);
            chart1.Location = new Point(448, 668);
            chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chart1.Series.Add(series1);
            chart1.Size = new Size(436, 279);
            chart1.TabIndex = 7;
            chart1.Text = "chart1";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(891, 176);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "Кількість класів";
            textBox2.Size = new Size(400, 27);
            textBox2.TabIndex = 8;
            textBox2.TextAlign = HorizontalAlignment.Center;
            // 
            // button4
            // 
            button4.Location = new Point(1297, 176);
            button4.Name = "button4";
            button4.Size = new Size(86, 27);
            button4.TabIndex = 9;
            button4.Text = "Оновити";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // chart2
            // 
            chartArea2.Name = "ChartArea1";
            chart2.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            chart2.Legends.Add(legend2);
            chart2.Location = new Point(7, 668);
            chart2.Name = "chart2";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            chart2.Series.Add(series2);
            chart2.Size = new Size(435, 279);
            chart2.TabIndex = 10;
            chart2.Text = "chart2";
            // 
            // dataGridView2
            // 
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(7, 409);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.Size = new Size(878, 253);
            dataGridView2.TabIndex = 11;
            // 
            // button5
            // 
            button5.Location = new Point(7, 3);
            button5.Name = "button5";
            button5.Size = new Size(599, 27);
            button5.TabIndex = 12;
            button5.Text = "Ідентифікувати нормальний розподіл на основі коефіцієнтів асиметрії та ексцесу";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(612, 3);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(272, 27);
            textBox3.TabIndex = 13;
            // 
            // button6
            // 
            button6.Location = new Point(464, 36);
            button6.Name = "button6";
            button6.Size = new Size(419, 51);
            button6.TabIndex = 14;
            button6.Text = "Ідентифікувати нормальний розподіл на основі ймовірнісного паперу";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(891, 29);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(492, 27);
            textBox1.TabIndex = 16;
            // 
            // chart3
            // 
            chartArea3.Name = "ChartArea1";
            chart3.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            chart3.Legends.Add(legend3);
            chart3.Location = new Point(464, 93);
            chart3.Name = "chart3";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            chart3.Series.Add(series3);
            chart3.Size = new Size(421, 310);
            chart3.TabIndex = 17;
            chart3.Text = "chart3";
            // 
            // chart4
            // 
            chartArea4.Name = "ChartArea1";
            chart4.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            chart4.Legends.Add(legend4);
            chart4.Location = new Point(7, 93);
            chart4.Name = "chart4";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            chart4.Series.Add(series4);
            chart4.Size = new Size(363, 310);
            chart4.TabIndex = 18;
            chart4.Text = "chart4";
            // 
            // button7
            // 
            button7.Location = new Point(7, 36);
            button7.Name = "button7";
            button7.Size = new Size(227, 51);
            button7.TabIndex = 19;
            button7.Text = "Знайти аномальні дані";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.Location = new Point(232, 36);
            button8.Name = "button8";
            button8.Size = new Size(226, 51);
            button8.TabIndex = 20;
            button8.Text = "Видалити аномальні дані";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(1389, 3);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(55, 24);
            checkBox1.TabIndex = 21;
            checkBox1.Text = "Все";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(448, 920);
            textBox4.Name = "textBox4";
            textBox4.PlaceholderText = "Ширина вікна";
            textBox4.Size = new Size(125, 27);
            textBox4.TabIndex = 22;
            textBox4.TextAlign = HorizontalAlignment.Center;
            // 
            // button9
            // 
            button9.Location = new Point(569, 918);
            button9.Name = "button9";
            button9.Size = new Size(79, 29);
            button9.TabIndex = 23;
            button9.Text = "Оновити";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.Location = new Point(376, 119);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(82, 284);
            listBox2.TabIndex = 24;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(376, 93);
            label1.Name = "label1";
            label1.Size = new Size(72, 20);
            label1.TabIndex = 25;
            label1.Text = "Аномалії";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SkyBlue;
            ClientSize = new Size(1485, 948);
            Controls.Add(label1);
            Controls.Add(listBox2);
            Controls.Add(button9);
            Controls.Add(textBox4);
            Controls.Add(checkBox1);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(chart4);
            Controls.Add(chart3);
            Controls.Add(textBox1);
            Controls.Add(button6);
            Controls.Add(textBox3);
            Controls.Add(button5);
            Controls.Add(dataGridView2);
            Controls.Add(chart2);
            Controls.Add(button4);
            Controls.Add(textBox2);
            Controls.Add(chart1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(dataGridView1);
            Controls.Add(listBox1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Аналіз даних | Лабораторна робота №1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ((System.ComponentModel.ISupportInitialize)chart2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)chart3).EndInit();
            ((System.ComponentModel.ISupportInitialize)chart4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button1;
        private ListBox listBox1;
        private DataGridView dataGridView1;
        private Button button2;
        private Button button3;
        private Chart chart1;
        private TextBox textBox2;
        private Button button4;
        private Chart chart2;
        private DataGridView dataGridView2;
        private Button button5;
        private TextBox textBox3;
        private Button button6;
        private OpenFileDialog openFileDialog1;
        private TextBox textBox1;
        private Chart chart3;
        private Chart chart4;
        private Button button7;
        private Button button8;
        private CheckBox checkBox1;
        private TextBox textBox4;
        private Button button9;
        private ListBox listBox2;
        private Label label1;
    }
}
