using System.Collections.Generic;

namespace ReversePolishNotation
{
    public class Controller
    {
        private readonly RpnCalculator _calc;
        private readonly InputHandle _input;
        private readonly OutputHandle _output;
        public Controller(RpnCalculator calc, InputHandle input, OutputHandle output)
        {
            _calc = calc;
            _input = input;
            _output = output;
        }
        private List<string> OperationsHelp => _calc.OperationsHelp;

        public void Run()
        {
            var quitFlag = false;
            while (!quitFlag)
            {
                _output.Write("\nEnter an expression:        (h)Help (q)Quit");
                var uInput = _input.ReadInput();
                if (uInput == "h")
                {
                    _output.Write(OperationsHelp);
                }
                else if (uInput == "q")
                {
                    quitFlag = true;
                }
                else
                {
                    var result = _calc.Execute(uInput);
                    _output.Write($"Result:{result}");
                }
            }
        }
    }
}