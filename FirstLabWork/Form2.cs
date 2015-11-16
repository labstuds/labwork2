using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LoggerEvsSpace;
using System.IO;
namespace FirstLabWork
{
    public partial class Form2 : Form
    {        
        List<double[]> LaplasTable = new List<double[]>();  // Таблица значений функции Лапласа
        HiCritTable currentHiTable = new HiCritTable();     // Таблица критических точек Хи квадрат                
        IntervalVariationStatisticSeries intSeries;
        GroupedRelativeArequenceSeries groupedSeries;
        
        public Form2()
        {
            InitializeComponent(); 
            // Заполнить ряд стандартными значениями
            setDefaultIntervalsGrid();
        }

        private void setDefaultIntervalsGrid()
        {
            int intervalsCount = 6;
            double oldLftBrdr, oldRghtBrdr, lftBrdr;
            double[] freqs = {4, 13, 34, 32, 12, 5};
            dgvIntervals.Rows.Add();
            dgvIntervals.Rows[0].Cells[0].Value = 44;
            dgvIntervals.Rows[0].Cells[1].Value = 46;
            dgvIntervals.Rows[0].Cells[2].Value = freqs[0];
            for (int i = 1; i < intervalsCount; i++)
            {
                dgvIntervals.Rows.Add();
                oldRghtBrdr = Convert.ToDouble(dgvIntervals.Rows[i-1].Cells[1].Value);
                oldLftBrdr = Convert.ToDouble(dgvIntervals.Rows[i - 1].Cells[0].Value);
                dgvIntervals.Rows[i].Cells[0].Value = oldRghtBrdr.ToString();
                lftBrdr = oldRghtBrdr;
                dgvIntervals.Rows[i].Cells[1].Value = (lftBrdr + oldRghtBrdr - oldLftBrdr).ToString();
                dgvIntervals.Rows[i].Cells[2].Value = freqs[i].ToString();
            }            
            btnRemoveInterval.Enabled = true;
        }

        // Чтение интервалов из таблицы
        #region IntervalReading

        private void button1_Click(object sender, EventArgs e)
        {
            if (intervalsGridIsCorrect())
                readIntervalsGrid();
        }

        private void readIntervalsGrid()
        {
            SortedDictionary<LinearInterval, double> intervalSeriesTable = new SortedDictionary<LinearInterval, double>();
            // Считать ряд из таблицы
            LinearInterval bufInterval;
            double leftBorder, rightBorder, freq;
            for (int i = 0; i < dgvIntervals.Rows.Count; i++)
            {
                leftBorder = Convert.ToDouble(dgvIntervals.Rows[i].Cells[0].Value);
                rightBorder = Convert.ToDouble(dgvIntervals.Rows[i].Cells[1].Value);
                freq = Convert.ToDouble(dgvIntervals.Rows[i].Cells[2].Value);
                bufInterval = new LinearInterval(leftBorder, rightBorder);
                intervalSeriesTable.Add(bufInterval, freq);
            }
            // Получить интервальные ряды
            intSeries = IntervalVariationStatisticSeries.calculateSeriesFromReadySeries(intervalSeriesTable);
        }

        private bool intervalsGridIsCorrect()
        {
            bool tableIsValid = true;            
            double oldRghtBrdr = 0;
            double bordersDifference = 0; // Разница между интервалами
            if (dgvIntervals.Rows.Count < 2)
            {
                MessageBox.Show("Введите как минимум 2 интервала");
                tableIsValid = false;
            }
            else
            {
                // Проверить валидность таблицы
                for (int i = 0; i < dgvIntervals.Rows.Count && tableIsValid; i++)
                {
                    checkEmptyValuesInRow(ref tableIsValid, i);     // Проверить на незаполненные значения
                    checkIntervalBorders(ref tableIsValid, i);  // Проверить на "перевернутые" интервалы
                    checkIntervalIntegrity(ref tableIsValid, ref oldRghtBrdr, i);   // Проверить на целостность интервалов
                    ckeckIntervalsLength(ref tableIsValid, ref bordersDifference, i);   // Проверить на длину интервалов
                }
            }
            return tableIsValid;
        }

