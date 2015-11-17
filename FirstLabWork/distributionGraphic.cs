using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using ZedGraph;

namespace FirstLabWork
{
	public partial class CheckDistributionForm : Form
	{
        Func<double, double> getLaplasFuncValue;
		public CheckDistributionForm()
		{
			InitializeComponent();
		}

        public void drawNormalDistribution(double dispertion, double sq, double m)
        {
            double leftBorder = 0, rightBorder = 0;
            leftBorder = m - 3 * sq;
            rightBorder = m + 3 * sq;
            double step = 6 * sq / 20;
            double currentPosition = leftBorder;
            double coeff = 2;
            if (leftBorder < 0)
                coeff = 1;
            SortedDictionary<double, double> distr = new SortedDictionary<double, double>();
            for (int i = 0; i < 20; i++)
            {
                double firstFraction = 1/(sq*Math.Sqrt(2*Math.PI));
                double expValueNum = Math.Pow((currentPosition-m),2);
                double expValueDen = 2*dispertion;
                double expValue=-expValueNum/expValueDen;
                distr.Add(currentPosition, firstFraction*Math.Exp(expValue));
                currentPosition += step;
            }
            draw_distribution(distr, "График теоретической плотности распределения", m, sq, Color.FromArgb(255, 255, 255, 0));
            graphTheor.GraphPane.Title.Text = "Полигон отн. частот и график плотности нормального распределения";
        }

        public void drawExpDistribution(double dispertion, double sq, double m)
        {
            double leftBorder = 0, rightBorder = 0;
            rightBorder = m + 5 * dispertion;
            double step = 10 * dispertion / 20;
            double currentPosition = leftBorder;
            SortedDictionary<double, double> distr = new SortedDictionary<double, double>();
            double lambda = 1/m;
            for (int i = 0; i < 20; i++)
            {
                distr.Add(currentPosition, lambda*Math.Pow(Math.E,-lambda*currentPosition));
                currentPosition += step;
            }
            draw_distribution(distr, "График теоретической плотности распределения", m, sq, Color.FromArgb(255,255,0,0));
            graphTheor.GraphPane.Title.Text = "Полигон отн. частот и график плотности показательного распределения";
        }
		#region GRAPHICS

		//Строит график
        public void draw_distribution(SortedDictionary<double, double> distr, String distLabel, double m, double sq, Color color)
		{
            setup_graph(graphTheor);
            
			//Построение полигона
            var pane = graphTheor.GraphPane;
			SymbolType type = SymbolType.Default;
			if (distr.Count > 20) type = SymbolType.None;
			var curve = pane.AddCurve("", dictionaryToList(distr), color,type);
            graphTheor.AxisChange();
            graphTheor.Invalidate();
		}

		//Преобразует словарь в набор точек
        PointPairList dictionaryToList(SortedDictionary<double, double> data)
		{
			var list = new PointPairList();
			foreach (var x in data) list.Add(x.Key, x.Value);
			return list;
		}

		//Настройки графика
		void setup_graph(ZedGraph.ZedGraphControl graph)
		{
            var pane = graphTheor.GraphPane;
			pane.YAxis.Title.Text = "y";
			pane.X2Axis.Title.Text = "x";

			//Настраиваем пересечение осей
			pane.XAxis.Cross = 0.0;
			pane.YAxis.Cross = 0.0;
			pane.XAxis.Scale.IsSkipFirstLabel = true;
			pane.XAxis.Scale.IsSkipLastLabel = true;
			pane.XAxis.Scale.IsSkipCrossLabel = true;
			pane.YAxis.Scale.IsSkipFirstLabel = true;
			pane.YAxis.Scale.IsSkipLastLabel = true;
			pane.YAxis.Scale.IsSkipCrossLabel = true;

			//Убираем засечки сверху и снизу
			pane.XAxis.MinorTic.IsOpposite = false;
			pane.XAxis.MajorTic.IsOpposite = false;
			pane.YAxis.MinorTic.IsOpposite = false;
			pane.YAxis.MajorTic.IsOpposite = false;

			graph.AxisChange();
			graph.Invalidate();
		}
		#endregion
	}
}
