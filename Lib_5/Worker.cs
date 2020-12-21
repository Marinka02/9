using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lib_5
{
    public struct Worker
    {
        string gender; // пол
        int experience, // стаж
            salary; // оклад

        // конструктор
        public Worker(string name, string lastName, string patronymic, string position, string gender, int experience, int salary) 
        {
            // присваиваем полям значения
            Name = name;
            LastName = lastName;
            Patronymic = patronymic;
            Position = position;

            // проверяем соотвествует ли пол шаблону
            if (gender == "Женский" || gender == "Мужской")
            {
                // присваиваем полю значение
                this.gender = gender;
            }
            else
            {
                // присваиваем значение по умолчанию (потому что у структуры не может быть неназначенных свойств)
                // выводим подсказку
                MessageBox.Show("Некорректный пол. Присвоено значение по умолчанию: Женский.");
                // присваиваем полю значение
                this.gender = "Женский";
            }

            // проверяем что стаж больше или равен 0
            if (experience >= 0)
            {
                // присваиваем полю значение
                this.experience = experience;
            }
            else
            {
                // присваиваем значение по умолчанию (потому что у структуры не может быть неназначенных свойств)
                // выводим подсказку
                MessageBox.Show("Пожалуй, стаж не может быть отрицательным. Присвоено значение по умолчанию: 0");
                // присваиваем полю значение
                this.experience = 0;
            }

            // проверяем что оклад больше или равен 0
            if (salary >= 0)
            {
                // присваиваем полю значение
                this.salary = salary;
            }
            else
            {
                // присваиваем значение по умолчанию (потому что у структуры не может быть неназначенных свойств)
                // выводим подсказку
                MessageBox.Show("Пожалуй, оклад не может быть отрицательным. Присвоено значение по умолчанию: 10000");
                // присваиваем полю значение
                this.salary = 10000;
            }
        }

        // Имя
        public string Name { get; set; }

        public string LastName { get; set; }

        public string Patronymic { get; set; }

        public string Position { get; set; }

        public string Gender
        {
            get
            {
                return gender;
            }
            set
            {
                // проверяем соотвествует ли пол шаблону
                if (value == "Женский" || value == "Мужской")
                {
                    // присваиваем полю значение
                    gender = value;
                }
                else
                {
                    // выводим подсказку
                    MessageBox.Show("Некорректный пол \"Мужской\" или \"Женский\"");
                }
            }
        }

        public int Experience
        {
            get
            {
                return experience;
            }
            set
            {
                // проверяем что стаж больше или равен 0
                if (value >= 0)
                {
                    // присваиваем полю значение
                    experience = value;
                }
                else
                {
                    // выводим подсказку
                    MessageBox.Show("Пожалуй, стаж не может быть отрицательным. Введите число больше или равное нулю.");
                }
            }
        }

        public int Salary
        {
            get
            {
                return salary;
            }
            set
            {
                // проверяем что оклад больше или равен 0
                if (value >= 0)
                {
                    // присваиваем полю значение
                    salary = value;
                }
                else
                {
                    // выводим подсказку
                    MessageBox.Show("Пожалуй, оклад не может быть отрицательным. Введите число больше или равное нулю.");
                }
            }
        }
    }
}
