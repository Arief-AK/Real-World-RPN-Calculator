namespace ReversePolishNotation
{
    public class Division:IOperation
    {
        public string Description => "Performing division operation";
        public string Operator => "/";
        public int ArgumentsCount => 2;
        public double Execute(params double[] operands)
        {
            return operands[0] / operands[1];
        }
        public double Result { get; set; }
    }
}