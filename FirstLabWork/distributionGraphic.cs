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
		public CheckDistributionForm(Func<double,double> getLaplas)
		{
			InitializeComponent();
            getLaplasFuncValue = getLaplas;
		}

        public void drawNormalDistribution(double dispertion, double sq, double m)
        {
            double leftBorder = 0, rightBorder = 0;
            leftBorder = m - 3 * sq;
            rightBorder = m + 3 * sq;
            double step = 6 * sq / 20;
            double currentPosition = leftBorder;
            Dictionary<double, double> distr=new Dictionary<double,double>();
            for (int i = 0; i < 20; i++)
            {
                distr.Add(currentPosition, (1/sq*Math.Sqrt(2*Math.PI))*Math.Pow(Math.E,-Math.Pow(currentPosition-m,2)/(2*Math.Pow(sq,2))));
                currentPosition += step;
            }
            draw_distribution(distr, "График теоретической плотности распределения",m,sq);
        }
		#region GRAPHICS

		//Строит график
		public void draw_distribution( Dictionary<double, double> distr,String distLabel,double m,double sq)
		{
            setup_graph(graphTheor);

			//Построение полигона
            var pane = graphTheor.GraphPane;
			SymbolType type = SymbolType.Default;
			if (distr.Count > 20) type = SymbolType.None;
			var curve = pane.AddCurve("", dictionaryToList(distr), Color.FromArgb(255, 39, 174, 96),type);
            graphTheor.AxisChange();
            graphTheor.Invalidate();
		}

		//Преобразует словарь в набор точек
		PointPairList dictionaryToList(Dictionary<double, double> data)
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