        /// <summary>
        /// Проверить длину интервалов
        /// </summary>
        /// <param name="tableIsValid">Корректна ли таблица</param>
        /// <param name="bordersDifference">Разница между границами интервала</param>
        /// <param name="i">Строка, в которой ведется проверка</param>
        /// <returns></returns>
        private void ckeckIntervalsLength(ref bool tableIsValid, ref double bordersDifference, int i)
        {
            if (tableIsValid)
            {
                if (i == 0)
                    bordersDifference = Convert.ToDouble(dgvIntervals.Rows[i].Cells[1].Value) - Convert.ToDouble(dgvIntervals.Rows[i].Cells[0].Value);
                else
                {
                    double currentBordersDifference = Convert.ToDouble(dgvIntervals.Rows[i].Cells[1].Value) - Convert.ToDouble(dgvIntervals.Rows[i].Cells[0].Value);
                    if (bordersDifference != currentBordersDifference)
                    {
                        tableIsValid = false;
                        MessageBox.Show("Обнаружен непропорциональный интервал");
                    }
                    else
                        bordersDifference = currentBordersDifference;
                }
            }
        }

        /// <summary>
        /// Проверить целостность интервала
        /// </summary>
        /// <param name="tableIsValid">Корректна ли таблица</param>
        /// <param name="oldRghtBrdr">Правая граница предыдущего интервала</param>
        /// <param name="i">Номер строки с текущим интервалом</param>
        /// <returns></returns>
        private void checkIntervalIntegrity(ref bool tableIsValid, ref double oldRghtBrdr, int i)
        {
            if (tableIsValid)
            {
                if (i == 0)
                    oldRghtBrdr = Convert.ToDouble(dgvIntervals.Rows[0].Cells[1].Value);
                else
                {
                    if (oldRghtBrdr != Convert.ToDouble(dgvIntervals.Rows[i].Cells[0].Value))
                    {
                        tableIsValid = false;
                        MessageBox.Show(string.Format("Нарушена целостность интервала в {0}-й строке", i + 1));
                    }
                    else
                        oldRghtBrdr = Convert.ToDouble(dgvIntervals.Rows[i].Cells[1].Value);
                }
            }
        }

        /// <summary>
        /// Проверить на "перевернутый" интервал
        /// </summary>        
        /// <param name="tableIsValid">Корректна ли таблица</param>
        /// <param name="i">Номер строки, в которой ведется проверка</param>
        /// <returns></returns>
        private void checkIntervalBorders(ref bool tableIsValid, int i)
        {
            if (tableIsValid)
            {
                double leftBrdr = Convert.ToDouble(dgvIntervals.Rows[i].Cells[0].Value);
                double rigthBrdr = Convert.ToDouble(dgvIntervals.Rows[i].Cells[1].Value);
                if (leftBrdr > rigthBrdr)
                {
                    tableIsValid = false;
                    MessageBox.Show(string.Format("У интервала в {0}-й строке неверные границы", i + 1));
                }
                else if (leftBrdr == rigthBrdr)
                {
                    tableIsValid = false;
                    MessageBox.Show(string.Format("У инетрвала в {0}-й строке равны границы", i + 1));
                }
            }
        }

        /// <summary>
        /// Проверить на незаполненные значения
        /// </summary>        
        /// <param name="tableIsValid">Корректна ли таблица</param>
        /// <param name="i">Номер строки, в которой идет проверка</param>
        /// <returns></returns>
        private void checkEmptyValuesInRow(ref bool tableIsValid, int i)
        {
            if (tableIsValid)
            {
                for (int j = 0; j < dgvIntervals.Rows[i].Cells.Count && tableIsValid; j++)
                {
                    if (dgvIntervals.Rows[i].Cells[j].Value == null)
                    {
                        tableIsValid = false;
                        MessageBox.Show(string.Format("Незаполнена {0} ячейка в {1}-й строке", j + 1, i + 1));
                    }
                }
            }
        }

        #endregion

