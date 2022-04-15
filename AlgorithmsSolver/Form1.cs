using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Algorithms;

namespace AlgorithmsSolver
{
    public partial class Form1 : Form
    {
        List<TextBox> textboxes;
        int tempM;
        int tempN;
        Matrix matrixFirst;
        Matrix matrixSecond;

        public Form1()
        {
            textboxes = new List<TextBox>();
            InitializeComponent();
            var intArray = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var intArray2 = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.DataSource = intArray;
            comboBox1.SelectedIndex = 0;

            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DataSource = intArray2;
            comboBox2.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e) // генерирует пустую матрицу
        {
            int m = Convert.ToInt32(comboBox1.SelectedItem);
            tempM = m;
            int n = Convert.ToInt32(comboBox2.SelectedItem);
            tempN = n;
            GenerateMatrix(m, n);
        }

        private void button2_Click(object sender, EventArgs e) // отвечает за запись первой матрицы
        {
            matrixFirst = new Matrix(tempM, tempN, ReadMatrix());
        }

        private void button3_Click(object sender, EventArgs e) // отвечает за запись второй матрицы
        {
            matrixSecond = new Matrix(tempM, tempN, ReadMatrix());
        }

        private void button4_Click(object sender, EventArgs e) // умеожает матрицы и выводмт результат
        {
            try
            {
                double[,] resultArray = matrixFirst.Multiply(matrixSecond);
                PrintMatrix(resultArray, matrixFirst.M, matrixSecond.N);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Запишите матрицы корректно!");
            }
        }

        private void GenerateMatrix(int m, int n)
        {
            CleanPanel();
            int x = 5;
            int y = 10;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    TextBox textBox = new TextBox { Parent = panel1, Location = new Point(x, y), Width = 50, Height = 30 };
                    textboxes.Add(textBox);
                    x += 55;
                }
                x = 5;
                y += 35;
            }
        }

        private void CleanPanel()
        {
            textboxes.Clear();
            panel1.Controls.Clear();
        }

        private double[,] ReadMatrix()
        {
            double[,] matrixArray = new double[tempM, tempN];
            try
            {
                int index = 0;
                for (int m = 0; m < tempM; m++)
                {
                    for (int n = 0; n < tempN; n++)
                    {
                        double value;
                        value = double.Parse(textboxes[index].Text);
                        matrixArray[m, n] = value;
                        index++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Введите значения в типе double");
            }

            MessageBox.Show("Матрица записана");
            return matrixArray;
        }
        private void PrintMatrix(double[,] array, int m, int n)
        {
            GenerateMatrix(m, n);
            int index = 0;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    textboxes[index].Text = array[i, j].ToString();
                    index++;
                }
            }
        }
    }
}
