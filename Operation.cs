namespace ReversePolishNotation
{
    public interface IOperation
    {
        public string Description { get; }
        public string Operator { get; }
        public int ArgumentsCount { get; }
        public double Execute(params double[] operands);
        public double Result { get; set; }
    }
}