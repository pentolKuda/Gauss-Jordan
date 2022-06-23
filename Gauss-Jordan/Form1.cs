using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gauss_Jordan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int matrixSize;
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                matrixSize = int.Parse(tbInputNumber.Text);
            }
            catch
            {
                MessageBox.Show("Masukkan nilai dengan benar!");
                return;
            }
            tbInputNumber.Text = "";

            label6.Text = matrixSize.ToString() + " X " + matrixSize.ToString();

            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Clear();

            //pertanyaan
            for (int i = 0; i <= matrixSize; i++)
            {
                var column = new DataGridViewColumn();
                column.HeaderText = (i == matrixSize ? "Y" : "X" + (i+1).ToString());
                column.CellTemplate = new DataGridViewTextBoxCell();
                column.Width = 30;
                dataGridView1.Columns.Add(column);

                if (i != matrixSize)
                {
                    dataGridView1.Rows.Add();
                }
            }

            //jawaban
            for (int i = 0; i < matrixSize; i++)
            {
                var colX1 = new DataGridViewColumn();
                colX1.HeaderText = "X"+(i+1).ToString();
                colX1.CellTemplate = new DataGridViewTextBoxCell();
                colX1.Width = 70;
                dataGridView2.Columns.Add(colX1);
                
            }
            dataGridView2.Rows.Add();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            double[][] x_eq = new double[matrixSize][];
            double[] y_eq = new double[matrixSize];
            //double[] r_eq = new double[matrixSize];

            for (int i = 0; i < matrixSize; i++)
            {
                x_eq[i] = new double[matrixSize+1];
                for (int j = 0; j < matrixSize+1; j++)
                {
                    x_eq[i][j] = double.Parse((string)dataGridView1.Rows[i].Cells[j].Value);
                    Console.Write(x_eq[i][j] + "\t");
                }
                
                Console.WriteLine();
            }

            

            for(int i=0; i< matrixSize; i++)
            {
                x_eq =  get_one(x_eq, i);
                for(int j=0; j< matrixSize; j++)
                {
                    if(i != j)
                    {
                        x_eq =  get_zero(x_eq,j, i);
                    }
                }
            }

            for (int i = 0; i < matrixSize; i++)
            {
                for(int j=0; j< matrixSize+1; j++)
                {
                    Console.Write(x_eq[i][j]);
                }
                Console.WriteLine();
            }

            for (int i = 0; i < matrixSize; i++)
            {
                dataGridView2.Rows[0].Cells[i].Value = x_eq[i][matrixSize];
            }

        }


        private double[][] get_one(double[][] mat, int pp)
        {
            int mat_size = mat[0].GetLength(0);

            for(int i=0; i < mat_size; i++)
            {
                if(mat[pp][pp] != 1)
                {
                    double q00 = mat[pp][pp];
                    for(int j = 0; j<mat_size; j++)
                    {
                        mat[pp][j] = mat[pp][j] / q00;
                    }
                }
            }
            return mat;
        }

        private double[][] get_zero(double[][] mat, int r, int c)
        {
            int mat_size = mat[0].GetLength(0);

            for(int i=0; i<mat_size; i++)
            {
                if (mat[r][c] != 0)
                {
                    double q04 = mat[r][c];
                    for(int j=0; j<mat_size; j++)
                    {
                        mat[r][j] = mat[r][j] - ((q04) * mat[c][j]);
                    }
                }
            }

            return mat;
        }


    }
}
