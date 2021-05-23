using System;
using System.Collections.Generic;
using System.Linq;

public enum TokenType
{
    Operation,
    Operand
}

public struct ExpressionTokens
{
    public string Element { get; private set; }
    public TokenType Type { get; private set; }

    public ExpressionTokens(string element, TokenType type)
    {
        Element = element;
        Type = type;
    }
}

namespace ReversePolishNotation
{
    public class Parser
    {
        // Private:
        public readonly string[] MathOperators = {"+", "-", "*", "/", "sqrt"};

        // Public:
        public List<ExpressionTokens> Tokens { get; } = new List<ExpressionTokens>();
        
        public Parser(string expression)
        {
            string[] tokenList = expression.Split();
            
            foreach (var token in tokenList)
            {
                if (int.TryParse(token,out int operand))
                {
                    Tokens.Add(new ExpressionTokens(operand.ToString(),TokenType.Operand));
                }
                else if(MathOperators.Contains(token))
                {
                    Tokens.Add(new ExpressionTokens(token,TokenType.Operation));                 
                }
                else
                {
                    throw new ArgumentException("Invalid expression input, ensure operands and operators are" +
                                                " entered in between spaces");
                }
            }
        }
    }
}