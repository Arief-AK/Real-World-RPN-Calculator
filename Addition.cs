namespace ReversePolishNotation
{
    public class Addition: IOperation
    {
        public string Description => ("Performing addition operation");
        public string Operator => "+";
        public int ArgumentsCount => 2;
        public double Execute(params double[] operands)
        {
            Result = operands[0] + operands[1];
            return Result;
        }
        public double Result { get; set; }
    }
}