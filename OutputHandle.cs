using System;
using System.Collections.Generic;

namespace ReversePolishNotation
{
    public class OutputHandle
    {
        public void Write(string text)
        {
            Console.WriteLine(text);
        }
        public void Write(List<string> text)
        {
            Console.Write("\nDescriptions:\n");
            foreach (var segment in text)
            {
                Console.WriteLine(segment);
            }
        }
    }
}