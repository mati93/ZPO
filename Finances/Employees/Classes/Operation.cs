using System;

namespace Finances.Employees.Classes
{
    public class Operation
    {

        public Operation(string label, string type, decimal amount)
        {
            Label = label;
            Type = type;
            Amount = amount;
        }

        public string Label { get; set; }
        public string Type { get; set; }
        public decimal Amount { get; set; }

    }
}