        // Загрузка критических точек Хи квадрат
        #region LoadHiSquareTable
        // Для чтения таблицы значений критерия Пирсона
        public void readTable()
        {
            // Открыть окно загрузки
            if (ofdHi.ShowDialog() != DialogResult.OK)
                return;

            // Начать чтение
            if (ofdHi.FileName != null)
                readStrs();
            else
                MessageBox.Show("Не был выбран файл!");
        }


        private void readStrs()
        {
            dgvHi.Rows.Clear();
            dgvHi.Columns.Clear();
            StreamReader srHi = new StreamReader(ofdHi.FileName);
            double[] firstString = parseStr(srHi.ReadLine());
            dgvHi.TopLeftHeaderCell.Value = "k\\alpha";
            List<double> horizValues = new List<double>();
            // Создать заголовки колонкам (значения альфа)
            for (int i = 0; i < firstString.Length - 1; i++)
            {
                dgvHi.Columns.Add(i.ToString(), firstString[i + 1].ToString());
                horizValues.Add(firstString[i + 1]);
            }
            currentHiTable.SignificanceLevelValues = horizValues;
            // Добавить строки со значениями критерия
            double[] buffer;
            for (int i = 0; !srHi.EndOfStream; i++)
            {
                buffer = parseStr(srHi.ReadLine());
                dgvHi.Rows.Add();
                dgvHi.Rows[i].HeaderCell.Value = buffer[0].ToString();
                for (int j = 0; j < buffer.Length - 1; j++)
                {
                    // Сформировать "ключ" для таблицы критических точек 
                    HiValueKey buffHiKey = new HiValueKey();
                    buffHiKey.Horizontally = buffer[0];
                    buffHiKey.Vertically = horizValues[j];

                    dgvHi.Rows[i].Cells[j].Value = buffer[j + 1].ToString();
                    currentHiTable.Add(buffHiKey, buffer[j + 1]);
                }
            }
        }

        private void загрузитьКритическиеТочкиРаспределенияХиКвадратToolStripMenuItem_Click(object sender, EventArgs e)
        {
            readTable();
            // Добавить пункты в комбобокс уровня значимости
            List<double> alphaValues = currentHiTable.SignificanceLevelValues;
            cbAlphaValues.DataSource = alphaValues;
            cbAlphaValues.Enabled = true;
        }
        #endregion

        // Загрузка таблицы Лапласа
        #region LoadLaplasTable

        private void загрузитьТаблицуЗначенийФункцииЛапласаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Открыть окно загрузки
            if (ofdLaplas.ShowDialog() != DialogResult.OK)
                return;

            // Начать чтение
            if (ofdLaplas.FileName != null)
                LaplasTable = readData(ofdLaplas.FileName);
            else
                MessageBox.Show("Не был выбран файл!");
        }

        private List<double[]> readData(string filename)
        {
            List<double[]> data = new List<double[]>();
            double[] buffer;
            // Прочитать и распарсить данные 
            StreamReader srLaplasTable = new StreamReader(filename);
            while (!srLaplasTable.EndOfStream)
            {
                buffer = parseStr(srLaplasTable.ReadLine());
                data.Add(buffer);
            }
            return data;
        }

        #endregion

        // Построение графиков
        #region ShowGraphics

