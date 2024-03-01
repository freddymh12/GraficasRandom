using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Windows.Forms.DataVisualization.Charting;

namespace GraficasRandom
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {

        Thread hilo1;
        Thread hilo2;

        public void Grafica1()
        {

            while (true)
            {
                Series s1 = new Series("Grados");
                s1.ChartType = SeriesChartType.Column;

                if (chart1.InvokeRequired)
                {
                    chart1.Invoke(new MethodInvoker(delegate
                    {
                        chart1.Series.Clear();
                        chart1.Series.Add(s1);

                    }));
                }
                else
                {
                    chart1.Series.Clear();
                    chart1.Series.Add(s1);
                }
                for (int i = 0; i < 100; i++)
                {
                    Random numeroAleatorio = new Random();
                    int numero = numeroAleatorio.Next(1, 45);

                    if (chart1.InvokeRequired)
                    {
                        chart1.Invoke(new MethodInvoker(delegate
                        {
                            chart1.Series["Grados"].Points.AddY(numero);
                            chart1.Series["Grados"].Points[i].AxisLabel = i.ToString();
                            chart1.Series["Grados"].YValueType = ChartValueType.String;
                            chart1.Series["Grados"].Points[i].Label = numero.ToString();

                        }));
                    }
                    else
                    {
                        chart1.Series["Grados"].Points.AddXY(numero);
                        chart1.Series["Grados"].Points[1].AxisLabel = i.ToString();
                        chart1.Series["Grados"].YValueType = ChartValueType.String;
                        chart1.Series["Grados"].Points[i].Label = numero.ToString();
                    }
                }
                if (metroLabel2.InvokeRequired)
                {
                    chart1.Invoke(new MethodInvoker(delegate
                    {
                        metroLabel2.Text = DateTime.Now.ToString();

                    }));
                }
                else
                {

                }

                Thread.Sleep(5000);
            }
            

        }

        public void Grafica2()
        {
            while (true)
            {

                Random rn = new Random();
                int numeroRandom = rn.Next(1, 100);
                int x = numeroRandom;
                int y = 100 - numeroRandom;

                if (chart2.InvokeRequired)
                {
                    chart1.Invoke(new MethodInvoker(delegate
                    {
                        chart2.Series.Clear();
                        chart2.BackColor = Color.Transparent;
                        Series serie1 = new Series
                        {
                            Name = "Grados",
                            IsVisibleInLegend = false,
                            Color = System.Drawing.Color.Green,
                            ChartType = SeriesChartType.Pie
                        };
                        chart2.Series.Add(serie1);
                        serie1.Points.Add(x);
                        serie1.Points.Add(y);

                    }));
                }
                else
                {
                    chart2.Series.Clear();
                    chart2.BackColor = Color.Transparent;
                    Series serie1 = new Series
                    {
                        Name = "Grados",
                        IsVisibleInLegend = false,
                        Color = System.Drawing.Color.Green,
                        ChartType = SeriesChartType.Pie
                    };
                    chart2.Series.Add(serie1);
                    serie1.Points.Add(x);
                    serie1.Points.Add(y);
                }
                if (metroLabel3.InvokeRequired)
                {
                    chart1.Invoke(new MethodInvoker(delegate
                    {
                        metroLabel3.Text = DateTime.Now.ToString();

                    }));
                }
                else
                {

                }

                Thread.Sleep(5000);
            }
    }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            hilo1 = new Thread(new ThreadStart(Grafica1));
            hilo1.Start();
            hilo2 = new Thread(new ThreadStart(Grafica2));
            hilo2.Start();



        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
