﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstLabWork
{
    /// <summary>
    /// Проверка гипотезы о виде закона распределения
    /// </summary>
    abstract class HypothesisCheck
    {
        protected List<double> probabilities;
        /// <summary>
        /// Выполнить проверку гипотезы
        /// </summary>
        /// <typeparam name="hiObserviedKey">Пара значений - k и alpha ("координаты" наблюдаемого значения Хи квадрат)</typeparam>        
        /// <typeparam name="intSeries">Интервальный ряд</typeparam>        
        /// <returns>Подтверждение гипотезы</returns>
        abstract public bool doCheck(double significanceLevel, IntervalVariationStatisticSeries intSeries);
        /// <summary>
        /// Рассчитать вероятности
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="inValue">Интервал для расчета вероятности</param>
        /// <returns></returns>
        abstract protected List<double> probabilityFunction(IntervalVariationStatisticSeries inValue);
    }

    /// <summary>
    /// Проверка гипотезы о нормальном законе распределения
    /// </summary>
    class NormalLawHypotesisCheck : HypothesisCheck 
    {
        private List<double[]> laplasTable = new List<double[]>();
        private HiCritTable hiCritValuesTable = new HiCritTable();
        private double hiObserved;
        public double HiObserved
        {
            get { return hiObserved; }
        }
        public List<double[]> LaplasTable
        {
            set { laplasTable = value; }
        }        
        public NormalLawHypotesisCheck()
        {
        }        
        public NormalLawHypotesisCheck(List<double[]> laplasTable, HiCritTable hiCritValuesTable)
        {
            this.laplasTable = laplasTable;
            this.hiCritValuesTable = hiCritValuesTable;            
        }

        public override bool doCheck(double significanceLevel, IntervalVariationStatisticSeries intSeries)
        {
            bool lawConfirmed = true;
            double k = intSeries.SeriesTable.Count - 3;
            // Сформировать новый интервальный ряд
            IntervalVariationStatisticSeries newInterval = createNewIntervalSeries(intSeries);
            // Рассчитать вероятности
            probabilities = probabilityFunction(newInterval);
            // Рассчитать наблюдаемое значение критерия Хи квадрат
            hiObserved = countHiObserved(newInterval);
            return lawConfirmed;
        }
        protected override List<double> probabilityFunction(IntervalVariationStatisticSeries intervalSeries)
        {
            List<double> probabilities = new List<double>();
            double firstArg = 0, secondArg = 0;
            int i = 0;
            foreach (KeyValuePair<LinearInterval, double> pair in intervalSeries.SeriesTable)
            {
                if (i == 0)
                {
                    secondArg = -5;
                    firstArg = pair.Key.RightBorder;
                }
                else if (i == intervalSeries.SeriesTable.Count - 1)
                {
                    firstArg = 5;
                    secondArg = pair.Key.LeftBorder;
                }
                else
                {
                    firstArg = pair.Key.RightBorder;
                    secondArg = pair.Key.LeftBorder;

                }
                if (secondArg < 0)
                    probabilities.Add(Math.Round(getLaplasFunctionValue(secondArg) - getLaplasFunctionValue(firstArg), 3));
                else
                    probabilities.Add(Math.Round(getLaplasFunctionValue(firstArg) - getLaplasFunctionValue(secondArg), 3));
                i++;
            }
            return probabilities;
        }
        private double countHiObserved(IntervalVariationStatisticSeries intSeries)
        {
            double sum = 0;            
            double numerator, denomirator;
            int i = 0;
            foreach(KeyValuePair<LinearInterval, double> pair in intSeries.SeriesTable)
            {
                double toPow = pair.Value - intSeries.SeriesTableFreqSum * probabilities[i];
                numerator = Math.Pow(toPow, 2);
                denomirator = intSeries.SeriesTableFreqSum * probabilities[i];
                sum += numerator / denomirator;
                i++;
            }
            return sum;
        }
        
        private double getLaplasFunctionValue(double argument)
        {
            argument = Math.Abs(Math.Round(argument, 2));   // Т.к. значения аргументов в таблице Лапласа округлены до двух знаков
            double value = 0;
            foreach(double[] pair in laplasTable)            
                if (pair[0] == argument)
                    value = pair[1];
            return Math.Round(value, 4);
        }
        private IntervalVariationStatisticSeries createNewIntervalSeries(IntervalVariationStatisticSeries old)
        {
            GroupedRelativeArequenceSeries groupedSeries = GroupedRelativeArequenceSeries.calculateFromIntervalSeries(old, old.SeriesTable.Count);
            double sampleMean = SeriesCharacteristics.calculateSampleMean(groupedSeries.SeriesTable);
            double sampleMeanSquare = SeriesCharacteristics.calculateSampleMeanSquare(groupedSeries.SeriesTable);
            IntervalVariationStatisticSeries newInterval = IntervalVariationStatisticSeries.calculateSeriesFromReadySeries(old.SeriesTable);
          
            foreach(KeyValuePair<LinearInterval, double> pair in newInterval.SeriesTable)
            {
                pair.Key.LeftBorder = (pair.Key.LeftBorder - sampleMean) / sampleMeanSquare;
                pair.Key.RightBorder = (pair.Key.RightBorder - sampleMean) / sampleMeanSquare;
            }

            return newInterval;
        }
    }

    /// <summary>
    /// Проверка гипотезы о показательном законе распределения
    /// </summary>
    class ExponentialLawCheck : HypothesisCheck
    {
        public override bool doCheck(double significanceLevel, IntervalVariationStatisticSeries intSeries)
        {
            throw new NotImplementedException();
        }
        protected override List<double> probabilityFunction(IntervalVariationStatisticSeries inValue)
        {
            throw new NotImplementedException();
        }
        
    }
}