        private void showGraphicsButton_Click(object sender, EventArgs e)
        {
            switch (cbGraphKind.SelectedIndex)
            {
                case 0:
                    {
                        if (groupedSeries != null)
                        {
                            SortedDictionary<double, int> modifiedSeries = new SortedDictionary<double, int>();
                            double summ = groupedSeries.ElementsCount;
                            foreach (var pair in groupedSeries.SeriesTable)
                            {
                                modifiedSeries.Add(pair.Key, (int)(pair.Value * summ));
                            }
                            DisplayForm.DisplayStatFreq(modifiedSeries);
                            LoggerEvs.writeLog("Построение полигона...");
                        }
                        break;
                    }
                case 1:
                    {
                        if (intSeries != null)
                        {
                            DisplayForm.DisplayIntervalFreq(intSeries.SeriesTable);
                            LoggerEvs.writeLog("Построение гистограммы...");
                        }
                        break;
                    }
                case 2:
                    {
                        if (groupedSeries != null)
                        {
                            SortedDictionary<double, double> modifiedSeries = new SortedDictionary<double, double>();
                            double summ = 0;
                            foreach (var pair in groupedSeries.SeriesTable)
                            {
                                summ += pair.Value;
                            }
                            foreach (var pair in groupedSeries.SeriesTable)
                            {
                                modifiedSeries.Add(pair.Key, pair.Value / summ);
                            }
                            EmpiricFunction.ShowEmpiricFunction(modifiedSeries);
                            LoggerEvs.writeLog("Построение функции распределения...");
                        }
                        break;
                    }
                case 3:
                    {
                        if (groupedSeries != null)
                        {
                            CheckDistributionForm wnd = new CheckDistributionForm();
                            double sampleMeanSquare = SeriesCharacteristics.calculateSampleMeanSquare(groupedSeries.SeriesTable);
                            double sampleMean = SeriesCharacteristics.calculateSampleMean(groupedSeries.SeriesTable);
                            double dispersion = SeriesCharacteristics.calculateDispersion(groupedSeries.SeriesTable);
                            wnd.draw_distribution(groupedSeries.SeriesTable, "Выборка", sampleMean, sampleMeanSquare, Color.FromArgb(255,255,0,255));
                            wnd.drawNormalDistribution(dispersion, sampleMeanSquare, sampleMean);
                            wnd.Show();
                        }
                        break;
                    }
                case 4:
                    {
                        if (groupedSeries != null)
                        {
                            CheckDistributionForm wnd = new CheckDistributionForm();
                            double sampleMeanSquare = SeriesCharacteristics.calculateSampleMeanSquare(groupedSeries.SeriesTable);
                            double sampleMean = SeriesCharacteristics.calculateSampleMean(groupedSeries.SeriesTable);
                            double dispersion = SeriesCharacteristics.calculateDispersion(groupedSeries.SeriesTable);
                            wnd.draw_distribution(groupedSeries.SeriesTable, "Выборка", sampleMean, sampleMeanSquare, Color.FromArgb(255,255,0,255));
                            wnd.drawExpDistribution(dispersion, sampleMeanSquare, sampleMean);
                            wnd.Show();
                        }
                        break;
                    }
            }
        }

        #endregion

        // Проверка закона
        #region CheckLaw

