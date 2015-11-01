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

using LoggerEvsSpace;
namespace FirstLabWork
{
    public partial class Form1 : Form
    {
        // 
        VariationSeries variationSeries;
        StatisticRelativeАrequenceSeries relativeSeries;
        IntervalVariationStatisticSeries intervalSeries;
        GroupedRelativeArequenceSeries groupedRelativeSeries;
        bool calculated;

        

        public Form1()
        {
            InitializeComponent();
            seriesType.SelectedIndex = 0;
            cbGraphKind.SelectedIndex = 0;
            calculated = false;
            // Для вывода логов в поле "Ход вычислений"
            LoggerEvs.messageCame += addLogNote;
        }
        
        private void addLogNote(string logNote)
        {
            rtbLogs.AppendText(logNote);
            rtbLogs.ScrollToCaret();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {   // Открыть файл
            LoggerEvs.writeLog("Открытие входной выборки...");
            if (openDataInputFile())
                LoggerEvs.writeLog("Входная выборка успешно открыта!");
            else
                LoggerEvs.writeLog("Ошибка при открытии входной выборки!");

        }
        
        /// <summary>
        /// Метод для открытия файла входных данных и их чтения
        /// </summary>
        /// <returns>Сведения о том, удалось ли открыть файл</returns>
        public bool openDataInputFile()
        {
            bool fileRead = false;                  // Файл прочитан
            // Имя файла по умолчанию
            ofdLoadDataInput.FileName = null;
            // Отбор текстовых документов txt
            ofdLoadDataInput.Filter = "Текстовые документы txt|*.txt";
            // Заголовок окна fileDialog
            ofdLoadDataInput.Title = "Выберите текстовый документ";
            // Запретить одновременный выбор нескольких файлов 
            ofdLoadDataInput.Multiselect = false;

            try
            {
                // Загрузить входные данные
                string dataInput = null;
                if (ofdLoadDataInput.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    // Создать поток чтения из файла
                    using (StreamReader dataInputReader = new StreamReader(ofdLoadDataInput.FileName))
                    {                        
                        dataInput = dataInputReader.ReadToEnd();
                        dataInputReader.Close();
                    }

                    // Распарсить входные данные
                    // Сформировать единую строку даных без переносов
                    dataInput = dataInput.Replace(";\r\n", ";");

                    // Сформировать массив строк с входными данными вида 4|1|3;
                    string[] rows = dataInput.Split(';');
                    // Очистить коллекцию входных данных
                    // Для записи входных данных
                    int matrixSize = rows.Length - 1;
                    SourceValues.valuesTable = new double[matrixSize, matrixSize]; // Матрица коэффициентов (сюда будут записаны данные из файла)
                    
                    // Получить цифровые данные 
                    
                    for (int i = 0; i < matrixSize; i++)
                    {
                        if (rows[i].Length > 0)
                        {
                            string[] nums = rows[i].Split('|'); 
                            
                            // Заполнить матрицу числами
                            for (int j = 0; j < matrixSize; j++)
                            {
                                if (nums[j].Any(s => s == '.'))
                                {
                                    nums[j] = nums[j].Replace('.',',');
                                }
                                SourceValues.valuesTable[i, j] = Convert.ToDouble(nums[j]);
                            }
                        }
                    }
                    fileRead = true;
                }
            }
            catch (Exception ex)
            {
                // Сообщение с текстом ошибки
                string errorMessage = ex.ToString() + "\n\nНе удалось обработать входные данные.";
                // Вывести сообщение об ошибке
                MessageBox.Show(errorMessage);
                LoggerEvs.writeLog(errorMessage);
            }
            if(fileRead)
            {
                statusLabel.Text = "Была загружена новая выборка";
            }
            // Вернуть данные о том, прочитан ли файл
            return fileRead;
        }

        private void cbGraphKind_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoggerEvs.writeLog("Заполнение таблицы данными ряда...");
            fillTable();
            LoggerEvs.writeLog("Расчет математических характеристик...");
            calculateTableCharacteristics();
        }

        private void fillTable()
        {
            if (SourceValues.valuesTable != null)
            {
                variationSeries = VariationSeries.calculateSerires();
                relativeSeries = variationSeries.getRelativeSeries();
                intervalSeries = variationSeries.getIntervalVariationSeries((int)intervalsCountUpDown.Value);
                groupedRelativeSeries = variationSeries.getGroupedRelativeArequenceSeries((int)intervalsCountUpDown.Value);
                calculated = true;
                printTable();
            }
            else
            {
                string errMsg = "Необходимо загрузить выборку из файла. Выберите файл с выборкой.";
                MessageBox.Show(errMsg, "Внимание");
                LoggerEvs.writeLog(errMsg);
                LoggerEvs.writeLog("Открытие входной выборки...");
                if (openDataInputFile())
                {
                    LoggerEvs.writeLog("Входная выборка успешно открыта!");
                    fillTable();
                }
            }
        }

        private void printTable()
        {
            clearTables();
            if (seriesType.SelectedIndex == 0)
            {
                printVariationSeries();
                LoggerEvs.writeLog("Построение статистического ряда частот...");
            }
            else if (seriesType.SelectedIndex == 1)
            {
                printRelativeSeries();
                LoggerEvs.writeLog("Построение статистического ряда относительных частот...");
            }
            else if (seriesType.SelectedIndex == 2)
            {
                printIntervalSeries();
                LoggerEvs.writeLog("Построение интервального статистического ряда частот...");
            }
            else if (seriesType.SelectedIndex == 3)
            {
                printGroupedRelativeSeries();
                LoggerEvs.writeLog("Построение группированного ряда частот...");
            }
        }

