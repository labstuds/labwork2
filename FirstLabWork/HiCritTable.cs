using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstLabWork
{
    /// <summary>
    /// Таблица критических точек Хи квадрат
    /// </summary>
    class HiCritTable
    {
        private Dictionary<HiValueKey, double> hiTable = new Dictionary<HiValueKey, double>();
        public Dictionary<HiValueKey, double> HiTable
        {
            get { return HiTable; }
            set { hiTable = value; }
        }
        private List<double> significanceLevelValues = new List<double>();  // Уровни значимости
        public List<double> SignificanceLevelValues
        {
            get { return significanceLevelValues; }
            set { significanceLevelValues = value; }
        }
        /// <summary>
        /// Добавить элемент
        /// </summary>
        /// <param name="key">Ключ</param>
        /// <param name="value">Значение</param>
        public void Add(HiValueKey key, double value)
        {
            hiTable.Add(key, value);
        }
        /// <summary>
        /// Получить значение
        /// </summary>
        /// <param name="key">Ключ</param>
        /// <returns>Значение по ключу key</returns>
        public double value(HiValueKey key)
        {
            return hiTable[key];
        }
        
    }

    /// <summary>
    /// Ключ, по которому хранится критическая точка Хи квадрат.
    /// </summary>
    class HiValueKey
    {
        private double horizontally;
        private double vertically;
        public HiValueKey()
        {

        }
        public HiValueKey(double vertically, double horizontally)
        {
            this.vertically = vertically;
            this.horizontally = horizontally;
        }
        public double Vertically
        {
            get { return vertically; }
            set { vertically = value; }
        }
        public double Horizontally
        {
            get { return horizontally; }
            set { horizontally = value; }
        }
    }
}
