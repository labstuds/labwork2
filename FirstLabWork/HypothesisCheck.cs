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
        /// <returns>Подтверждение гипотезы</returns>
        abstract public bool doCheck();
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
        public List<double[]> LaplasTable
        {
            set { laplasTable = value; }
        }        
        public NormalLawHypotesisCheck()
        {
        }        
        public NormalLawHypotesisCheck(List<double[]> laplasTable)
        {
            this.laplasTable = laplasTable;
        }
        
        public override bool doCheck()
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
        public override bool doCheck()
        {
            throw new NotImplementedException();
        }
        protected override double probabilityFunction<T>(T inValue)
        {
            throw new NotImplementedException();
        }
        
    }
}
