using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace FirstLabWork
{
    public partial class Form3 : Form
    {
        StreamReader srStr = null;
        DataGridView myDgv = null;
        public Form3()
        {
            InitializeComponent();

            if (myDgv == null)
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
            else
                dgvHi = myDgv;
        }

        
        private void readStrs()
        {
            srStr = new StreamReader(ofdHi.FileName); 
            double[] firstString = parseStr(srStr.ReadLine());
            dgvHi.TopLeftHeaderCell.Value = "k\\alpha";
            // Создать заголовки колонкам (значения альфа)
            for(int i = 0; i < firstString.Length-1; i++)            
                dgvHi.Columns.Add(i.ToString(), firstString[i+1].ToString());
             
            // Добавить строки со значениями критерия
            double[] buffer;
            for (int i = 0; !srStr.EndOfStream; i++)
            {
                buffer = parseStr(srStr.ReadLine());
                dgvHi.Rows.Add();
                dgvHi.Rows[i].HeaderCell.Value = buffer[0].ToString(); ;
                for (int j = 0; j < buffer.Length-1; j++)
                    dgvHi.Rows[i].Cells[j].Value = buffer[j+1].ToString();
            }
            myDgv = dgvHi;
        }

        private double[] parseStr(string str)
        {
            string[] values = str.Split(';'); // Пара значений - аргумент функции лапласа - значение            
            double[] valuesDb = new double[values.Length];            
            for (int i = 0; i < values.Length; i++)
                valuesDb[i] = double.Parse(values[i]);
            return valuesDb;
        }
      
    }
}