        private void printGroupedRelativeSeries()
        {
            int i = 0;

            foreach (KeyValuePair<double, double> pair in groupedRelativeSeries.SeriesTable)
            {
                UITable.Columns.Add(new DataGridViewTextBoxColumn());
                UITable.Columns[i].Name = pair.Key.ToString();
                UITable.Columns[i].Width = 60;
                i++;
            }
            string[] values;
            List<String> strs = new List<string>();
            foreach (KeyValuePair<double, double> pair in groupedRelativeSeries.SeriesTable)
            {
                strs.Add(pair.Value.ToString());
            }
            values = strs.ToArray();
            UITable.Rows.Add(values);
        }

        //don't see!!!
        private void printIntervalSeries()
        {
            int i = 0;
            foreach (KeyValuePair<LinearInterval, double> pair in intervalSeries.SeriesTable)
            {
                UITable.Columns.Add(new DataGridViewTextBoxColumn());
                UITable.Columns[i].Name = pair.Key.ToString();
                UITable.Columns[i].Width = 60;
                i++;
            }
            string[] values;
            List<String> strs = new List<string>();
            foreach (KeyValuePair<LinearInterval, double> pair in intervalSeries.SeriesTable)
            {
                strs.Add(pair.Value.ToString());
            }
            values = strs.ToArray();
            UITable.Rows.Add(values);
        }
        //don't see!!!
        private void printRelativeSeries()
        {
            int i = 0;
            foreach (KeyValuePair<double, double> pair in relativeSeries.SeriesTable)
            {
                UITable.Columns.Add(new DataGridViewTextBoxColumn());
                UITable.Columns[i].Name = pair.Key.ToString();
                UITable.Columns[i].Width = 60;
                i++;
            }
            string[] values;
            List<String> strs = new List<string>();
            foreach (KeyValuePair<double, double> pair in relativeSeries.SeriesTable)
            {
                strs.Add(pair.Value.ToString());
            }
            values = strs.ToArray();
            UITable.Rows.Add(values);
        }
        //don't see!!!
        private void printVariationSeries()
        {
            int i = 0;
            foreach (KeyValuePair<double, int> pair in variationSeries.SeriesTable)
            {
                UITable.Columns.Add(new DataGridViewTextBoxColumn());
                UITable.Columns[i].Name = pair.Key.ToString();
                UITable.Columns[i].Width = 60;
                i++;
            }
            string[] values;
            List<String> strs = new List<string>();
            foreach (KeyValuePair<double, int> pair in variationSeries.SeriesTable)
            {
                strs.Add(pair.Value.ToString());
            }
            values = strs.ToArray();
            UITable.Rows.Add(values);
            ColsSort();
        }

        private void ColsSort()
        {
            List<double> columns = new List<double>(UITable.Columns.Count);
            for (int i = 0; i < UITable.Columns.Count; i++)
                columns.Add(double.Parse(UITable.Columns[i].Name));
            columns.Sort();
            for (int i = 0; i < columns.Count; i++)
                UITable.Columns[columns[i].ToString()].DisplayIndex = i;
        }

        private void ofdLoadDataInput_FileOk(object sender, CancelEventArgs e)
        {

        }
        private void clearTables()
        {
            UITable.Rows.Clear();
            UITable.Columns.Clear();
        }

        private void calculateCharacteristics_Click(object sender, EventArgs e)
        {
            calculateTableCharacteristics();
        }

        private void calculateTableCharacteristics()
        {
            if (calculated)
            {
                SampleMeanTB.Text = SeriesCharacteristics.calculateSampleMean(relativeSeries.SeriesTable).ToString();
                SampleMeanSquareTB.Text = SeriesCharacteristics.calculateSampleMeanSquare(relativeSeries.SeriesTable).ToString();
                DispersionTB.Text = SeriesCharacteristics.calculateDispersion(relativeSeries.SeriesTable).ToString();
                InitialSamplingPointTB.Text = SeriesCharacteristics.calculateInitialSamplingPoint(relativeSeries.SeriesTable, Convert.ToDouble(nudR.Value)).ToString();
                CentralSamplingPointTB.Text = SeriesCharacteristics.calculateCentralSamplingPoint(relativeSeries.SeriesTable, Convert.ToDouble(nudR.Value)).ToString();
                statusLabel.Text = "Рассчитаны числовые характеристики выборки";
            }
            else
            {
                MessageBox.Show("Прежде чем рассчитывать характеристики выборки,\nрассчитайте ряды!", "Внимание");
            }
        }

        private void tpNums_Click(object sender, EventArgs e)
        {

        }

        private void seriesType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(calculated)
            {
                printTable();
            }
        }

        private void showGraphicsButton_Click(object sender, EventArgs e)
        {
            switch(cbGraphKind.SelectedIndex)
            {
                case 0:
                    {
                        if (variationSeries != null)
                        {
                            DisplayForm.DisplayStatFreq(variationSeries.SeriesTable);
                            LoggerEvs.writeLog("Построение полигона...");
                        }
                        break;
                    }
                case 1:
                    {
                        if (intervalSeries != null)
                        {
                            DisplayForm.DisplayIntervalFreq(intervalSeries.SeriesTable);
                            LoggerEvs.writeLog("Построение гистограммы...");
                        }
                        break;
                    }
                case 2:
                    {
                        if (intervalSeries != null)
                        {
                            EmpiricFunction.ShowEmpiricFunction(relativeSeries.SeriesTable);
                            LoggerEvs.writeLog("Построение функции распределения...");
                        }
                        break;
                    }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void работаСГотовымРядомToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
        }
    }
}
