using System;

namespace Finances.Employees.Classes
{
    public class LoginSystem
    {
        public static bool LoggedIn { get; set; } = false;

        public static bool Verification()
        {
            if (LoggedIn == false)
            {

                Console.Write("Podaj login: ");
                string login = Console.ReadLine();

                Console.Write("Podaj hasło: ");
                string password = Console.ReadLine();

                if (login == "admin" && password == "1234")
                {
                    LoggedIn = true;
                    return true;
                }

                return false;
            }

            return true;
        }

    }
}
