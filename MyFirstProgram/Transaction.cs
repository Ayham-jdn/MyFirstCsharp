using System;

namespace MyFirstProgram
{
    public class Transaction
    {
        public string Type { get; set; } = "";   // Deposit, Withdraw, Transfer
        public decimal Amount { get; set; }
        public string Currency { get; set; } = "";
        public DateTime Date { get; set; }
        public string? Notes { get; set; }      

        public override string ToString()
        {
            return $"{Date} - {Type}: {Amount} {Currency} {Notes}";
        }
    }
}
