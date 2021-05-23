using System;

namespace ReversePolishNotation
{
    public class SqRoot:IOperation
    {
        public string Description => "Performing square-root operation";
        public string Operator => "sqrt";
        public int ArgumentsCount => 1;
        public double Execute(params double[] operands)
        {
            var number = operands[0];
            if (number == 0 || Math.Abs(number - 1.0) < 0)
            {
                return number;
            }

            var iterator = 1;
            var result = 1.0;

            while (result <= number)
            {
                iterator++;
                result = iterator * iterator;
            }
            return iterator - 1;
        }
        public double Result { get; set; }
    }
}