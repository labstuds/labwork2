using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FirstLabWork
{
    public class SourceValues
    {
        public static double[,] valuesTable = null;
    }

    /// <summary>
    /// Класс, образующий начальный ряд. Имеет функции, генерирующие из него новые типы рядов, начинаются с префикса get*()
    /// </summary>
    public class VariationSeries
    {
        SortedDictionary<double,int > variationSeriesTable;

        private VariationSeries()
        {
            initialize();
        }

        private void initialize()
        {
            variationSeriesTable = new SortedDictionary<double, int>();
        }

        /// <summary>
        /// Функция-ферма для данного класса. Создавать объекты только ей.
        /// </summary>
        /// <returns></returns>
        public static VariationSeries calculateSerires()
        {
            VariationSeries variationSeries = new VariationSeries();

            if(SourceValues.valuesTable == null)
            {
                throw new ArgumentException("Нельзя расчитать ряды без выборки. Введите выборку.");
            }

            foreach(double currentElementFromValues in SourceValues.valuesTable)
            {
                variationSeries.addElementToSeriesTable(currentElementFromValues);
            }
            return variationSeries;
        }

        private void addElementToSeriesTable(double element)
        {
            if(elementIsAlreadyInSeriesTable(element))
            {
                variationSeriesTable[element]++;
            }
            else
            {
                variationSeriesTable.Add(element, 1);
            }
        }
        
        private bool elementIsAlreadyInSeriesTable(double element)
        {
            return variationSeriesTable.Keys.Contains(element);
        }

        /// <summary>
        /// Словарь со всей таблицей.
        /// </summary>
        public SortedDictionary<double,int > SeriesTable
        {
            get
            {
                return variationSeriesTable;
            }
        }

        /// <summary>
        /// Создает ряд относительных частот исходя из таблицы, построенной в данном объекте.
        /// </summary>
        /// <returns>Ряд относительных частот</returns>
        public StatisticRelativeАrequenceSeries getRelativeSeries()
        {
            return StatisticRelativeАrequenceSeries.calculateFromVariationSeries(this);
        }

        /// <summary>
        /// Создает интервальный ряд статистический, исходя из данных, расчитанных в текущем объекте.
        /// </summary>
        /// <param name="intervalsCount">Количество интервалов разбиения.</param>
        /// <returns>Интервальный статисический ряд частот.</returns>
        public IntervalVariationStatisticSeries getIntervalVariationSeries(int intervalsCount)
        {
            return IntervalVariationStatisticSeries.calculateSeriesFromVariationSeriesAndIntervalLength(this, intervalsCount);
        }

        /// <summary>
        /// Создает группированный ряд относительных частот, исходя из данных, расчитанных в данном объекте.
        /// </summary>
        /// <param name="intervalsCount">Количество интервалов разбиения.</param>
        /// <returns>Группированный ряд относительных частот.</returns>
        public GroupedRelativeArequenceSeries getGroupedRelativeArequenceSeries(int intervalsCount)
        {
            return GroupedRelativeArequenceSeries.calculateFromVariationSeries(this, intervalsCount);
        }
    }

    public class StatisticRelativeАrequenceSeries
    {
        SortedDictionary<double, double> seriesTable;
        VariationSeries varSeries;
        int elementsCount;
        private StatisticRelativeАrequenceSeries()
        {
            initialize();
        }

        private void initialize()
        {
            seriesTable = new SortedDictionary<double, double>();
            elementsCount = 0;
        }

        public static StatisticRelativeАrequenceSeries calculateFromVariationSeries(VariationSeries varSeries)
        {
            StatisticRelativeАrequenceSeries currentSeries = new StatisticRelativeАrequenceSeries();
            currentSeries.varSeries = varSeries;
            currentSeries.calculateElementsCount();
            currentSeries.calculateRelativeSeries();
            return currentSeries;
        }

        private void calculateElementsCount()
        {
            foreach(KeyValuePair<double,int> pairFromVarSeries in varSeries.SeriesTable)
            {
               elementsCount += pairFromVarSeries.Value;
            }
        }

        private void calculateRelativeSeries()
        {
            foreach(KeyValuePair<double,int> pairFromVarSeries in varSeries.SeriesTable)
            {
                addPairToRelativeSeriesFromRelativeValueAndElement(calculateRelativeValueForRelativeSeries(pairFromVarSeries.Value),pairFromVarSeries.Key);
            }
        }

        private double calculateRelativeValueForRelativeSeries(int currentElement)
        {
            return (double)currentElement / (double)elementsCount;
        }

        private void addPairToRelativeSeriesFromRelativeValueAndElement(double relativeValue, double elementFromTable)
        {
            seriesTable.Add(elementFromTable,relativeValue);
        }

        public SortedDictionary<double, double> SeriesTable
        {
            get { return seriesTable; }
        }
    }

    public class IntervalVariationStatisticSeries
    {
        SortedDictionary<LinearInterval, double> table;
        VariationSeries varSeries;
        double deltaInterval;

        private IntervalVariationStatisticSeries()
        {
            initialize();
        }

        private void initialize()
        {
            table = new SortedDictionary<LinearInterval, double>();
            deltaInterval = 0;
        }

        public static IntervalVariationStatisticSeries calculateSeriesFromReadySeries(SortedDictionary<LinearInterval,double> series)
        {
            IntervalVariationStatisticSeries currentSeries = new IntervalVariationStatisticSeries();
            currentSeries.varSeries = null;
            currentSeries.table = series;
            return currentSeries;
        }

        public static IntervalVariationStatisticSeries calculateSeriesFromVariationSeriesAndIntervalLength(VariationSeries varSeries, int intervalsCount)
        {
            IntervalVariationStatisticSeries currentSeries = new IntervalVariationStatisticSeries();
            currentSeries.varSeries = varSeries;
            currentSeries.calculateDeltaInterval(intervalsCount);
            currentSeries.addIntervalsWithValues(intervalsCount);
            return currentSeries;
        }

        private void calculateDeltaInterval(int intervalsCount)
        {
            LinearInterval allSelectionInterval = new LinearInterval(getLeftBorderFromAllSelection(), getRightBorderFromAllSelection());
            deltaInterval = allSelectionInterval.Length/(double)intervalsCount;
        }

        private double getLeftBorderFromAllSelection()
        {
            double minimum = double.MaxValue;
            foreach(KeyValuePair<double,int> pair in varSeries.SeriesTable)
            {
                if(minimum>=pair.Key)
                {
                    minimum = pair.Key;
                }
            }
            return minimum;
        }

        private double getRightBorderFromAllSelection()
        {
            double maximum = double.MinValue;
            foreach (KeyValuePair<double, int> pair in varSeries.SeriesTable)
            {
                if (maximum < pair.Key)
                {
                    maximum = pair.Key;
                }
            }
            return maximum;
        }

        private void addIntervalsWithValues(int intervalsCount)
        {
            double leftBorder = getLeftBorderFromAllSelection();
            double rightBorder = leftBorder + deltaInterval;
            for(int i=1;i<=intervalsCount;i++)
            {
                LinearInterval interval = new LinearInterval(leftBorder,rightBorder);
                //прошу прощения за непонятную функцию, она как раз считает n* итые для каждого интервала
                //i там нужно, чтобы правильно посчитать граничные значения у интервалов
                int value = calculateValueOnIntervalHelpsNumberOfInterval(interval, i);
                table.Add(interval, value);
                leftBorder = rightBorder;
                rightBorder = leftBorder + deltaInterval;
            }
        }

        private int calculateValueOnIntervalHelpsNumberOfInterval(LinearInterval interval,int intervalIndex)
        {
            int value = 0;
            foreach(KeyValuePair<double,int> pair in varSeries.SeriesTable)
            {
                if(intervalIndex==1 && interval.valueIsBelongsIncludingLeftAndRightBorders(pair.Key))
                {
                    value += pair.Value;
                }
                else if(intervalIndex!=1 && interval.valueIsBelongsIncludingRightBorders(pair.Key))
                {
                    value += pair.Value;
                }
            }
            return value;
        }
    
        public SortedDictionary<LinearInterval, double> SeriesTable
        {
            get { return table; }
            set { table = value; }
        }

        // Сумма частот
        public double SeriesTableFreqSum
        {
            get 
            {
                double sum = 0;
                foreach (KeyValuePair<LinearInterval, double> pair in table)
                {
                    sum += pair.Value;
                }
                return sum;
            }
        }
    }

    public class GroupedRelativeArequenceSeries
    {
        SortedDictionary<double, double> table;
        VariationSeries varSeries;
        IntervalVariationStatisticSeries intervalSeries;
        double elementsCount;
        public double ElementsCount
        {
            get { return elementsCount; }
        }
        private GroupedRelativeArequenceSeries()
        {
            initialize();
        }

        private void initialize()
        {
            table = new SortedDictionary<double, double>();
            elementsCount = 0;
        }

        public static GroupedRelativeArequenceSeries calculateFromIntervalSeries(IntervalVariationStatisticSeries intSeries,int intervalsCount)
        {
            GroupedRelativeArequenceSeries currentSeries = new GroupedRelativeArequenceSeries();
            currentSeries.varSeries = null;
            currentSeries.intervalSeries = intSeries;
            currentSeries.calculateElementsCount();
            currentSeries.addElementsToTable();
            return currentSeries;
        }

        public static GroupedRelativeArequenceSeries calculateFromVariationSeries(VariationSeries varSeries,int intervalsCount)
        {
            GroupedRelativeArequenceSeries currentSeries = new GroupedRelativeArequenceSeries();
            currentSeries.varSeries = varSeries;
            currentSeries.intervalSeries = varSeries.getIntervalVariationSeries(intervalsCount);
            currentSeries.calculateElementsCount();
            currentSeries.addElementsToTable();
            return currentSeries;
        }

        private void calculateElementsCount()
        {
            foreach(KeyValuePair<LinearInterval,double> pair in intervalSeries.SeriesTable)
            {
                elementsCount += pair.Value;
            }
        }

        private void addElementsToTable()
        {
            foreach(KeyValuePair<LinearInterval,double> pair in intervalSeries.SeriesTable)
            {
                table.Add(pair.Key.Middle,calculateRelativeArequence(pair.Value));
            }
        }

        private double calculateRelativeArequence(double arequence)
        {
            return arequence / elementsCount;
        }

        public SortedDictionary<double, double> SeriesTable
        {
            get { return table; }
        }
    }

    public class SeriesCharacteristics
    {
        static public double calculateSampleMean(SortedDictionary<double, double> seriesTable)
        {
            double result = 0f;
            double deltaResult = 0f;
            foreach(KeyValuePair<double,double> pair in seriesTable)
            {
                deltaResult=pair.Key*pair.Value;
                result += deltaResult;
            }
            return result;
        }
        static public double calculateDispersion(SortedDictionary<double,double> seriesTable)
        {
            
            double sm = calculateSampleMean(seriesTable);
            double result = 0;
            foreach(KeyValuePair<double,double> pair in seriesTable)
            {
                result += Math.Pow((pair.Key - sm),2) * pair.Value;
            }
            return result;
        }
        static public double calculateSampleMeanSquare(SortedDictionary<double, double> series)
        {
            return Math.Sqrt(calculateDispersion(series));
        }
        static public double calculateInitialSamplingPoint(SortedDictionary<double, double> seriesTable, double r)
        {
            double result = 0;
            foreach (KeyValuePair<double, double> pair in seriesTable)
            {
                result += Math.Pow(pair.Key,r) * pair.Value;
            }
            return result;
        }
        static public double calculateCentralSamplingPoint(SortedDictionary<double, double> seriesTable, double r)
        {
            double sm = calculateSampleMean(seriesTable);
            double result = 0;
            foreach (KeyValuePair<double, double> pair in seriesTable)
            {
                result += Math.Pow((pair.Key - sm),r) * pair.Value;
            }
            return result;
        }
    }

    public class LinearInterval:IComparable
    {
        double leftBorder;
        double rightBorder;

        public LinearInterval(double firstBorder,double secondBorder)
        {
            if(firstBorder>=secondBorder)
            {
                leftBorder = secondBorder;
                rightBorder = firstBorder;
            }
            else
            {
                leftBorder = firstBorder;
                rightBorder = secondBorder;
            }
        }

        public double LeftBorder
        {
            get { return leftBorder; }
            set { leftBorder = value; }
        }

        public double RightBorder
        {
            get { return rightBorder; }
            set { rightBorder = value; }
        }

        public override string ToString()
        {
            return ""+leftBorder+";"+rightBorder;
        }

        public double Length
        {
            get { return rightBorder - leftBorder; }
        }

        public bool valueIsBelongsIncludingLeftAndRightBorders(double value)
        {
            return Math.Round(leftBorder,4) <= Math.Round(value,2) && value <= Math.Round(rightBorder,4);
        }

        public bool valueIsBelongsIncludingRightBorders(double value)
        {
            return Math.Round(leftBorder,4) < Math.Round(value,4) && value <= Math.Round(rightBorder,4);
        }

        public double Middle
        {
            get { return (leftBorder + rightBorder) / 2; }
        }

        public static bool operator<(LinearInterval a,LinearInterval b)
        {
            return a.LeftBorder < b.LeftBorder;
        }

        public static bool operator>(LinearInterval a,LinearInterval b)
        {
            return a.LeftBorder > b.LeftBorder;
        }

        public static bool operator==(LinearInterval a,LinearInterval b)
        {
            return !(a<b)&&!(a>b);
        }

        public static bool operator>=(LinearInterval a,LinearInterval b)
        {
            return a > b || a == b;
        }
        public static bool operator<=(LinearInterval a,LinearInterval b)
        {
            return a < b || a == b;
        }
        public static bool operator!=(LinearInterval a,LinearInterval b)
        {
            return !(a == b);
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
                return 0;
            LinearInterval b = obj as LinearInterval;
            return this.LeftBorder.CompareTo(b.LeftBorder);
        }
    }

}