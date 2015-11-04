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
        List<double> probabilities; // Вероятности
        List<double[]> LaplasTable = new List<double[]>(); // Таблица значений функции Лапласа
        HiCritTable currentHiTable = new HiCritTable(); // Таблица критических точек Хи квадрат
        LinearInterval lastReadedInterval;
        double lastCount;
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
            int intervalsCount = 3;
            for (int i = 0; i < intervalsCount; i++)
                dgvIntervals.Rows.Add();
            dgvIntervals.Rows[0].Cells[0].Value = 1;
            dgvIntervals.Rows[0].Cells[1].Value = 2;
            dgvIntervals.Rows[0].Cells[2].Value = 5;
            dgvIntervals.Rows[1].Cells[0].Value = 2;
            dgvIntervals.Rows[1].Cells[1].Value = 3;
            dgvIntervals.Rows[1].Cells[2].Value = 5;
            dgvIntervals.Rows[2].Cells[0].Value = 3;
            dgvIntervals.Rows[2].Cells[1].Value = 4;
            dgvIntervals.Rows[2].Cells[2].Value = 90;
            btnRemoveInterval.Enabled = true;
        }

       
        private void label1_Click(object sender, EventArgs e)
        {

        }

        
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
                    // Проверить на незаполненные значения
                    for (int j = 0; j < dgvIntervals.Rows[i].Cells.Count && tableIsValid; j++)
                    {
                        if (dgvIntervals.Rows[i].Cells[j].Value == null)
                        {
                            tableIsValid = false;
                            MessageBox.Show(string.Format("Незаполнена {0} ячейка в {1}-й строке", j + 1, i + 1));
                        }
                    }
                    // Проверить на "перевернутый" интервал
                    for (int j = 0; j < dgvIntervals.Rows[i].Cells.Count - 1 && tableIsValid; j++)
                    {
                        double leftBrdr = Convert.ToDouble(dgvIntervals.Rows[i].Cells[j].Value);
                        double rigthBrdr = Convert.ToDouble(dgvIntervals.Rows[i].Cells[j + 1].Value);
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

                    // Проверка целостности интервала
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

                    // Проверка равенства интервальных отрезков
                    if(i == 0)
                        bordersDifference = Convert.ToDouble(dgvIntervals.Rows[i].Cells[1].Value) - Convert.ToDouble(dgvIntervals.Rows[i].Cells[0].Value);
                    else
                    {
                        double currentBordersDifferenice = Convert.ToDouble(dgvIntervals.Rows[i].Cells[1].Value) - Convert.ToDouble(dgvIntervals.Rows[i].Cells[0].Value);
                        if (bordersDifference != currentBordersDifferenice)
                        {
                            tableIsValid = false;
                            MessageBox.Show("Обнаружен непропорциональный интервал");
                        }
                        else
                            bordersDifference = currentBordersDifferenice;
                    }
                }
            }
            return tableIsValid;
        }

        private void calculateGroupedSeries_Click(object sender, EventArgs e)
        {
            if (intSeries != null)
            {
                groupedSeries = GroupedRelativeArequenceSeries.calculateFromIntervalSeries(intSeries, intSeries.SeriesTable.Count);
                visualizeGroupedSeries();
            }
            else
            {
                MessageBox.Show("Перед тем, как рассчитывать группированный ряд относительных частот,\n извлечите интервальный ряд обычных частот", "Не был извлечен интервальный ряд частот");
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
                MessageBox.Show("Перед тем, как рассчитывать характеристики выборки,\nизвлечите интервальный ряд обычных частот и рассчитайте группированный ряд отновительных частот", "Не был рассчитан группированный ряд относительных частот частот");
            }
        }

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
            }
        }

        private void cbGraphKind_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Каждый интервал ряда распределения вводится в новой строке.\nФорма ввода следующая.\nПервое число - левая граница инервала, разделитель \';\'\nПравая граница интервала, разделитель пробел, число - частота попаданий в интервал.\nПример \'1;2 20\'", "Формат ввода интервального ряда распределения");
        }
                
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
        
        private void нормальныйЗаконToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (LaplasTable.Count == 0)
                MessageBox.Show("Необходимо загрузить таблицу значений функции Лапласа");
            else if (currentHiTable.HiTable.Count == 0)
                MessageBox.Show("Необходимо загрузить таблицу критических точек Хи квадрат");
            else
            {
                NormalLawHypotesisCheck nrmLawCheck = new NormalLawHypotesisCheck(LaplasTable, currentHiTable);
                HiValueKey tmp = new HiValueKey();
                bool lawConfirmed = nrmLawCheck.doCheck(tmp);
            }
        }

        private void показательныйЗаконToolStripMenuItem_Click(object sender, EventArgs e)
        {
            probabilities = new List<double>(); // Вероятности

            //
            if (intSeries != null)
            {   // Среднее выборочное
                double sampleMean = SeriesCharacteristics.calculateSampleMean(groupedSeries.SeriesTable);
                // Рассчитать параметр лямбда
                double lambda = 1/(sampleMean);

                // Рассчитать вероятности
                foreach (KeyValuePair<LinearInterval, double> pair in intSeries.SeriesTable)
                {
                    double answer = countProbabilityDensityExponentialLaw(lambda, pair.Key.RightBorder) - countProbabilityDensityExponentialLaw(lambda, pair.Key.LeftBorder);
                    probabilities.Add(answer);
                }

                // Число степеней свободы
                double k = intSeries.SeriesTable.Count - 2;
                tbK.Text = k.ToString();
                // Рассчитать значение хи-квадрат наблюдаемое
                double hiObs = countHiObs();
                
                // Сравнить с табличным значением
            }
        }

        private double countProbabilityDensityExponentialLaw(double lambda, double t)
        {
            return lambda * Math.Exp(lambda * t);
        }
        
        // Рассчитать значение хи-квадрат наблюдаемое
        private double countHiObs()
        {
            double answer = 0;
            int i = 0;
            foreach (KeyValuePair<LinearInterval, double> pair in intSeries.SeriesTable)
            {
                answer += Math.Pow((pair.Value - intSeries.SeriesTableFreqSum), 2)/(intSeries.SeriesTableFreqSum*probabilities[i]);
                i++;
            }
            return answer;
        }

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
             
            // Добавить строки со значениями критерия
            double[] buffer;
            
            for (int i = 0; !srHi.EndOfStream; i++)
            {
                buffer = parseStr(srHi.ReadLine());
                dgvHi.Rows.Add();
                dgvHi.Rows[i].HeaderCell.Value = buffer[0].ToString();
                // Сформировать "ключ" для таблицы критических точек
                //buffHiKey.Horizontally = horizValues[i];
                
                for (int j = 0; j < buffer.Length - 1; j++)
                {
                    HiValueKey buffHiKey = new HiValueKey();
                    buffHiKey.Horizontally = buffer[0];
                    buffHiKey.Vertically = horizValues[j];

                    dgvHi.Rows[i].Cells[j].Value = buffer[j + 1].ToString();                    
                    currentHiTable.Add(buffHiKey, buffer[j + 1]);
                }
            }
        }

        private double[] parseStr(string str)
        {
            string[] values = str.Split(';'); // Пара значений - аргумент функции лапласа - значение            
            double[] valuesDb = new double[values.Length];            
            for (int i = 0; i < values.Length; i++)
                valuesDb[i] = double.Parse(values[i]);
            return valuesDb;
        }

        private void загрузитьКритическиеТочкиРаспределенияХиКвадратToolStripMenuItem_Click(object sender, EventArgs e)
        {
            readTable();
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
