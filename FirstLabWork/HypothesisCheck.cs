using System;
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
        /// <summary>
        /// Значение Хи квадрат наблюдаемое
        /// </summary>
        protected double hiObserved;
        public double HiObserved
        {
            get { return hiObserved; }
        }
        /// <summary>
        /// Критическая точка
        /// </summary>
        protected double hiCritical;
        public double HiCritical
        {
            get { return hiCritical; }
        }


        /// <summary>
        /// Вероятности
        /// </summary>
        protected List<double> probabilities;
        /// <summary>
        /// Таблица критических точек Хи квадрат
        /// </summary>
        protected HiCritTable hiCritValuesTable;
        /// <summary>
        /// Выполнить проверку гипотезы
        /// </summary>
        /// <param name="significanceLevel">Уровень значимости</param>
        /// <param name="intSeries">Интервальный ряд</param>
        /// <returns>Подтверждение гипотезы</returns>
        abstract public bool doCheck(double significanceLevel, IntervalVariationStatisticSeries intSeries);
        /// <summary>
        /// Рассчитать вероятности
        /// </summary>
        /// <param name="inValue">Интервальный ряд</param>
        /// <returns>Коллекция вероятностей</returns>
        abstract protected List<double> probabilitiesCount(IntervalVariationStatisticSeries inValue);
        /// <summary>
        /// Рассчитать наблюдаемое значение Хи квадрат
        /// </summary>
        /// <param name="intSeries">Интервальный ряд частот</param>
        /// <returns>Хи квадрат наблюдаемое</returns>
        abstract protected double countHiObserved(IntervalVariationStatisticSeries intSeries);
        /// <summary>
        /// Найти критическую точку
        /// </summary>
        /// <param name="k">Число степеней свободы</param>
        /// <param name="significanceLevel">Уровень значимости</param>
        /// <returns>Критическая точка Хи квадрат</returns>
        protected double findHiCritical(double k, double significanceLevel)
        {
            double answer = 0;
            foreach (KeyValuePair<HiValueKey, double> pair in hiCritValuesTable.HiTable)
                if (pair.Key.Horizontally == k && pair.Key.Vertically == significanceLevel)
                    answer = pair.Value;
            return answer;
        }
    }

    /// <summary>
    /// Проверка гипотезы о нормальном законе распределения
    /// </summary>
    class NormalLawHypotesisCheck : HypothesisCheck 
    {
        Dictionary<double, double> laplasDictionary=new Dictionary<double,double>();
        private List<double[]> laplasTable = new List<double[]>();
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
            convertTableIntoHash();
        }
        public override bool doCheck(double significanceLevel, IntervalVariationStatisticSeries intSeries)
        {
            bool lawConfirmed = true;   // Подтверждение закона
            double k = intSeries.SeriesTable.Count - 3; // Количество степеней свободы
            // Сформировать новый интервальный ряд
            IntervalVariationStatisticSeries newInterval = createNewIntervalSeries(intSeries);
            // Рассчитать вероятности
            probabilities = probabilitiesCount(newInterval);
            // Рассчитать наблюдаемое значение критерия Хи квадрат
            hiObserved = countHiObserved(newInterval);
            // Найти критическую точку в таблице Хи квадрат
            hiCritical = findHiCritical(k, significanceLevel);
            if (hiObserved <= hiCritical)
                lawConfirmed = true;
            else
                lawConfirmed = false;
            return lawConfirmed;
        }
        
        protected override List<double> probabilitiesCount(IntervalVariationStatisticSeries intervalSeries)
        {
            // Рассчитанные вероятности
            List<double> probabilities = new List<double>();
            double firstArg = 0, secondArg = 0;
            int i = 0;
            foreach (KeyValuePair<LinearInterval, double> pair in intervalSeries.SeriesTable)
            {
                if (i == 0)
                {   // Левая граница последовательности инетрвалов (-inf)
                    secondArg = -5;
                    firstArg = pair.Key.RightBorder;
                }
                else if (i == intervalSeries.SeriesTable.Count - 1)
                {   // Правая граница последовательности инетрвалов (+inf)
                    firstArg = 5;
                    secondArg = pair.Key.LeftBorder;
                }
                else
                {
                    firstArg = pair.Key.RightBorder;
                    secondArg = pair.Key.LeftBorder;
                }               
                //if (secondArg < 0)
                 //   probabilities.Add(Math.Round(getLaplasFunctionValue(secondArg) - getLaplasFunctionValue(firstArg), 3));
                //else if(firstArg < 0)
                    probabilities.Add(Math.Round(getLaplasFunctionValue(firstArg) - getLaplasFunctionValue(secondArg), 3));

                i++;
            }
            return probabilities;
        }
        
        protected override double countHiObserved(IntervalVariationStatisticSeries intSeries)
        {
            double sum = 0;
            double numerator, denomirator;
            int i = 0;
            foreach (KeyValuePair<LinearInterval, double> pair in intSeries.SeriesTable)
            {
                double toPow = pair.Value - intSeries.SeriesTableFreqSum * probabilities[i];
                numerator = Math.Pow(toPow, 2);
                denomirator = intSeries.SeriesTableFreqSum * probabilities[i];
                sum += numerator / denomirator;
                i++;
            }
            return sum;
        }

        public double getLaplasFunctionValue(double argument)
        {
            double coeff = 1;
            if (argument < 0)
                coeff = -1;

            argument = Math.Abs(argument);
            double leftBorder = 0, rightBorder = 0;
            double result = -1;
            foreach (KeyValuePair<double,double> pair in laplasDictionary)      
            {
                if (pair.Key < argument)
                {
                    leftBorder = pair.Key;
                }
                else if (pair.Key > argument)
                {
                    rightBorder = pair.Key;
                    return coeff*linearInterpolation(leftBorder, rightBorder,argument,laplasDictionary);
                }
                else
                {
                    return coeff*pair.Value;
                }
            }
            return result;
        }

        void convertTableIntoHash()
        {
            int i = 0;
            /*foreach (double[] pair in laplasTable)
            {
                laplasDictionary.Add(pair[0], pair[1]);i++;
            }*/
            for(int j=0;j<laplasTable.Count;j++)
            {
                laplasDictionary.Add(laplasTable[j][0], laplasTable[j][1]);
            }
        }

        public double linearInterpolation(double left, double right, double current, Dictionary<double, double> torqueByRPM)
        {
            return (torqueByRPM[left] + ((torqueByRPM[right] - torqueByRPM[left]) / (right - left)) * (current - left));
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
        public ExponentialLawCheck(HiCritTable hiCritValuesTable)
        {
            this.hiCritValuesTable = hiCritValuesTable;
        }

        public override bool doCheck(double significanceLevel, IntervalVariationStatisticSeries intSeries)
        {
            bool lawConfirmed = true;
            double k = intSeries.SeriesTable.Count - 2;
            // Рассчитать вероятности
            probabilities = probabilitiesCount(intSeries);
            // Рассчитать наблюдаемое значение критерия Хи квадрат
            hiObserved = countHiObserved(intSeries);
            hiCritical = findHiCritical(k, significanceLevel);
            if (hiObserved <= hiCritical)
                lawConfirmed = true;
            else
                lawConfirmed = false;
            return lawConfirmed;
        }
        protected override List<double> probabilitiesCount(IntervalVariationStatisticSeries inValue)
        {
            List<double> probs = new List<double>();    // Вероятности
            GroupedRelativeArequenceSeries groupedSeries = GroupedRelativeArequenceSeries.calculateFromIntervalSeries(inValue, inValue.SeriesTable.Count);
            double sampleMean = SeriesCharacteristics.calculateSampleMean(groupedSeries.SeriesTable);
            double lambda = 1 / sampleMean;
            double buff;
            foreach(KeyValuePair<LinearInterval, double> pair in inValue.SeriesTable)
            {
                buff = Math.Exp(-lambda * pair.Key.LeftBorder) - Math.Exp(-lambda * pair.Key.RightBorder);
                probs.Add(buff);
            }
            return probs;
        }
        protected override double countHiObserved(IntervalVariationStatisticSeries intSeries)
        {
            double hiObserved = 0;
            double theoryFreq;
            int i = 0;
            foreach(KeyValuePair<LinearInterval, double> pair in intSeries.SeriesTable)
            {
                theoryFreq = intSeries.SeriesTableFreqSum * probabilities[i];
                hiObserved += Math.Pow(pair.Value - theoryFreq, 2) / theoryFreq;
                i++;
            }
            return hiObserved;
        } 
    }
}
