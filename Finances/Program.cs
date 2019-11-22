using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Employees.Classes
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Login: admin | Hasło: 1234");
                Employee firstEmployee = new Employee(1,"Adam", "Borowski",19,83-110, "Mechanik");
                Employee secondEmployee = new Employee(2, "Bartek", "Pek", 30, 83-110, "Księgowy");

                firstEmployee.Wage = new Wage(5000, 2500, 350.50m);

                secondEmployee.Wage = new Wage(6000, 1500, 150.50m);

                Console.WriteLine("Całość zgromadzonych środkow wynosi: " + firstEmployee.Wage.WageTotal());

                Employees Employees = new Employees();
                Employees.EmployeesList.Add(firstEmployee);
                Employees.EmployeesList.Add(secondEmployee);

                firstEmployee.Operations.Add(new Operation("Styczeń", "Wypłata", firstEmployee.Wage.WageTotal()));
                firstEmployee.Operations.Add(new Operation("Luty", "Wypłata", firstEmployee.Wage.WageTotal()));

                secondEmployee.Operations.Add(new Operation("Kwiecień", "Wypłata", secondEmployee.Wage.WageTotal()));
                secondEmployee.Operations.Add(new Operation("Maj", "Wypłata", secondEmployee.Wage.WageTotal()));

                Employee thirdEmployee = Employee.CreateEmployee(3, "Mariusz", "Laskowski", 30, 85-110, "Kierowca", 4500);
                Employees.EmployeesList.Add(thirdEmployee);
                Employee fourthEmployee = Employees.CreateEmployeeAndAddToList(4, "Jacek", "Czarny", 28, 98-150, "Magazynier", 3500);

                firstEmployee.Name = "Jan";

                Console.WriteLine("Czy obiekty są identyczne ? {0} ", firstEmployee == secondEmployee);

                Console.WriteLine("Kwota:  {0}", (double)firstEmployee);
 
                Employees.PrintNameandSurname();
                Employees.PrintSurnameP();
                Employees.SortNameAndSurname();
                Employees.BasicBigger5000();
                Employees.DescendingSumWage();

                Employee searchedEmployee = Employees["Mariusz", "Laskowski"];
                Console.WriteLine("Znaleziono Pracownika");

                Console.ReadKey();
        }
        } 
}
