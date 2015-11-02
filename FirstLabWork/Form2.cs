﻿using System;
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
        List<double[]> LaplasTable = new List<double[]>(); // Таблица значений функции Лапласа
        LinearInterval lastReadedInterval;
        double lastCount;
        IntervalVariationStatisticSeries intSeries;
        GroupedRelativeArequenceSeries groupedSeries;
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SortedDictionary<LinearInterval, double> intervalSeriesTable = new SortedDictionary<LinearInterval, double>();
            int index = 0;
            int stringCounter = 0;
            try
            {
                String currentString = getNextString(sourceIntervalSeriesBox.Text, ref index);
                stringCounter++;
                while (currentString != "")
                {
                    getLinearIntervalDoublePairFromString(currentString);
                    intervalSeriesTable.Add(lastReadedInterval, lastCount);
                    currentString = getNextString(sourceIntervalSeriesBox.Text, ref index);
                    stringCounter++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Не верно записан ряд. Заполняйте поле ввода согласно стандарту.");
                return;
            }
            finally
            {
                intSeries = IntervalVariationStatisticSeries.calculateSeriesFromReadySeries(intervalSeriesTable);
            }
        }

        private String getNextString(String source, ref int index)
        {
            String currentString = "";
            while (index != source.Length && (source[index] != '\n' && source[index] != '\r' && source[index] != '\t'))
            {
                currentString += source[index];
                index++;
            }
            while (index != source.Length && (source[index] == '\n' || source[index] == '\r' || source[index] == '\t'))
            {
                index++;
            }
            return currentString;
        }

        private void getLinearIntervalDoublePairFromString(String source)
        {
            String left = "", right = "", count = "";
            int index = 0;
            parseleftBorder(source, ref left, ref index);
            parseRightBorder(source, ref right, ref index);
            parseCount(source, ref count, ref index);
            double leftBorder = 0;
            if (!Double.TryParse(left, out leftBorder))
                leftBorder = (double)Int32.Parse(left);
            double rightBorder = 0;
            if (!Double.TryParse(right, out rightBorder))
                rightBorder = (double)Int32.Parse(right);
            double countValue = 0;
            if (!Double.TryParse(count, out countValue))
                countValue = (double)Int32.Parse(count);
            lastReadedInterval = new LinearInterval(leftBorder, rightBorder);
            lastCount = countValue;
        }

        private static void parseCount(String source, ref String count, ref int index)
        {
            while (index != source.Length)
            {
                count += source[index];
                index++;
            }
        }

        private static void parseRightBorder(String source, ref String right, ref int index)
        {
            while (source[index] != ' ')
            {
                if (index == source.Length - 1)
                {
                    throw new ArgumentException("Не верный формат строки для извлечения элемента для интервального ряда частот");
                }
                right += source[index];
                index++;

            }
            index++;
        }

        private static void parseleftBorder(String source, ref String left, ref int index)
        {
            while (source[index] != ';')
            {
                if (index == source.Length - 1)
                {
                    throw new ArgumentException("Не верный формат строки для извлечения элемента для интервального ряда частот");
                }
                left += source[index];
                index++;

            }
            index++;
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
            String result = "";
            foreach (KeyValuePair<double, double> pair in groupedSeries.SeriesTable)
            {
                result += String.Format("{0}    {1:f4}\r\n", pair.Key, pair.Value);
            }
            groupedSeriesBox.Text = result;
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
                buffer = parseString(srLaplasTable.ReadLine());
                data.Add(buffer);
            }
            return data;
        }

        private double[] parseString(string str)
        {
            string[] values = str.Split(';'); // Пара значений - аргумент функции лапласа - значение            
            double[] valuesPare = new double[2];
            valuesPare[0] = double.Parse(values[0]);
            valuesPare[1] = double.Parse(values[1]);
            return valuesPare;
        }
    }
}
