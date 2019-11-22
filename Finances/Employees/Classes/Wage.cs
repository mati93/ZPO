namespace Finances.Employees.Classes
{
    public struct Wage
    {
        public Wage(decimal basic, decimal bonus = 0, decimal other = 0)
        {
            Basic = basic;
            Bonus = bonus;
            Other = other;
        }

        public decimal Basic { get; set; }
        public decimal Bonus { get; set; }
        public decimal Other { get; set; }

        public decimal WageTotal()
        {
            return Basic + Bonus + Other;
        }
    }
}
