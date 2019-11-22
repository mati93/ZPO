using System.Collections.Generic;
using System.Linq;
using System;

namespace Finances.Employees.Classes
{
    class Employees
    {

        public List<Employee> EmployeesList { get; set; } = new List<Employee>();

        public Employee this[string name, string surname]
        {
            get
            {
                foreach (Employee Employee in EmployeesList)
                {
                    if (Employee.Name == name && Employee.Surname == surname)
                    {
                        return Employee;
                    }

                }

                return null;
            }
        }



        public Employee CreateEmployeeAndAddToList(int id, string name, string surname, int age, int postcode, string position, decimal baseWage)
        {
            Employee Employee = Employee.CreateEmployee(id, name, surname, age, postcode, position, baseWage);
            EmployeesList.Add(Employee);

            return Employee;
        }

        public void AddEmployee(Employee Employee)
        {
            if (!EmployeesList.Contains(Employee))
            {
                EmployeesList.Add(Employee);
            }

        }

        public void RemoveEmployee(Employee Employee)
        {
            if (!EmployeesList.Contains(Employee))
            {
                EmployeesList.Remove(Employee);
            }
        }

        public Employee GetEmployee(string name, string surname)
        {
            return this[name, surname];
        }

        public void SortEmployeesByNameAndSurname(bool ascending = true)
        {
            if (ascending == true)
            {
                EmployeesList = EmployeesList.OrderBy(x => x.Name).ThenBy(x => x.Surname).ToList();
            }
            else
            {
                EmployeesList = EmployeesList.OrderByDescending(x => x.Name).ThenByDescending(x => x.Surname).ToList();
            }

        }

        public void SortNameAndSurname()
        {
            var sortedList = from l in EmployeesList
                             orderby l.Surname ascending
                             select l;
            Console.WriteLine("Lista pracowników posortowana alfabetycznie: ");
            foreach (var item in sortedList)
            {
                Console.WriteLine(item.Surname + " " + item.Name);
            }
            Console.WriteLine(" ");
        }

        public void PrintNameandSurname()
        {
            var searching = from l in EmployeesList
                            select l.Name + " " + l.Surname;
            Console.WriteLine("Imiona i nazwiska wszystkich pracowników: ");
            foreach (var item in searching)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(" ");
        }


        public void PrintSurnameP()
        {
            var searching = from l in EmployeesList
                            where l.Surname.StartsWith("P")
                            select l;
            Console.WriteLine("Nazwiska rozpoczynające się na literę p: ");
            foreach (var item in searching)
            {
                Console.WriteLine(item.Surname);
            }
            Console.WriteLine(" ");
        }

        public void BasicBigger5000()
        {
            var searching = from l in EmployeesList
                            where l.Wage.Basic > 5000
                            select l;
            Console.WriteLine("Pracownicy zarabiający powyżej 5000: ");
            foreach (var item in searching)
            {
                Console.WriteLine(item.Surname);
            }
            Console.WriteLine(" ");
        }

        public void DescendingSumWage()
        {
            var searching = from l in EmployeesList
                            orderby l.Wage.WageTotal() descending
                            select l.Wage.WageTotal();
            Console.WriteLine("Łączna kwota zarobków malejąco: ");
            foreach (var item in searching)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(" ");
        }

    }
}
