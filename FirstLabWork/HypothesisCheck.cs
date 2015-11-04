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
        /// Выполнить проверку гипотезы
        /// </summary>
        /// <typeparam name="hiObserviedKey">Пара значений - k и alpha ("координаты" наблюдаемого значения Хи квадрат)</typeparam>        
        /// <returns>Подтверждение гипотезы</returns>
        abstract public bool doCheck(HiValueKey hiObserviedKey);
        /// <summary>
        /// Рассчитать вероятность при значении inValue
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="inValue">Аргумент для расчета вероятности</param>
        /// <returns></returns>
        abstract protected double probabilityFunction<T>(T inValue);
    }

    /// <summary>
    /// Проверка гипотезы о нормальном законе распределения
    /// </summary>
    class NormalLawHypotesisCheck : HypothesisCheck 
    {
        private List<double[]> laplasTable = new List<double[]>();
        private HiCritTable hiCritValuesTable = new HiCritTable();
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

        public override bool doCheck(HiValueKey hiObserviedKey)
        {
            throw new NotImplementedException();
        }
        protected override double probabilityFunction<T>(T inValue)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Проверка гипотезы о показательном законе распределения
    /// </summary>
    class ExponentialLawCheck : HypothesisCheck
    {
        public override bool doCheck(HiValueKey hiObserviedKey)
        {
            throw new NotImplementedException();
        }
        protected override double probabilityFunction<T>(T inValue)
        {
            throw new NotImplementedException();
        }
        
    }
}