        private void нормальныйЗаконToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (readyForLawChecking())
            {
                int k = intSeries.SeriesTable.Count - 2 - 1;
                tbK.Text = k.ToString();
                double significanceLevel = Convert.ToDouble(cbAlphaValues.SelectedValue);
                // Проверить гипотезу
                NormalLawHypotesisCheck nrmLawCheck = new NormalLawHypotesisCheck(LaplasTable, currentHiTable);                                
                if (nrmLawCheck.doCheck(significanceLevel, intSeries))
                    MessageBox.Show("Гипотеза о нормальном законе распределения не опровергается");
                else
                    MessageBox.Show("Гипотеза о нормальном законе распределения опровергается");
                tbHiObs.Text = nrmLawCheck.HiObserved.ToString();
            }
        }

        private void показательныйЗаконToolStripMenuItem_Click(object sender, EventArgs e)
        {
           if (readyForLawChecking())
           {
               int k = intSeries.SeriesTable.Count - 2;
               tbK.Text = k.ToString();
               double significanceLevel = Convert.ToDouble(cbAlphaValues.SelectedValue);
               // Проверить гипотезу
               ExponentialLawCheck expLawCheck = new ExponentialLawCheck(currentHiTable);
               if (expLawCheck.doCheck(significanceLevel, intSeries))
                   MessageBox.Show("Гипотеза о показательном законе распределения не опровергается");
               else
                   MessageBox.Show("Гипотеза о показательном законе распределения опровергается");
               tbHiObs.Text = expLawCheck.HiObserved.ToString();
           }
        }

        private bool readyForLawChecking()
        {
            bool readyToCheckLaw;
            if (LaplasTable.Count == 0)
            {
                MessageBox.Show("Необходимо загрузить таблицу значений функции Лапласа");
                readyToCheckLaw = false;
            }
            else if (currentHiTable.Count() == 0)
            {
                MessageBox.Show("Необходимо загрузить таблицу критических точек Хи квадрат");
                readyToCheckLaw = false;
            }
            else if (intSeries == null)
            {
                MessageBox.Show("Необходимо сформировать интервальный ряд");
                readyToCheckLaw = false;
            }
            else
                readyToCheckLaw = true;
            return readyToCheckLaw;
        }

        #endregion

        // Обработка интервалов (извлечение, расчет характеристик, вывод групированного ряда)
        #region IntervalsProcessing

        private void calculateGroupedSeries_Click(object sender, EventArgs e)
        {
            if (intSeries != null)
            {
                groupedSeries = GroupedRelativeArequenceSeries.calculateFromIntervalSeries(intSeries, intSeries.SeriesTable.Count);
                visualizeGroupedSeries();
            }
            else
            {
                MessageBox.Show("Перед тем, как рассчитывать группированный ряд относительных частот,\n извлеките интервальный ряд обычных частот", "Не был извлечен интервальный ряд частот");
            }
        }

        private void visualizeGroupedSeries()
        {
            int i = 0;
            foreach (KeyValuePair<double, double> pair in groupedSeries.SeriesTable)
            {
                dgvGroupedSeries.Rows.Add();
                dgvGroupedSeries.Rows[i].Cells[0].Value = pair.Key.ToString();
                dgvGroupedSeries.Rows[i].Cells[1].Value = pair.Value.ToString();
                i++;
            }
        }

        private void calculateChars_Click(object sender, EventArgs e)
        {
            if (intSeries != null)
            {
                double sampleMeanSquare = SeriesCharacteristics.calculateSampleMeanSquare(groupedSeries.SeriesTable);
                double dispersion = SeriesCharacteristics.calculateDispersion(groupedSeries.SeriesTable);
                double sampleMean = SeriesCharacteristics.calculateSampleMean(groupedSeries.SeriesTable);
                double centralSamplingPoint = SeriesCharacteristics.calculateCentralSamplingPoint(groupedSeries.SeriesTable, (double)rNumber.Value);
                double initialSamplingPoint = SeriesCharacteristics.calculateInitialSamplingPoint(groupedSeries.SeriesTable, (double)rNumber.Value);
                characteristicsLabel.Text = String.Format("Средневыборочное квадратическое {0:f4}\n\rСредневыборочное {1:f4}\n\rДисперсия {2:f4}\n\rЦентр. выборочн. момент {3}: {4:f4}\n\rНачальный выборочный момент {5}: {6:f4}", sampleMeanSquare, sampleMean, dispersion, (int)rNumber.Value, centralSamplingPoint, (int)rNumber.Value, initialSamplingPoint);
            }
            else
            {
                MessageBox.Show("Перед тем, как рассчитывать характеристики выборки,\nизвлеките интервальный ряд обычных частот и рассчитайте группированный ряд отновительных частот", "Не был рассчитан группированный ряд относительных частот частот");
            }
        }

        #endregion
                
        private double[] parseStr(string str)
        {
            string[] values = str.Split(';'); // Пара значений - аргумент функции лапласа - значение            
            double[] valuesDb = new double[values.Length];            
            for (int i = 0; i < values.Length; i++)
                valuesDb[i] = double.Parse(values[i]);
            return valuesDb;
        }

        private void btnRemoveInterval_Click(object sender, EventArgs e)
        {   // Удалить ряд (строку таблицы)                        
            dgvIntervals.Rows.RemoveAt(dgvIntervals.CurrentRow.Index);
            if (dgvIntervals.Rows.Count == 0)
                btnRemoveInterval.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dgvIntervals.Rows.Add();
            btnRemoveInterval.Enabled = true;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            ToolTip formula_k = new ToolTip(); // Всплывающая подсказка с формулой для степеней свободы
            formula_k.AutoPopDelay = 5000;
            formula_k.InitialDelay = 100;
            formula_k.ReshowDelay = 500;
            formula_k.ShowAlways = true;                        
            formula_k.SetToolTip(this.tbK, "k = n - r - 1\nk - Число степеней свободы\nn - Число интервалов\nr - Число параметров закона распределения");        
        }
    }
}
