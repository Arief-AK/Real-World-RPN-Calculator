using System;
using System.Collections.Generic;

namespace ReversePolishNotation
{
    public class RpnCalculator
    {
        // Private:
        private static readonly List<IOperation> Operations = new List<IOperation>();
        private Stack<double> _numberStack = new Stack<double>();

        // Public:
        public List<ExpressionTokens> ExpressionList = new List<ExpressionTokens>();

        public void AddOperation(IOperation operation)
        {
            Operations.Add(operation);
        }
        public List<string> OperationsHelp
        {
            get
            {
                var descriptions = new List<string>();
                foreach (var operation in Operations)
                {
                    descriptions.Add($"{operation.Operator} - {operation.Description}");
                }
                return descriptions;
            }
        }

        private static int FindOperatorIndex(string element, ref Parser parser)
        {
            // TODO: Find index of math operator
            var found = false;
            var opIndex = 0;

            while (!found)
            {
                if (element == parser.MathOperators[opIndex])
                {
                    found = true;
                }
                else
                {
                    opIndex++;
                }
            }
            return opIndex;
        }
        private static IOperation FindOperation(int index, ref Parser parser)
        {
            // TODO: Find which operation to perform
            var found = false;
            IOperation thisOperation = null;
            
            var opSymbol = parser.MathOperators[index];

            while (!found)
            {
                foreach (var operation in Operations)
                {
                    if (opSymbol == operation.Operator)
                    {
                        thisOperation = operation;
                        found = true;
                        break;
                    }
                }
            }
            
            return thisOperation;
        }

        public double Execute(string expression)
        {
            var parser = new Parser(expression);
            ExpressionList = parser.Tokens;

            foreach (var element in ExpressionList)
            {
                // TODO: If element is an operand, place on stack
                if (element.Type == TokenType.Operand)
                {
                    _numberStack.Push(int.Parse(element.Element));
                }
                else if(element.Type == TokenType.Operation)
                {
                    // TODO: Get the operation
                    var operation = FindOperation(FindOperatorIndex(element.Element, ref parser), ref parser);

                    switch (operation.ArgumentsCount)
                    {
                        // TODO: Perform operation
                        case 1:
                            var op = _numberStack.Pop();
                            _numberStack.Push(operation.Execute(op));
                            break;
                        case 2:
                            var op1 = _numberStack.Pop();
                            var op2 = _numberStack.Pop();
                            var operands = new[] {op1, op2};
                            _numberStack.Push(operation.Execute(operands));
                            break;
                    }
                }
                else
                {
                    throw new ArgumentException("Invalid token");
                }
            }
            return _numberStack.Pop();
        }
    }
}