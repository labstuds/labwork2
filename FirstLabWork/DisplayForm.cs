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
	public partial class DisplayForm : Form
	{
		// Представление ряда частот                
		public static void DisplayStatFreq(SortedDictionary<double, int> data)
		{
			var window = new DisplayForm(data, "Полигон частот", "X_i", "N_i");
			window.Show();
		}

		// Представление ряда относительных частот
		public static void DisplayStatRelFreq(SortedDictionary<double, double> data)
		{
			var window = new DisplayForm(data, "Полигон относительных частот",  "X_i", "W_i");
			window.Show();
		}

        // Представление интервального ряда относительных частот
		public static void DisplayIntervalFreq(SortedDictionary<LinearInterval, double> data)
		{
			var window = new DisplayForm(data, "Гистограмма частот", "X_i", "N_i*");
			window.Show();
		}

        // Представление интервального ряда относительных частот
		public static void DisplayIntervalRelFreq(SortedDictionary<LinearInterval, double> data)
		{
			var window = new DisplayForm(data, "Гистограмма относительных частот", "X_i", "W_i*");
			window.Show();
		}

        // Представление группированного ряда частот
		public static void DisplayGroupFreq(SortedDictionary<double, double> data)
		{
			var window = new DisplayForm(data, "Полигон группированного ряда частот", "X_i*", "N_i*");
			window.Show();
		}

        // Представление группированного ряда относительных частот
		public static void DisplayGroupRelFreq(SortedDictionary<double, double> data)
		{
			var window = new DisplayForm(data, "Полигон группированного ряда относительных частот", "X_i*", "W_i*");
			window.Show();
		}

		// Настройка текста формы
		void setupForm(string title, string xName, string yName)
		{
			Text = title;
			var pane = graph.GraphPane;
			pane.YAxis.Title.Text = yName;
			pane.X2Axis.Title.Text = xName;
			pane.Title.Text = Text;
			// Настроить точку начала системы координат
			pane.XAxis.Cross = 0.0;
			pane.YAxis.Cross = 0.0;
			pane.XAxis.Scale.IsSkipFirstLabel = true;
			pane.XAxis.Scale.IsSkipLastLabel = true;
			pane.XAxis.Scale.IsSkipCrossLabel = true;
			pane.YAxis.Scale.IsSkipFirstLabel = true;
			pane.YAxis.Scale.IsSkipLastLabel = true;
			pane.YAxis.Scale.IsSkipCrossLabel = true;
			// Убрать засечки
			pane.XAxis.MinorTic.IsOpposite = false;
			pane.XAxis.MajorTic.IsOpposite = false;
			pane.YAxis.MinorTic.IsOpposite = false;
			pane.YAxis.MajorTic.IsOpposite = false;
			graph.AxisChange();
			graph.Invalidate();
		}

		// Построение статистический ряд частот
		public DisplayForm(SortedDictionary<double, double> data, string title, string xName, string yName)
		{
			InitializeComponent();

			//Вывод таблицы
			SetupDataSource<double, double>(data,xName, yName);
			setupForm(title, xName, yName);

			//Построение полигона
			var pane = graph.GraphPane;
			var curve = pane.AddCurve("", SortedDictionaryToList(data), Color.FromArgb(255, 39, 174, 96));
			graph.AxisChange();
			graph.Invalidate();
		}
        public DisplayForm(SortedDictionary<double, int> data, string title, string xName, string yName)
        {
            InitializeComponent();
            //Вывод таблицы
            SetupDataSource<double, int>(data, xName, yName);
            setupForm(title, xName, yName);
            //Построение полигона
            var pane = graph.GraphPane;
            var curve = pane.AddCurve("", SortedDictionaryToList(data), Color.FromArgb(255, 39, 174, 96));
            graph.AxisChange();
            graph.Invalidate();
        }

		//Преобразует словарь в набор точек
		PointPairList SortedDictionaryToList(SortedDictionary<double, double> data)
		{
			var list = new PointPairList();
			foreach (var x in data) list.Add(x.Key, x.Value);
			return list;
		}
        PointPairList SortedDictionaryToList(SortedDictionary<double, int> data)
        {
            var list = new PointPairList();
            foreach (var x in data) list.Add(x.Key, x.Value);
            return list;
        }

        public DisplayForm(SortedDictionary<LinearInterval, double> data, string title, string xName, string yName)
		{
			InitializeComponent();
			//Вывод таблицы
            SetupDataSource<LinearInterval, double>(data, xName, yName);
			setupForm(title, xName, yName);
			//Вывод графика
			var pane = graph.GraphPane;
			double maxY = 0;
			//Находим интервалы
			var intervals = new double[data.Count];
			var height = new double[data.Count];
			var xi = new double[data.Count];
            			
			int i = 0;
			foreach(var x in data)
			{
				intervals[i] = x.Key.Length;
				height[i] = x.Value / intervals[i];
				xi[i] = x.Key.LeftBorder;
				i++;
			}

			//Находим высоту
			//Рисуем гистограмму
			for (i = 0; i < height.Length; i++)
			{
				var box = new BoxObj((float)xi[i], (float)height[i], (float)intervals[i], (float)height[i], Color.Black, Color.FromArgb(255, 39, 174, 96));

				pane.GraphObjList.Add(box);
				if (height[i] > maxY) maxY = height[i];
			}

			//Настраиваем масштаб
			pane.XAxis.Scale.Min = 0;
			pane.XAxis.Scale.Max = data.Last().Key.RightBorder*1.1;
			pane.YAxis.Scale.Min = 0;
			pane.YAxis.Scale.Max = maxY * 1.1;
			
			graph.AxisChange();
			graph.Invalidate();
		}
        		
        // Настроить таблицу и привязать данные
		void SetupDataSource<TKey, TValue>(SortedDictionary<TKey, TValue> data, string xName, string valName)
		{
			dataGridView1.Columns.Add("x", xName);
			dataGridView1.Columns.Add("y", valName);

			foreach (DataGridViewColumn col in dataGridView1.Columns)
				col.DataPropertyName = col.Name;

			var bs = new BindingSource();
			bs.DataSource = data.Select(x => new { x = x.Key, y = x.Value }).ToList();
			dataGridView1.DataSource = bs;
		}
	}
}
