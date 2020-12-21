using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lib_5;

namespace _9
{
    public partial class Form1 : Form
    {
        Worker[] workers;
        public Form1()
        {
            InitializeComponent();
        }
        // о программе
        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Заполнить таблицу со списком сотрудников на 7 человек с полями: ФИО, пол, должность, стаж работы, оклад. " +
                "Вывести результат на экран. Вывести средний оклад.");
        }
        // выход
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // инициализируем массив
            workers = new Worker[7];
            // задаем количество строк таблицы
            dataGridView1.RowCount = 7;
            // заполняем таблицу с помощью метода сброс
            сбросToolStripMenuItem.PerformClick();
        }

        string temp; // глобальная переменная для хранения предыдущего значения ячейки таблицы
        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            // запоминем значение до изменения 
            if (dataGridView1.CurrentCell.Value != null) temp = dataGridView1.CurrentCell.Value.ToString();
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // смотрим какой столбец был изменен чтобы понять какое свойство структуры менять
            switch (dataGridView1.CurrentCell.ColumnIndex)
            {
                // фамилия
                case 0:
                    {
                        // изменяем свойство объекта в массиве по индексу выбранной строки таблицы
                        workers[dataGridView1.CurrentCell.RowIndex].LastName = dataGridView1.CurrentCell.Value.ToString();
                        break;
                    }
                // имя
                case 1:
                    {
                        // изменяем свойство объекта в массиве по индексу выбранной строки таблицы
                        workers[dataGridView1.CurrentCell.RowIndex].Name = dataGridView1.CurrentCell.Value.ToString();
                        break;
                    }
                // отчество
                case 2:
                    {
                        // изменяем свойство объекта в массиве по индексу выбранной строки таблицы
                        workers[dataGridView1.CurrentCell.RowIndex].Patronymic = dataGridView1.CurrentCell.Value.ToString();
                        break;
                    }
                // пол
                case 3:
                    {
                        // изменяем свойство объекта в массиве по индексу выбранной строки таблицы
                        workers[dataGridView1.CurrentCell.RowIndex].Gender = dataGridView1.CurrentCell.Value.ToString();
                        break; 
                    }
                // должность
                case 4:
                    {
                        // изменяем свойство объекта в массиве по индексу выбранной строки таблицы
                        workers[dataGridView1.CurrentCell.RowIndex].Position = dataGridView1.CurrentCell.Value.ToString();
                        break;
                    }
                // стаж
                case 5:
                    {
                        // проверяем конвертацию
                        try
                        {
                            // получаем значение
                            int exp = Convert.ToInt32(dataGridView1.CurrentCell.Value);
                            // изменяем свойство объекта в массиве по индексу выбранной строки таблицы
                            workers[dataGridView1.CurrentCell.RowIndex].Experience = exp;
                            // поскольку у свойста есть ограничения на отрицательные значения, оно может не быть изменено
                            // так что присваиваем ячейке значение свойства (на случай если оно не изменилось)
                            dataGridView1.CurrentCell.Value = workers[dataGridView1.CurrentCell.RowIndex].Experience;
                            break;
                        }
                        catch
                        {
                            // выводим подсказку 
                            MessageBox.Show("Стаж должен быть целым числом");
                            // возвращаем ячейке предыдущее значение (до измемения)
                            dataGridView1.CurrentCell.Value = temp;
                            break;
                        }
                    }
                // оклад
                case 6:
                    {
                        // проверяем конвертацию
                        try
                        {
                            // получаем значение
                            int sal = Convert.ToInt32(dataGridView1.CurrentCell.Value);
                            // изменяем свойство объекта в массиве по индексу выбранной строки таблицы
                            workers[dataGridView1.CurrentCell.RowIndex].Salary = sal;
                            // поскольку у свойста есть ограничения на отрицательные значения, оно может не быть изменено
                            // так что присваиваем ячейке значение свойства (на случай если оно не изменилось)
                            dataGridView1.CurrentCell.Value = workers[dataGridView1.CurrentCell.RowIndex].Salary;
                            break;
                        }
                        catch
                        {
                            // выводим подсказку 
                            MessageBox.Show("Зарплата должен быть целым числом");
                            // возвращаем ячейке предыдущее значение (до измемения)
                            dataGridView1.CurrentCell.Value = temp;
                            break;
                        }
                    }
                default:
                    break;
            }
        }

        private void рассчитатьСреднийОкладToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int salaries = 0;
            // складываем оклады всех работников
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                salaries += Convert.ToInt32(dataGridView1[6, i].Value);
            }
            // делим на количество
            double mid = salaries / 7;
            // выводим среднюю зарплату в текстбокс
            textBox1.Text = mid.ToString();
        }

        private void сбросToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // создаем "стандартного работника"
            Worker worker = new Worker("Иван", "Иванов", "Иванович", "Учитель", "Мужской", 0, 10000);
            // меняем все значение в массиве и в таблице на "стандартного работника"
            for (int i = 0; i < 7; i++)
            {
                workers[i] = worker;
                dataGridView1[0, i].Value = workers[i].LastName;
                dataGridView1[1, i].Value = workers[i].Name;
                dataGridView1[2, i].Value = workers[i].Patronymic;
                dataGridView1[3, i].Value = workers[i].Gender;
                dataGridView1[4, i].Value = workers[i].Position;
                dataGridView1[5, i].Value = workers[i].Experience;
                dataGridView1[6, i].Value = workers[i].Salary;
            }
        }
    }
}