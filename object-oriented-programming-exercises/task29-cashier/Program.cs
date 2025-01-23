using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace task29_cashier
{
    public interface ITransaction
    {
        // interface members
        string ShowTransaction();
        float Money { get; set; }
    }

    public class CashMachine
    {
        public CashMachine() { }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
