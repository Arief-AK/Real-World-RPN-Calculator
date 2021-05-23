using System;

namespace ReversePolishNotation
{
    static class Program
    {
        static void Main()
        {
            Console.WriteLine("\nRPN Calculator");
            var calc = new RpnCalculator();
            var hInput = new InputHandle();
            var hOutput = new OutputHandle();
            
            calc.AddOperation(new Addition());
            calc.AddOperation(new Subtraction());
            calc.AddOperation(new Multiplication());
            calc.AddOperation(new Division());
            calc.AddOperation(new SqRoot());
            
            var controller = new Controller(calc, hInput, hOutput);
            controller.Run();
        }
    }
}