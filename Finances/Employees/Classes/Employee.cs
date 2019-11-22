using System;
using System.Collections.Generic;

namespace Finances.Employees.Classes
{
    public class Employee : Person
    {
        public string Interest { get; set; }
        public override string Interests()
        {
            return Interest;
        }

        public string Position { get; set; }
        public Employee(int id, string name, string surname, int age, int postcode, string position) : base(id, name, surname, age, postcode)
        {
            Position = position;
        }
        public static decimal Holidaybonus { get; set; } = 1000;
        public List<Operation> Operations { get; set; } = new List<Operation>();
        public enum Contract { FullTime, PartTime, Contract };

        private Wage wage;
        public Wage Wage
        {
            get { return wage; }
            set
            {
                if (LoginSystem.Verification() == true)
                {
                    wage = value;
                }
                else
                {
                    Console.WriteLine("Niepoprawny login lub hasło");
                }
            }
        }

        public static Employee CreateEmployee(int id, string name, string surname, int age, int postcode, string position, decimal baseWage)
        {
            Employee Employee = new Employee(id, name, surname, age, postcode, position);
            Employee.Wage = new Wage(baseWage);

            return Employee;
        }

        public static decimal operator +(Employee employee1, decimal number)
        {
            return employee1.Wage.WageTotal() + number;
        }


        public static bool operator ==(Employee employee1, Employee employee2)
        {
            if (employee1.Name != employee2.Name)
            {
                return false;
            }

            if (employee1.Surname != employee2.Surname)
            {
                return false;
            }

            return true;
        }

        public static bool operator !=(Employee employee1, Employee employee2)
        {
            bool IdenticalNames = false;
            bool IdenticalSurnames = false;

            if (employee1.Name == employee2.Name)
            {
                IdenticalNames = true;
            }

            if (employee1.Surname == employee2.Surname)
            {
                IdenticalSurnames = true;
            }

            if (IdenticalNames && IdenticalSurnames)
            {
                return false;
            }

            return true;
        }

        public static implicit operator double(Employee employee)
        {
            return Convert.ToDouble(employee.Wage.WageTotal());
        }

        public delegate void NameOrSurnameChangedEventHandler(Employee employee, EventArgs args);
        public event NameOrSurnameChangedEventHandler NameOrSurnameChanged;

        public virtual void OnNameOrSurnameChaneged()
        {
            if (NameOrSurnameChanged != null)
            {
                NameOrSurnameChanged(this, EventArgs.Empty);
            }
        }

         public string Name {
                get {
                    return GetName();
                }
                set {
                    SetName(value);

                    OnNameOrSurnameChaneged();
                }
          }

        public event EventHandler<WageEventArgs> WageChanged;

        public async void OnWageChanged(Wage oldWage, Wage newWage)
        {
            WageChanged?.Invoke(this, new WageEventArgs() { OldWage = oldWage, NewWage = newWage });
        }
    }
        public class WageEventArgs : EventArgs
    {
        public Wage OldWage { get; set; }
        public Wage NewWage { get; set; }
    }
}
